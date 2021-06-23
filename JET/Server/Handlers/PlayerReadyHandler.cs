using System;
using Comfort.Common;
using JET.Server.Messages;
using UnityEngine.Networking;

#pragma warning disable 618

namespace JET.Server.Handlers
{
    public static class PlayerReadyHandler
    {
        public static void OnPlayerReadyMessage(NetworkMessage message)
        {
            var someBundleMessage = new LoadBundlesMessage
            {
                ID = 0, Prefabs = Singleton<ServerInstance>.Instance.AllPrefabs.ToArray()
            };

            NetworkServer.SendToClient(
                message.conn.connectionId,
                LoadBundlesMessage.MessageID,
                someBundleMessage
            );

            Console.WriteLine($"OnPlayerReady received, conn id is: {message.conn.connectionId}");
        }
    }
}