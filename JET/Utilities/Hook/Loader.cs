using UnityEngine;

namespace JET.Utilities.Hook
{
	public class Loader<T> where T : MonoBehaviour
	{
		private static GameObject HookObject
		{
			get
			{
				GameObject result = GameObject.Find("JET Instance");

				if (result == null)
				{
					result = new GameObject("JET Instance");
					Object.DontDestroyOnLoad(result);
				}

				return result;
			}
		}

		public static T Load()
		{
			return HookObject.GetOrAddComponent<T>();
		}
	}
}
