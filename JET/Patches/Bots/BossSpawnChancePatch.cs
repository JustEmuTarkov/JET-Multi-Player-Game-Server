using System.Linq;
using System.Reflection;
using JET.Utilities.Patching;

namespace JET.Patches.Bots
{
    public class BossSpawnChancePatch : GenericPatch<BossSpawnChancePatch>
    {
        private static float[] bossSpawnPercent;

        public BossSpawnChancePatch() : base(prefix: nameof(PrefixPatch), postfix: nameof(PostfixPatch)) { }

        static void PrefixPatch(BossLocationSpawn[] bossLocationSpawn)
        {
            bossSpawnPercent = bossLocationSpawn.Select(s => s.BossChance).ToArray();
        }

        static void PostfixPatch(ref BossLocationSpawn[] __result)
        {
            if (__result.Length != bossSpawnPercent.Length)
            {
                return;
            }

            for (var i = 0; i < bossSpawnPercent.Length; i++)
            {
                __result[i].BossChance = bossSpawnPercent[i];
            }
        }

        protected override MethodBase GetTargetMethod()
        {
            return PatcherConstants.LocalGameType.BaseType
                .GetMethods(BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.DeclaredOnly)
                .SingleOrDefault(m => IsTargetMethod(m));
        }

        private static bool IsTargetMethod(MethodInfo mi)
        {
            var parameters = mi.GetParameters();
            return (parameters.Length != 2 || parameters[0].Name != "wavesSettings" || parameters[1].Name != "bossLocationSpawn") ? false : true;
        }
    }
}
