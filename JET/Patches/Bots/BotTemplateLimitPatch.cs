using System.Collections.Generic;
using System.Reflection;
using System;
using UnityEngine;
using EFT;
using JET.Utilities.HTTP;
using JET.Utilities.Patching;
using JET.Utilities;
using WaveInfo = GClass929; // Field: Role (choose first one displayed as "Role")
using BotsPresets = GClass362; // Method: GetNewProfile (higher GClass number)

namespace JET.Patches.Bots
{
    public class BotTemplateLimitPatch : GenericPatch<BotTemplateLimitPatch>
    {
        public BotTemplateLimitPatch() : base(postfix: nameof(PatchPostfix))
        {
            // compile-time checks
            _ = nameof(BotsPresets.CreateProfile);
            _ = nameof(WaveInfo.Difficulty);
        }

        protected override MethodBase GetTargetMethod()
        {
            return typeof(BotsPresets).GetMethod("method_1", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly);
        }

        public static void PatchPostfix(List<WaveInfo> __result, List<WaveInfo> wavesProfiles, List<WaveInfo> delayed)
        {
            /*
                In short this method sums Limits by grouping wavesPropfiles collection by Role and Difficulty
                then in each group sets Limit to 30, the remainder is stored in "delayed" collection.
                So we change Limit of each group.
                Clear delayed waves, we don't need them if we have enough loaded profiles and in method_2 it creates a lot of garbage.
            */

            delayed?.Clear();
            
            foreach (WaveInfo wave in __result)
            {
                wave.Limit = Request(wave.Role);
            }
        }

        private static int Request(WildSpawnType role)
        {
            var json = new Request(null, Config.BackendUrl).GetJson("/singleplayer/settings/bot/limit/" + role.ToString());

            if (string.IsNullOrWhiteSpace(json))
            {
                Debug.LogError("[JET]: Received bot " + role.ToString() + " limit data is NULL, using fallback");
                return 30;
            }
            Debug.LogError("[JET]: Successfully received bot " + role.ToString() + " limit data");
            return Convert.ToInt32(json);
        }
    }
}
