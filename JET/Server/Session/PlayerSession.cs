using System;
using System.Collections.Generic;
using Comfort.Common;
using EFT;
using JET.Server.Messages;
using JET.Server.Player;
using JET.Server.World;
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
            Debug.LogError($"NetworkGameSession started, con id: {Connection.connectionId}");
            Debug.LogError($"NetworkGameSession started, channel id: {chanelId}");
            Debug.LogError($"NetworkGameSession started, channel index: {chanelIndex}");
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

            RpcGameMatching(5, 1, 10);
        }

        private void UpdatePerTenSec()
        {
            if (gameSyncTimeIsSent && !worldMessageIsSent)
            {
                var worldSpawnMessage = new WorldSpawnMessage();

                Connection.Send(WorldSpawnMessage.MessageID, worldSpawnMessage);
                worldMessageIsSent = true;
                return;
            }

            if (worldMessageIsSent && !subWorldMessageIsSent)
            {
                var subWorldSpawnMessage = new SubWorldSpawnMessage();
                Connection.Send(SubWorldSpawnMessage.MessageID, subWorldSpawnMessage);
                subWorldMessageIsSent = true;
                return;
            }

            if (subWorldMessageIsSent && !playerSpawnIsSent)
            {
                var serverInstance = Singleton<ServerInstance>.Instance;

                var spawnMessage = PlayerSpawnMessage.FromProfile(chanelId, player.Profile);
                spawnMessage.IsInSpawnOperation = false;

                Connection.Send(PlayerSpawnMessage.MessageID, spawnMessage);

                foreach (var gameSession in serverInstance.GameSessions.Values)
                {
                    if (gameSession.chanelId == chanelId) continue;
                    gameSession.SpawnQueue.Enqueue(spawnMessage);
                }

                Debug.LogError($"Player teleport SpawnPosition {spawnMessage.SpawnPosition}");

                player.Teleport(spawnMessage.SpawnPosition);
                playerSpawnIsSent = true;
                return;
            }

            if (playerIsSpawned && !gameSpawnedIsSent)
            {
                RpcGameSpawned();
                gameSpawnedIsSent = true;
                return;
            }

            if (gameSpawnedIsSent && !gameStartingIsSent)
            {
                RpcGameStarting(5);
                gameStartingIsSent = true;
                return;
            }

            if (gameStartingIsSent && !gameStartedIsSent)
            {
                RpcGameStarted(1, 3322);
                gameStartedIsSent = true;

                player.InventoryController.SetExamined(true);
                //player.ManageGameQuests();
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
                Debug.LogError(e);
            }
        }

        protected override void CmdSpawnConfirm(int spawnedChannel)
        {
            Debug.LogError(
                $"CmdSpawnConfirm from client {Connection.connectionId} " +
                $"Spawned with channelId {spawnedChannel} " +
                $"Self channelId {chanelId}"
            );

            if (chanelId == spawnedChannel)
            {
                playerIsSpawned = true;
            }

            RpcSyncGameTime(DateTime.UtcNow.ToBinary());
            Singleton<ServerWorld>.Instance.AddInteractiveObjectsStatusPacket();
        }
    }
}