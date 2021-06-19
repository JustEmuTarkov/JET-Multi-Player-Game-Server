using System;
using System.Collections.Concurrent;
using Comfort.Common;
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

        public readonly ConcurrentDictionary<int, EFT.NetworkGameSession> GameSessions =
            new ConcurrentDictionary<int, EFT.NetworkGameSession>();
        //public readonly ConcurrentDictionary<int, ServerPlayer> NetworkClients = new ConcurrentDictionary<int, ServerPlayer>();

        public void Start()
        {
            Singleton<ServerInstance>.Create(this);
            ClientAppUtils.EnableLogs(); // enable debug logs in game
            Console.WriteLine("ServerInstance.Start");
        }

        public void FixedUpdate()
        {
            
        }
    }
}