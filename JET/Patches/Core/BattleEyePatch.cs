using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using JET.Utilities.Patching;

namespace JET.Patches
{
	public class BattleEyePatch : GenericPatch<BattleEyePatch>
	{
        public static PropertyInfo __property;

		private string _MethodName = "RunValidation";
		private string _FieldName = "Succeed";

        public BattleEyePatch() : base(prefix: nameof(PatchPrefix)) {}

		protected override MethodBase GetTargetMethod()
		{
			System.Type __type = PatcherConstants.TargetAssembly.GetTypes().Single(x => x.GetMethod(_MethodName, BindingFlags.Public | BindingFlags.Instance) != null);

            __property = __type.GetProperty(_FieldName, BindingFlags.Public | BindingFlags.Instance);

            return __type.GetMethod(_MethodName, BindingFlags.Public | BindingFlags.Instance);
        }

        private static bool PatchPrefix(ref Task __result, object __instance)
		{
            __property.SetValue(__instance, true);
			__result = Task.CompletedTask;
			return false;
		}
	}
}
