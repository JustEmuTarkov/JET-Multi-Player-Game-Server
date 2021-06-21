using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Networking;

#pragma warning disable 618

namespace JET.Server.Session
{
    public abstract class AbstractSession : NetworkBehaviour
    {
        public NetworkConnection connection;
        public byte chanelId;
        public byte chanelIndex;
        public string profileId = "empty";
        private EMemberCategory _memberCategory;

        public EMemberCategory MemberCategory
        {
            get => EMemberCategory.Developer;
            set => _memberCategory = value;
        }

        internal static NetworkHash128 NetworkHash128_0 => NetworkHash128.Parse("d");

        public NetworkConnection Connection
        {
            [CompilerGenerated] get { return networkConnection_0; }
            [CompilerGenerated] protected set { networkConnection_0 = value; }
        }

        protected static T smethod_0<T>(Transform parent, string name, string profileId, string token) where T : AbstractSession
        {
            T t = new GameObject
            {
                name = name,
                transform =
                {
                    parent = parent
                }
            }.AddComponent<T>();
            t.ProfileId = profileId;
            t.Token = token;
            return t;
        }

        public string ProfileId
        {
            get { return string_0; }
            private set { string_0 = value; }
        }

        public string Token
        {
            get { return string_1; }
            private set { string_1 = value; }
        }

        public virtual void ProfileResourcesLoadProgress(int id, float progress)
        {
        }

        private EMemberCategory ememberCategory_0;

        // Token: 0x04004A48 RID: 19016
        private NetworkConnection networkConnection_0;

        // Token: 0x04004A49 RID: 19017
        private string string_0;

        // Token: 0x04004A4A RID: 19018
        private string string_1;
    }
}