using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using JET.Utilities.Patching;
using UnityEngine;

namespace JET.Patches.RaidFix
{
    class SpawnRandomizationPatch : GenericPatch<SpawnRandomizationPatch>
    {
        public SpawnRandomizationPatch() : base(transpiler: nameof(TranspilerPatch)) { }
        protected override MethodBase GetTargetMethod()
        {
            var targetType = PatcherConstants.TargetAssembly.GetTypes().First(x => x.IsClass &&
                                              x.GetMethods(
                                                  BindingFlags.NonPublic | BindingFlags.Instance |
                                                  BindingFlags.FlattenHierarchy).Any(y =>
                                                  y.Name.Contains(".") && y.Name.Split('.')[1] == "SelectSpawnPoint"));
            return targetType
                .GetMethods(BindingFlags.NonPublic | BindingFlags.Instance |
                            BindingFlags.FlattenHierarchy).Single(y =>
                    y.Name.Contains(".") && y.Name.Split('.')[1] == "SelectSpawnPoint");
        }

        public static IEnumerable<CodeInstruction> TranspilerPatch(IEnumerable<CodeInstruction> instructions)
        {
            int endIndex, lastRet;
            var startIndex = endIndex = lastRet = -1;

            var codes = instructions.ToList();
            for (var i = 0; i < codes.Count; i++)
            {
                var code = codes[i];
                if (code.opcode != OpCodes.Ret) continue;
                if (startIndex == -1)
                    startIndex = i - 7; // -7 to position before first if statement

                endIndex = lastRet + 1; // Call after second to last rest
                lastRet = i;
            }

            if (startIndex == -1)
            {
                Debug.LogError("[SpawnRandomizationPatch] Failed to find first ret statement. Using normal spawns.");
                return instructions;
            }

            if (endIndex <= 0)
            {
                Debug.LogError("[SpawnRandomizationPatch] Failed to find last ret statement. Using normal spawns.");
                return instructions;
            }


            // Insert a "br" statement to jump to the last return statement
            codes.Insert(startIndex, new CodeInstruction(OpCodes.Br, codes[endIndex].labels.First()));

            return codes.AsEnumerable();
        }
    }
}
