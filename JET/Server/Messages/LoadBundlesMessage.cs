using ComponentAce.Compression.Libs.zlib;
using EFT;
using UnityEngine.Networking;

#pragma warning disable 618

namespace JET.Server.Messages
{
    public class LoadBundlesMessage : MessageBase
    {
        public int ID = -1;
        public ResourceKey[] Prefabs;
        public string[] CustomizationIds = new string[0];

        public override void Serialize(NetworkWriter writer)
        {
            writer.Write(ID);

            var bundlesBytes = SimpleZlib.CompressToBytes(Prefabs.ToJson(), 9);
            writer.WriteBytesAndSize(bundlesBytes, bundlesBytes.Length);

#warning need reverse customization
            var customizationBytes = SimpleZlib.CompressToBytes(CustomizationIds.ToJson(), 9);
            writer.WriteBytesAndSize(customizationBytes, customizationBytes.Length);
            
            base.Serialize(writer);
        }

        public const int SelfBundleID = 5000;
        public const short MessageID = 188;
    }
}