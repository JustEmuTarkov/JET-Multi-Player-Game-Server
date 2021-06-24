using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using Comfort.Common;
using EFT;
using EFT.UI;
using EFT.UI.Screens;
using JET.Server.Connection;
using JET.Server.Handlers;
using JET.Server.Player;
using JET.Server.Session;
using JET.Utilities.Reflection;
using UnityEngine;
using UnityEngine.Networking;

#pragma warning disable 618

namespace JET
{
    public class ServerInstance : NetworkManager, GInterface62
    {
        public static int NextChannelId = 5;

        public const int Port = 5000;
        public const int MaxConnections = 20;
        public const int MaxPlayersOnMap = 200;
        public GClass1345[] WeatherNodes;

        public ulong LocalIndex { get; set; }
        public double LocalTime { get; private set; }
        public bool RaidStarted { get; private set; }
        public bool WorldSpawned { get; private set; }

        public readonly List<ResourceKey> AllPrefabs = new List<ResourceKey>();
        public readonly ConcurrentDictionary<int, PlayerSession> GameSessions = new ConcurrentDictionary<int, PlayerSession>();
        public readonly ConcurrentDictionary<int, ServerPlayer> NetworkClients = new ConcurrentDictionary<int, ServerPlayer>();

        public void Start()
        {
            Singleton<ServerInstance>.Create(this);
            ClientAppUtils.EnableLogs(); // enable debug logs in game
            WeatherNodes = GClass1345.GetRandomTestWeatherNodes();
            Console.WriteLine("ServerInstance.Start");
        }

        public void FixedUpdate()
        {
            ulong currentIndex = LocalIndex;
            LocalIndex = currentIndex + 1UL;
            LocalTime += Time.deltaTime;

            if (!RaidStarted && LocalGameUtils.IsGameReadyForStart())
            {
                Console.WriteLine("ServerInstance.FixedUpdate: starting MP server");

                string locationId = "factory4_day";
                var result = LocalGameUtils.StartOfflineRaid(locationId);
                if (!result)
                {
                    Console.WriteLine("ServerInstance.FixedUpdate: unable to start mp server");
                }

                RaidStarted = result;
            }

            if (WorldSpawned)
                return;

            var gameWorld = Singleton<GameWorld>.Instance;
            if (gameWorld == null || gameWorld.AllLoot.Count <= 0)
                return;

            WorldSpawned = true;

            if (!NetworkServer.active)
            {
                networkPort = Port;
                networkAddress = "127.0.0.1";
                
                var started = StartServer(Config.GetHostConfiguration(), MaxConnections);
                if (!started)
                {
                    Console.WriteLine(
                        "ServerInstance.FixedUpdate: error occurred while starting UDP server on port " + Port);
                    return;
                }

                Console.WriteLine(
                    "ServerInstance.FixedUpdate: UDP server started on port " + Port);
                ServerHandlers.RegisterServerHandlers();
            }

            var game = LocalGameUtils.GetLocalGame();
            if (game == null)
                return;

            var levelPhysicsSettings = GClass494.GetAllComponentsOfType<LevelPhysicsSettings>(false);
            Console.WriteLine($"LevelPhysicsSettings count: {levelPhysicsSettings.Count}");
            GClass862.SetupPositionQuantizer(levelPhysicsSettings.ToArray()[0].GetGlobalBounds());

            //game.PlayerOwner.Player.GClass1652_0.SetExamined(true); // !!!!
            game.BotsController.DestroyInfo(game.PlayerOwner.Player);
            Singleton<GameWorld>.Instance.UnregisterPlayer(game.PlayerOwner.Player);
        }

        public override void OnServerReady(NetworkConnection conn)
        {
            Console.WriteLine("OnSceneReady called on client");
            SceneReadyHandler.OnSceneReady(conn);
            base.OnServerReady(conn);
        }

        private void OnApplicationQuit()
        {
            if (NetworkServer.active)
                NetworkServer.Shutdown();
        }

        public static int GetNextChannelId()
        {
            var id = ++NextChannelId;
            NextChannelId = (id % 2 == 0) ? ++id : id;

            Console.Write($"ServerInstance.GetNextChannelId: the new chanel Id is {id}");
            return id;
        }
    }
}