using EFT.UI.SessionEnd;
using JET.Utilities.Patching;
using System.Linq;
using System.Reflection;


namespace JET.Patches.Progression
{
    public class ExperienceGainPatch : GenericPatch<ExperienceGainPatch>
    {
        public ExperienceGainPatch() : base(prefix: nameof(PrefixPatch), postfix: nameof(PostfixPatch)) { }

        static void PrefixPatch(ref bool isLocal)
        {
            isLocal = false;
        }

        static void PostfixPatch(ref bool isLocal)
        {
            isLocal = true;
        }

        protected override MethodBase GetTargetMethod()
        {
            return typeof(SessionResultExperienceCount)
                 .GetMethods(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly)
                 .FirstOrDefault(IsTargetMethod);
        }

        private static bool IsTargetMethod(MethodInfo mi)
        {
            var parameters = mi.GetParameters();

            if (parameters.Length != 3
                || parameters[0].Name != "profile"
                || parameters[1].ParameterType != typeof(bool)
                || parameters[1].Name != "isLocal"
                || parameters[2].Name != "exitStatus")
            {
                return false;
            }

            return true;
        }
    }

}
