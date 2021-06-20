using System.Collections.Generic;
using System.IO;
using System.Linq;
using ComponentAce.Compression.Libs.zlib;
using EFT.InventoryLogic;
using UnityEngine.Networking;

#pragma warning disable 618

namespace JET.Server.Trash
{
    public static class PlayerSpawnMessageTrash
    {
        // Token: 0x060092E1 RID: 37601 RVA: 0x000FB0A7 File Offset: 0x000F92A7
        public static void SerializeSetupInfo(this SetupInfo setupInfo, NetworkWriter writer)
        {
            writer.Write(setupInfo.Count);
            writer.Write(setupInfo.Seed);
            writer.Write(setupInfo.Index);
        }

        // Token: 0x060092E2 RID: 37602 RVA: 0x000FB0CD File Offset: 0x000F92CD
        public static void DeserializeSetupInfo(this SetupInfo setupInfo, NetworkReader reader)
        {
            setupInfo.Count = reader.ReadInt32();
            setupInfo.Seed = reader.ReadInt32();
            setupInfo.Index = reader.ReadInt32();
        }

        public static void SerializeSearchableInfo(this NetworkWriter writer, IEnumerable<Item> loot)
        {
            var array2 = new byte[ushort.MaxValue];
            var gclass = new GClass740(array2);
            
            GClass858.Serialize(gclass, loot);
            gclass.Flush();
            writer.WriteBytesAndSize(gclass.Buffer, gclass.BytesWritten);
        }

        public class SetupInfo
        {
            // Token: 0x060092DF RID: 37599 RVA: 0x000FB07A File Offset: 0x000F927A
            public override string ToString()
            {
                return $"RandomsSetupInfo  Seed: {Seed}, Count: {Count}, Index: {Index}";
            }

            // Token: 0x040084A0 RID: 33952
            public int Seed;

            // Token: 0x040084A1 RID: 33953
            public int Count;

            // Token: 0x040084A2 RID: 33954
            public int Index;
        }
    }
}