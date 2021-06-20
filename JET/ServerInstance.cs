using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using Comfort.Common;
using EFT;
using JET.Server.Connection;
using JET.Server.Handlers;
using JET.Server.Player;
using JET.Server.Session;
using JET.Utilities.Reflection;
using UnityEngine;
using UnityEngine.Networking;

namespace JET
{
#pragma warning disable 618
    public class ServerInstance : NetworkManager, GInterface62
    {
        public static int NextChannelId = 5;
        public const int Port = 5000;

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
            Console.WriteLine("ServerInstance.Start");
        }

        public void FixedUpdate()
        {
            ulong currentIndex = LocalIndex;
            LocalIndex = currentIndex + 1UL;
            LocalTime += Time.deltaTime;

            if (!RaidStarted && LocalGameUtils.IsGameStarted())
            {
                Console.WriteLine("ServerInstance.FixedUpdate: starting MP server");
                RaidStarted = true;

                string locationId = "factory4_day";
                LocalGameUtils.StartOfflineRaid(locationId);
            }

            if (WorldSpawned)
                return;

            if (!NetworkServer.active)
            {
                var started = StartServer(Config.GetConfiguration(), 20);
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