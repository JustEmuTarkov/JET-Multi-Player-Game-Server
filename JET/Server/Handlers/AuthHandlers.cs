using System.Linq;
using Comfort.Common;
using EFT;
using JET.Server.Messages;
using JET.Server.Player;
using JET.Server.Utils;
using JET.Utilities;
using JET.Utilities.HTTP;
using UnityEngine.Networking;

#pragma warning disable 618

namespace JET.Server.Handlers
{
    public class AuthHandlers
    {
        public static async void OnAuthMessage(NetworkMessage message)
        {
            var authRequest = message.ReadMessage<AuthRequestMessage>();
            var server = Singleton<ServerInstance>.Instance;

            var profiles = new Request(null, Config.BackendUrl).GetJson($"/client/game/profile/list/{authRequest.ProfileId}").ParseJsonTo<Profile[]>();

            var channelId = ServerInstance.GetNextChannelId();
            var spawnMessage = PlayerSpawnMessage.FromProfile(channelId, profiles[0]);

            var player = ServerPlayer.Create(spawnMessage.PlayerID, spawnMessage.Position, Singleton<ServerInstance>.Instance);
            await player.Init(profiles[0]);

            player.channelIndex = (byte) channelId;
            server.NetworkClients.TryAdd(message.conn.connectionId, player);

            var playerPrefabs = profiles[0].GetAllInventoryPrefabs();
            server.AllPrefabs.AddRange(playerPrefabs);

            var customizationIds = player.Profile.Customization.Select(pair => pair.Value);
            var msg = new LoadBundlesMessage()
            {
                Prefabs = playerPrefabs.ToArray(),
                //CustomizationIds = customizationIds.ToArray(),
                ID = 5000
            };
            
            foreach (var gameSession in server.GameSessions.Values)
            {
                if (gameSession.connection.connectionId == message.conn.connectionId) continue;
                gameSession.BundlesQueue.Enqueue(msg);
            }

        }
    }
}