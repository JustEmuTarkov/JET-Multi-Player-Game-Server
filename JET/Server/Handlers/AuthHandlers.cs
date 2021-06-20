using Comfort.Common;
using EFT;
using JET.Server.Messages;
using JET.Server.Player;
using JET.Utilities;
using JET.Utilities.HTTP;
using UnityEngine.Networking;

#pragma warning disable 618

namespace JET.Server.Handlers
{
    public class AuthHandlers
    {
        public static void OnAuthMessage(NetworkMessage message)
        {
            var authRequest = message.ReadMessage<AuthRequestMessage>();
            var server = Singleton<ServerInstance>.Instance;

            var profiles = new Request(null, Config.BackendUrl).GetJson($"/client/game/profile/list/{authRequest.ProfileId}").ParseJsonTo<Profile[]>();

            var channelId = ServerInstance.GetNextChannelId();
            var spawnMessage = PlayerSpawnMessage.FromProfile(channelId, profiles[0]);

            var player = ServerPlayer.Create(spawnMessage.PlayerID, spawnMessage.Position, Singleton<ServerInstance>.Instance);
        }
    }
}