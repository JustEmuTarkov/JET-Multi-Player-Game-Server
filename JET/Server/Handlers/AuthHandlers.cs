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

            var request = new Request(null, Config.BackendUrl);
            var response = request.GetJson($"/server/profile/{authRequest.ProfileId}");
            var profile = response.ParseJsonTo<Request.ServerResponse<Profile>>().data;

            var channelId = ServerInstance.GetNextChannelId();
            var spawnMessage = PlayerSpawnMessage.FromProfile(channelId, profile);

            var player = ServerPlayer.Create(spawnMessage.PlayerID, spawnMessage.Position, Singleton<ServerInstance>.Instance);
            await player.Init(profile);

            player.channelIndex = (byte) channelId;
            server.NetworkClients.TryAdd(message.conn.connectionId, player);

            var playerPrefabs = profile.GetAllInventoryPrefabs();
            server.AllPrefabs.AddRange(playerPrefabs);

            /*var customizationIds = player.Profile.Customization.Select(pair => pair.Value);
            var msg = new LoadBundlesMessage()
            {
                Prefabs = playerPrefabs.ToArray(),
                CustomizationIds = customizationIds.ToArray(),
                ID = 5000
            };*/

            // send a player bundles to other players
            /*foreach (var gameSession in server.GameSessions.Values)
            {
                if (gameSession.connection.connectionId == message.conn.connectionId) continue;
                gameSession.BundlesQueue.Enqueue(msg);
            }*/

            var authResponseMessage = AuthResponseMessage.GetResponseMessage(profile);

            NetworkServer.SendToClient(
                message.conn.connectionId,
                AuthResponseMessage.MessageID,
                authResponseMessage
            );
        }
    }
}