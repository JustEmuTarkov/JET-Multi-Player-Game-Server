﻿using JET.Server.Messages;
using UnityEngine.Networking;

#pragma warning disable 618

namespace JET.Server.Handlers
{
    public class ServerHandlers
    {
        public static void RegisterServerHandlers()
        {
            NetworkServer.RegisterHandler(AuthRequestMessage.MessageID, AuthHandlers.OnAuthMessage);
            NetworkServer.RegisterHandler(LoadBundlesStatusMessage.MessageID, BundlesLoadHandler.OnReportProgressLoading);
        }

        public static void OnSceneReady(NetworkConnection conn)
        {
            SceneReadyHandler.OnSceneReady(conn);
        }
    }
}