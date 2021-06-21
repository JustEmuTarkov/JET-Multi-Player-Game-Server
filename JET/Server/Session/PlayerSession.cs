using System;
using System.Collections.Generic;
using Comfort.Common;
using EFT;
using JET.Server.Messages;
using JET.Server.Player;
using UnityEngine;

namespace JET.Server.Session
{
    public class PlayerSession : AbstractGameSession
    {
        private float _nextActionTime = 5f;
        private float ShortPeriod = 2f;
        public ServerPlayer player;
        public bool[] availableChannels = new bool[ServerInstance.MaxPlayersOnMap];
        private readonly Queue<int> _spawnedQueue = new Queue<int>();

        public bool isInLoadBundlesState;
        public bool isInSpawnObserverState;

        public readonly Queue<PlayerSpawnMessage> SpawnQueue = new Queue<PlayerSpawnMessage>();
        public readonly Queue<LoadBundlesMessage> BundlesQueue = new Queue<LoadBundlesMessage>();


        private void Start()
        {
            Console.WriteLine($"NetworkGameSession started, con id: {connection.connectionId}");
            Console.WriteLine($"NetworkGameSession started, channel id: {chanelId}");
            Console.WriteLine($"NetworkGameSession started, channel index: {chanelIndex}");
        }

        private void FixedUpdate()
        {
            if (!(Time.time > _nextActionTime)) return;

            _nextActionTime = Time.time + ShortPeriod;

            if (sessionIsSpawned)
            {
                UpdatePerTenSec();
                return;
            }

            CallRpcGameMatching(5, 1, 10);
        }

        private void UpdatePerTenSec()
        {
            if (gameSyncTimeIsSent && !worldMessageIsSent)
            {
                var worldSpawnMessage = new WorldSpawnMessage();

                connection.Send(WorldSpawnMessage.MessageID, worldSpawnMessage);
                worldMessageIsSent = true;
                return;
            }

            if (worldMessageIsSent && !subWorldMessageIsSent)
            {
                var subWorldSpawnMessage = new SubWorldSpawnMessage();
                connection.Send(SubWorldSpawnMessage.MessageID, subWorldSpawnMessage);
                subWorldMessageIsSent = true;
                return;
            }

            if (subWorldMessageIsSent && !playerSpawnIsSent)
            {
                var serverInstance = Singleton<ServerInstance>.Instance;

                var spawnMessage = PlayerSpawnMessage.FromProfile(chanelId, player.Profile);
                spawnMessage.IsInSpawnOperation = false;

                connection.Send(PlayerSpawnMessage.MessageID, spawnMessage);

                foreach (var gameSession in serverInstance.GameSessions.Values)
                {
                    if (gameSession.chanelId == chanelId) continue;
                    gameSession.SpawnQueue.Enqueue(spawnMessage);
                }

                Console.WriteLine($"Player teleport SpawnPosition {spawnMessage.SpawnPosition}");

                player.Teleport(spawnMessage.SpawnPosition);
                playerSpawnIsSent = true;
                return;
            }

            if (BundlesQueue.Count > 0)
            {
                ShortPeriod = 0.1f;
                if (isInLoadBundlesState) return;

                var bundleMessage = BundlesQueue.Dequeue();
                connection.Send(LoadBundlesMessage.MessageID, bundleMessage);
                isInLoadBundlesState = true;
                return;
            }

            /*if (SpawnQueue.Count > 0)
            {
                //if (isInSpawnObserverState) return;

                var spawnMessage = SpawnQueue.Dequeue();

                connection.Send(ObserverSpawnMessage.MessageId, spawnMessage);
                isInSpawnObserverState = true;
                return;
            }*/

            if (playerIsSpawned && !gameSpawnedIsSent)
            {
                CallRpcGameSpawned();
                gameSpawnedIsSent = true;
                return;
            }

            if (gameSpawnedIsSent && !gameStartingIsSent)
            {
                CallRpcGameStarting(5);
                gameStartingIsSent = true;
                return;
            }

            if (gameStartingIsSent && !gameStartedIsSent)
            {
                CallRpcGameStarted(1, 3322);
                gameStartedIsSent = true;

                player.InventoryController.SetExamined(true);
                player.ManageGameQuests();
                RegisterEnemy();
            }
        }

        public void RegisterEnemy()
        {
            try
            {
                var localGame = Singleton<AbstractGame>.Instance as BaseLocalGame<GamePlayerOwner>;
                // ReSharper disable once Unity.NoNullPropagation
                localGame?.AllPlayers.Add(player);
               // LocalGameUtils.Get()?.BotsController.AddActivePLayer(player);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        /*protected override void CmdSpawnConfirm(int spawnedChannel)
        {
            var serverInstance = Singleton<ServerInstance>.Instance;
            var allBots = BotsMonitor.AllBots;

            Console.WriteLine(
                $"CmdSpawnConfirm from client {connection.connectionId} " +
                $"Spawned with channelId {spawnedChannel} " +
                $"Self channelId {chanelId}"
            );
            isInSpawnObserverState = false;

            if (chanelId == spawnedChannel)
            {
                if (playerIsSpawned) return;

                foreach (var gameSession in serverInstance.GameSessions.Values)
                {
                    if (gameSession.chanelId == chanelId) continue;
                    var spawnMessage = PlayerSpawnMessage.FromInstance(gameSession.player, gameSession.chanelId);

                    SpawnQueue.Enqueue(spawnMessage);
                }

                foreach (var bot in allBots.Values)
                {
                    var emitter = bot.GetComponent<BotStateEmitter>();
                    var spawnMessage = PlayerSpawnMessage.FromInstance(bot.GetPlayer, emitter.channelId);
                    spawnMessage.PlayerId = emitter.channelId;

                    SpawnQueue.Enqueue(spawnMessage);
                }

                playerIsSpawned = true;
            }
            else
            {
                if (allBots.TryGetValue(spawnedChannel, out var bot))
                {
                    var emitter = bot.GetComponent<BotStateEmitter>();
                    emitter.availableChannels[chanelId] = true;
                    return;
                }

                if (serverInstance.GameSessions.TryGetValue(spawnedChannel, out var session))
                {
                    session.availableChannels[chanelId] = true;

                    return;
                }
            }

            RpcSyncGameTime(DateTime.UtcNow.ToBinary());
            Singleton<ServerWorld>.Instance.AddInteractiveObjectsStatusPacket();
        }*/
    }
}