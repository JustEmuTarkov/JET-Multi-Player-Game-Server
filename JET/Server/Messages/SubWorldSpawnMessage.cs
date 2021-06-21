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
        public override void Serialize(NetworkWriter writer)
        {
            writer.Write(true);

            var jsonLootItems = Singleton<GameWorld>.Instance.GetJsonLootItems();
            var lootItemArray = jsonLootItems.ToArray();
            
            using (MemoryStream memoryStream = new MemoryStream())
            {
                using (BinaryWriter binaryWriter = new BinaryWriter(memoryStream))
                {
                    binaryWriter.Write(GClass970.SerializeLootData(lootItemArray));
                    byte[] array = memoryStream.ToArray();
                    byte[] buffer = SimpleZlib.CompressToBytes(array, array.Length, 9);
                    writer.WriteBytesFull(buffer);
                }
            }

            IEnumerable<Item> allItemsFromCollections = lootItemArray.Select(x => x.Item).OfType<IContainerCollection>().GetAllItemsFromCollections();
            GClass740 gclass = new GClass740(new byte[ushort.MaxValue]);
            GClass858.Serialize(gclass, allItemsFromCollections);
            gclass.Flush();
            writer.WriteBytesAndSize(gclass.Buffer, gclass.BytesWritten);


            base.Serialize(writer);
        }

        public const short MessageID = 153;
    }
}