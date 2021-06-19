using System.Reflection;
using UnityEngine;
using JET.Utilities.HTTP;
using JET.Utilities.Patching;
using JET.Utilities;
using BotDifficultyHandler = GClass303; // Method: CheckOnExcude, LoadCoreByString

namespace JET.Patches.Bots
{
	public class CoreDifficultyPatch : GenericPatch<CoreDifficultyPatch>
	{
		public CoreDifficultyPatch() : base(prefix: nameof(PatchPrefix))
		{
        }

        protected override MethodBase GetTargetMethod()
        {
			return typeof(BotDifficultyHandler).GetMethod("LoadCoreByString", BindingFlags.Public | BindingFlags.Static);
		}

		public static bool PatchPrefix(ref string __result)
		{
            __result = Request();

			return string.IsNullOrWhiteSpace(__result);
        }

        private static string Request()
        {
            var json = new Request(null, Config.BackendUrl).GetJson("/singleplayer/settings/bot/difficulty/core/core");

            if (string.IsNullOrWhiteSpace(json))
            {
                Debug.LogError("[JET]: Received core bot difficulty data is NULL, using fallback");
                return null;
            }

            Debug.LogError("[JET]: Successfully received core bot difficulty data");
            return json;
        }
    }
}
