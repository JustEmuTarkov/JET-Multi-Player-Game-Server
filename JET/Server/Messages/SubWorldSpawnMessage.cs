using System.Collections.Generic;
using System.IO;
using System.Linq;
using Comfort.Common;
using ComponentAce.Compression.Libs.zlib;
using EFT;
using EFT.InventoryLogic;
using JET.Server.Utils;
using UnityEngine.Networking;

#pragma warning disable 618

namespace JET.Server.Messages
{
    public class SubWorldSpawnMessage : MessageBase
    {
        public SubWorld SubWorld;

        public override void Serialize(NetworkWriter writer)
        {
            var mapLoot = Singleton<ServerInstance>.Instance.MapLootSettings.Loot.ToArray();
            SubWorld.OnSerialize(writer, mapLoot);

            base.Serialize(writer);
        }

        public const short MessageID = 153;
    }
}