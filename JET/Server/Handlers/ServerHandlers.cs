using JET.Server.Messages;
using UnityEngine.Networking;

#pragma warning disable 618

namespace JET.Server.Handlers
{
    public class ServerHandlers
    {
        public static void RegisterServerHandlers()
        {
        }

        private static void RegisterAuthHandler()
        {
            NetworkServer.RegisterHandler(AuthRequestMessage.MessageID, AuthHandlers.OnAuthMessage);
        }
    }
}