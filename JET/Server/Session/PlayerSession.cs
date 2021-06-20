using System;
using JET.Server.Player;
using UnityEngine;

namespace JET.Server.Session
{
    public class PlayerSession : AbstractGameSession
    {
        public bool isInLoadBundlesState;
        public bool isInSpawnObserverState;
        private float _nextActionTime = 5f;
        private float ShortPeriod = 2f;
        public ServerPlayer player;

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
    }
}