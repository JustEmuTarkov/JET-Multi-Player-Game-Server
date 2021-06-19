using HarmonyLib;
using JET.Utilities;
using JET.Utilities.Patching;
using JET.Utilities.Reflection.CodeWrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace JET.Patches.Core
{
    class StreamerModePatch : GenericPatch<StreamerModePatch>
    {
        public StreamerModePatch() : base(transpiler: nameof(PatchTranspile)) { }

        protected override MethodBase GetTargetMethod()
        {
            return PatcherConstants.TargetAssembly.GetTypes().Single(x => x.GetMethod("SetStreamMode") != null).GetMethod("SetStreamMode");
        }

        static IEnumerable<CodeInstruction> PatchTranspile(IEnumerable<CodeInstruction> instructions)
        {
            var codes = new List<CodeInstruction>(instructions);
            var searchCode = new CodeInstruction(OpCodes.Ldc_I4_0);
            int Index = -1;

            for (var i = 0; i < codes.Count; i++)
            {
                if (codes[i].opcode == searchCode.opcode && codes[i].operand == searchCode.operand)
                {
                    codes[i].opcode = OpCodes.Ldarg_1;
                    Index++;
                }
            }

            // Patch failed
            if (Index < 3)
            {
                Debug.LogError("Patch Failed!!");
                PatchLogger.LogTranspileSearchError(MethodBase.GetCurrentMethod());
                return instructions;
            }
            return codes.AsEnumerable();
        }
    }
}
