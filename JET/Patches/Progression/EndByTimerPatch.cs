using System;
using System.Linq;
using System.Reflection;
using UnityEngine;
using EFT;
using JET.Utilities.HTTP;
using JET.Utilities.Patching;
using JET.Utilities;

namespace JET.Patches.Progression
{
    /// <summary>
    /// Fixes exit status to 'MissingInAction' when the raid time ends. Default is Survived.
    /// </summary>
    class EndByTimerPatch : GenericPatch<EndByTimerPatch>
    {
        private static PropertyInfo _profileIdProperty;
        private static MethodInfo _stopRaidMethod;

        static EndByTimerPatch()
        {
            _profileIdProperty = PatcherConstants.LocalGameType
                .BaseType
                .GetProperty("ProfileId", BindingFlags.NonPublic | BindingFlags.Instance)
                ?? throw new InvalidOperationException("'ProfileId' property not found");

            // find method
            // protected void method_11(string profileId, ExitStatus exitStatus, string exitName, float delay = 0f)
            _stopRaidMethod = PatcherConstants.LocalGameType
                .BaseType
                .GetMethods(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly)
                .SingleOrDefault(IsStopRaidMethod)
                ?? throw new InvalidOperationException("Method not found");
        }

        private static bool IsStopRaidMethod(MethodInfo mi)
        {
            var parameters = mi.GetParameters();
            if (parameters.Length != 4
            || parameters[0].ParameterType != typeof(string)
            || parameters[0].Name != "profileId"
            || parameters[1].ParameterType != typeof(ExitStatus)
            || parameters[1].Name != "exitStatus"
            || parameters[2].ParameterType != typeof(string)
            || parameters[2].Name != "exitName"
            || parameters[3].ParameterType != typeof(float)
            || parameters[3].Name != "delay")
            {
                return false;
            }

            return true;
        }

        public EndByTimerPatch() : base(prefix: nameof(PrefixPatch)) { }

        protected override MethodBase GetTargetMethod()
        {
            return PatcherConstants.LocalGameType
                .BaseType
                .GetMethods(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly)
                .Single(x => x.Name.EndsWith("StopGame"));  // find explicit interface implementation
        }

        private static bool PrefixPatch(object __instance)
        {
            var profileId = _profileIdProperty.GetValue(__instance) as string;
            var enabled = Request();

            if (!enabled)
            {
                return true;
            }

            _stopRaidMethod.Invoke(__instance, new object[] { profileId, ExitStatus.MissingInAction, null, 0f });
            return false;
        }

        private static bool Request()
        {
            var json = new Request(null, Config.BackendUrl).GetJson("/singleplayer/settings/raid/endstate");

            if (string.IsNullOrWhiteSpace(json))
            {
                Debug.LogError("[JET]: Received NULL response for DefaultRaidSettings. Defaulting to fallback.");
                return false;
            }

            Debug.LogError("[JET]: Successfully received DefaultRaidSettings");
            return Convert.ToBoolean(json);
        }
    }
}
