using UnityEngine.Networking;

#pragma warning disable 618

namespace JET.Server.Messages
{
    public class AuthRequestMessage : MessageBase
    {
        public string ProfileId;
        public string Token;
        public bool ObserveOnly;
        public byte[] OpenEncryptionKey;
        public int OpenEncryptionKeyLength;
        public string LocationId;

        public override void Deserialize(NetworkReader reader)
        {
            ProfileId = reader.ReadString();
            Token = reader.ReadString();
            ObserveOnly = reader.ReadBoolean();
            OpenEncryptionKey = reader.ReadBytesAndSize();
            OpenEncryptionKeyLength = reader.ReadInt32();
            LocationId = reader.ReadString();
            base.Deserialize(reader);
        }

        public override void Serialize(NetworkWriter writer)
        {
            writer.Write(ProfileId);
            writer.Write(Token);
            writer.Write(ObserveOnly);
            writer.WriteBytesFull(OpenEncryptionKey);
            writer.Write(OpenEncryptionKeyLength);
            writer.Write(LocationId);
            base.Serialize(writer);
        }

        public const short MessageID = 147;
    }
}