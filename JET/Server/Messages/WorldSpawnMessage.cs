using Comfort.Common;
using EFT;
using JET.Server.Utils;
using UnityEngine.Networking;

#pragma warning disable 618

namespace JET.Server.Messages
{
    public class WorldSpawnMessage : MessageBase
    {
        public override void Serialize(NetworkWriter writer)
        {
            var world = Singleton<GameWorld>.Instance.GetWorld();
            world.OnSerialize(writer);

            base.Serialize(writer);
        }

        public const short MessageID = 151;
    }
}