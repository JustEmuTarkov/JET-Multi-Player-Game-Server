using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using HarmonyLib;
using EFT;
using JET.Utilities.Patching;

namespace JET.Patches.Bots
{
    public class SpawnPmcPatch : GenericPatch<SpawnPmcPatch>
    {
        private static Type targetInterface;
        private static Type targetType;

        private static AccessTools.FieldRef<object, WildSpawnType> wildSpawnTypeField;
        private static AccessTools.FieldRef<object, BotDifficulty> botDifficultyField;

        // gclass364 (the one containing method_1

        public SpawnPmcPatch() : base(prefix: nameof(PatchPrefix))
        {
            targetInterface = PatcherConstants.TargetAssembly.GetTypes().Single(IsTargetInterface);
            targetType = PatcherConstants.TargetAssembly.GetTypes().Single(IsTargetType);
            wildSpawnTypeField = AccessTools.FieldRefAccess<WildSpawnType>(targetType, "wildSpawnType_0"); // Type
            botDifficultyField = AccessTools.FieldRefAccess<BotDifficulty>(targetType, "botDifficulty_0"); // BotDifficulty
        }

        private static bool IsTargetInterface(Type type) =>
            type.IsInterface &&
            type.GetMethod("ChooseProfile", new[] { typeof(List<Profile>), typeof(bool) }) != null;

        private bool IsTargetType(Type type)
        {
            if (!targetInterface.IsAssignableFrom(type))
                return false;

            if (!type.GetMethods(BindingFlags.Public | BindingFlags.Instance)
                     .Any(m => m.Name == "SameSide"))
                return false;

            if (!type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                     .Any(f => f.FieldType == typeof(WildSpawnType) || 
                               f.FieldType == typeof(BotDifficulty)))
                return false;

            return true;
        }

        protected override MethodBase GetTargetMethod()
        {
            return targetType.GetMethod("method_1", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly);
        }

        public static bool PatchPrefix(object __instance, ref bool __result, Profile x)
        {
            var botType = wildSpawnTypeField(__instance);
            var botDifficulty = botDifficultyField(__instance);

            __result = x.Info.Settings.Role == botType && x.Info.Settings.BotDifficulty == botDifficulty;

            return false;
        }
    }
}
