using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Networking;

namespace JET.Server.Session
{
	public abstract class AbstractSession : NetworkBehaviour
	{
		internal static NetworkHash128 NetworkHash128_0
		{
			get
			{
				return NetworkHash128.Parse("d");
			}
		}

		public EMemberCategory MemberCategory
		{
			get
			{
				return ememberCategory_0;
			}
			protected set
			{
				ememberCategory_0 = value;
			}
		}

		public NetworkConnection Connection
		{
			[CompilerGenerated]
			get
			{
				return networkConnection_0;
			}
			[CompilerGenerated]
			protected set
			{
				networkConnection_0 = value;
			}
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
			get
			{
				return string_0;
			}
			private set
			{
				string_0 = value;
			}
		}

		public string Token
		{
			get
			{
				return string_1;
			}
			private set
			{
				string_1 = value;
			}
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
