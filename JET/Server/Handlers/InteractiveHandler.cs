using System;
using UnityEngine.Networking;

#pragma warning disable 618

namespace JET.Server.Handlers
{
    public class InteractiveHandler
    {
        public static void OnInteractivePacket(NetworkMessage message)
        {
            Console.WriteLine("JET.Server.Handlers.InteractiveHandler.OnInteractivePacket: new interactive packet received!");
        }

        public const short MessageID = 170;
    }
}