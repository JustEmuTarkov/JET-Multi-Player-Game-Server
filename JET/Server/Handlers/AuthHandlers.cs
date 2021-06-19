using Comfort.Common;
using JET.Server.Messages;
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

            var json = new Request(null, Config.BackendUrl).GetJson(
                $"/client/game/profile/list/server/{authRequest.ProfileId}");

            var channelId = ServerInstance.GetNextChannelId();
        }
    }
}