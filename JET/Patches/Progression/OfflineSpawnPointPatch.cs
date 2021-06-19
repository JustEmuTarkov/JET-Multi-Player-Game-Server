using System.Reflection;
using UnityEngine;
using EFT;
using JET.Utilities.Patching;
using System.Linq;
using System;
using EFT.Game.Spawning;
using System.Collections.Generic;

namespace JET.Patches.Progression
{
    class OfflineSpawnPointPatch : GenericPatch<OfflineSpawnPointPatch>
    {
        public OfflineSpawnPointPatch() : base(prefix: nameof(PatchPrefix)) { }

        protected override MethodBase GetTargetMethod()
        {
            var targetType = PatcherConstants.TargetAssembly.GetTypes().First(IsTargetType);
            return targetType.GetMethods(PatcherConstants.DefaultBindingFlags).First(m => m.Name.Contains("SelectSpawnPoint"));
        }

        private static bool IsTargetType(Type type)
        {
            var methods = type.GetMethods(PatcherConstants.DefaultBindingFlags);

            if (!methods.Any(x => x.Name.IndexOf("CheckFarthestFromOtherPlayers", StringComparison.OrdinalIgnoreCase) != -1))
                return false;

            return !type.IsInterface;
        }

        public static bool PatchPrefix(ref ISpawnPoint __result, GInterface217 ___ginterface217_0, ESpawnCategory category, EPlayerSide side, string infiltration)
        {
            var spawnPoints = ___ginterface217_0.ToList();
            var unfilteredSpawnPoints = spawnPoints.ToList();
            var infils = spawnPoints.Select(sp => sp.Infiltration).Distinct();
            Debug.LogError($"PatchPrefix SelectSpawnPoint Infiltrations: {spawnPoints.Count} | {String.Join(", ", infils)}");

            Debug.LogError($"Filter by Infiltration: {infiltration}");
            spawnPoints = spawnPoints.Where(sp => sp != null && sp.Infiltration != null && (String.IsNullOrEmpty(infiltration) || sp.Infiltration.Equals(infiltration))).ToList();
            if (spawnPoints.Count == 0)
            {
                __result = GetFallBackSpawnPoint(unfilteredSpawnPoints, category, side, infiltration);
                return false;
            }

            Debug.LogError($"Filter by Categories: {category}");
            spawnPoints = spawnPoints.Where(sp => sp.Categories.Contain(category)).ToList();
            if (spawnPoints.Count == 0)
            {
                __result = GetFallBackSpawnPoint(unfilteredSpawnPoints, category, side, infiltration);
                return false;
            }

            Debug.LogError($"Filter by Side: {side}");
            spawnPoints = spawnPoints.Where(sp => sp.Sides.Contain(side)).ToList();
            if (spawnPoints.Count == 0)
            {
                __result = GetFallBackSpawnPoint(unfilteredSpawnPoints, category, side, infiltration);
                return false;
            }

            __result = spawnPoints.RandomElement();
            Debug.LogError($"PatchPrefix SelectSpawnPoint: {__result.Id}");
            return false;
        }

        private static ISpawnPoint GetFallBackSpawnPoint(List<ISpawnPoint> spawnPoints, ESpawnCategory category, EPlayerSide side, string infiltration)
        {
            Debug.LogError($"PatchPrefix SelectSpawnPoint: Couldn't find any spawn points for:  {category}  |  {side}  |  {infiltration}");
            var spawn = spawnPoints.Where(sp => sp.Categories.Contain(ESpawnCategory.Player)).RandomElement();
            Debug.LogError($"PatchPrefix SelectSpawnPoint: {spawn.Id}");
            return spawn;
        }

    }
}
