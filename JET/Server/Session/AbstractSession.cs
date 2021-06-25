using UnityEngine;
using UnityEngine.Networking;

#pragma warning disable 618

namespace JET.Server.Session
{
    public abstract class AbstractSession : NetworkBehaviour
    {
        public byte chanelId;
        public byte chanelIndex;
        // Token: 0x170008D5 RID: 2261
        // (get) Token: 0x060047F1 RID: 18417 RVA: 0x000CDA2A File Offset: 0x000CBC2A
        internal static NetworkHash128 AuthorityHash => NetworkHash128.Parse("d");

        // Token: 0x170008D6 RID: 2262
        // (get) Token: 0x060047F2 RID: 18418 RVA: 0x000CDA36 File Offset: 0x000CBC36
        // (set) Token: 0x060047F3 RID: 18419 RVA: 0x000CDA3E File Offset: 0x000CBC3E
        public EMemberCategory memberCategory;

        // Token: 0x170008D7 RID: 2263
        // (get) Token: 0x060047F4 RID: 18420 RVA: 0x000CDA47 File Offset: 0x000CBC47
        // (set) Token: 0x060047F5 RID: 18421 RVA: 0x000CDA4F File Offset: 0x000CBC4F
        public NetworkConnection Connection;

        // Token: 0x060047F6 RID: 18422 RVA: 0x000CDA58 File Offset: 0x000CBC58
        protected static T New<T>(Transform parent, string name, string profileId, string token) where T : AbstractSession
        {
            T t = new GameObject
            {
                name = name,
                transform =
                {
                    parent = parent
                }
            }.AddComponent<T>();
            t.profileId = profileId;
            t.token = token;
            return t;
        }

        // Token: 0x170008D8 RID: 2264
        // (get) Token: 0x060047F7 RID: 18423 RVA: 0x000CDA8F File Offset: 0x000CBC8F
        // (set) Token: 0x060047F8 RID: 18424 RVA: 0x000CDA97 File Offset: 0x000CBC97
        public string profileId;

        // Token: 0x170008D9 RID: 2265
        // (get) Token: 0x060047F9 RID: 18425 RVA: 0x000CDAA0 File Offset: 0x000CBCA0
        // (set) Token: 0x060047FA RID: 18426 RVA: 0x000CDAA8 File Offset: 0x000CBCA8
        public string token;

        // Token: 0x060047FB RID: 18427 RVA: 0x000A29D7 File Offset: 0x000A0BD7
        public virtual void ProfileResourcesLoadProgress(int id, float progress)
        {
        }

        // Token: 0x060047FC RID: 18428 RVA: 0x000A29D7 File Offset: 0x000A0BD7
        protected virtual void OnDestroy()
        {
        }

        // Token: 0x060047FF RID: 18431 RVA: 0x0024D508 File Offset: 0x0024B708
        public override bool OnSerialize(NetworkWriter writer, bool forceAll)
        {
            return false;
        }

        // Token: 0x06004800 RID: 18432 RVA: 0x000A29D7 File Offset: 0x000A0BD7
        public override void OnDeserialize(NetworkReader reader, bool initialState)
        {
        }

        // Token: 0x04004A2F RID: 18991
        internal const short short_0 = 147;

        // Token: 0x04004A30 RID: 18992
        internal const short short_1 = 148;

        // Token: 0x04004A31 RID: 18993
        internal const short short_2 = 188;

        // Token: 0x04004A32 RID: 18994
        internal const short short_3 = 189;

        // Token: 0x04004A33 RID: 18995
        internal const short short_4 = 190;

        // Token: 0x04004A34 RID: 18996
        internal const short short_5 = 151;

        // Token: 0x04004A35 RID: 18997
        internal const short short_6 = 152;

        // Token: 0x04004A36 RID: 18998
        internal const short short_7 = 153;

        // Token: 0x04004A37 RID: 18999
        internal const short short_8 = 154;

        // Token: 0x04004A38 RID: 19000
        internal const short short_9 = 155;

        // Token: 0x04004A39 RID: 19001
        internal const short short_10 = 165;

        // Token: 0x04004A3A RID: 19002
        internal const short short_11 = 156;

        // Token: 0x04004A3B RID: 19003
        internal const short short_12 = 157;

        // Token: 0x04004A3C RID: 19004
        internal const short short_13 = 167;

        // Token: 0x04004A3D RID: 19005
        internal const short short_14 = 158;

        // Token: 0x04004A3E RID: 19006
        internal const short short_15 = 160;

        // Token: 0x04004A3F RID: 19007
        internal const short short_16 = 168;

        // Token: 0x04004A40 RID: 19008
        internal const short short_17 = 170;

        // Token: 0x04004A41 RID: 19009
        internal const short short_18 = 180;

        // Token: 0x04004A42 RID: 19010
        internal const short short_19 = 181;

        // Token: 0x04004A43 RID: 19011
        internal const short short_20 = 182;

        // Token: 0x04004A44 RID: 19012
        internal const short short_21 = 183;

        // Token: 0x04004A45 RID: 19013
        internal const ushort ushort_0 = 62000;

        // Token: 0x04004A46 RID: 19014
        internal const ushort ushort_1 = 62000;
    }
}