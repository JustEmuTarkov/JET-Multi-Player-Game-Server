using UnityEngine.Networking;

#pragma warning disable 618

namespace JET.Server.Messages
{
    public class LoadBundlesStatusMessage : MessageBase
    {
        internal string ProfileId;
        internal int TaskId;
        internal float ProgressValue;

        public override void Deserialize(NetworkReader reader)
        {
            ProfileId = reader.ReadString();
            TaskId = reader.ReadInt32();
            ProgressValue = reader.ReadSingle();
            
            base.Deserialize(reader);
        }

        public const short MessageID = 190;
    }
}