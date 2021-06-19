using System;
using System.Linq;
using System.Reflection;
using EFT;
using EFT.InventoryLogic;
using JET.Utilities.Patching;
using JET.Utilities;
using static EFT.Player;

namespace JET.Patches.Progression
{
    public class SingleModeJamPatch : GenericPatch<SingleModeJamPatch>
    {
        private static MethodInfo _onFireEventMethod;

        public SingleModeJamPatch() : base(postfix: nameof(PatchPostfix))
        {
        }

        protected override MethodBase GetTargetMethod()
        {
            var targetType = PatcherConstants.TargetAssembly.GetTypes().Single(IsTargetType);
            _onFireEventMethod = targetType.GetMethod("OnFireEvent", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            return targetType.GetMethod("PrepareShot", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly);
        }

        private static bool IsTargetType(Type type)
        {
            if (type.DeclaringType == null
            || type.DeclaringType.DeclaringType == null
            || type.DeclaringType.Name != nameof(FirearmController)
            || type.DeclaringType.DeclaringType.Name != nameof(Player))
            {
                return false;
            }

            var methods = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly);

            if (!methods.Any(x => x.Name == "PrepareShot"))
            {
                return false;
            }

            var prepareShotMethod = type.GetMethod("PrepareShot", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            var methodbody = prepareShotMethod.GetMethodBody();
            if (!methodbody.LocalVariables.Any(x => x.LocalType == typeof(Weapon.EMalfunctionState)))
            {
                return false;
            }

            return true;
        }

        public static void PatchPostfix(object __instance, Weapon ___weapon_0, FirearmsAnimator ___firearmsAnimator_0, FirearmController ___firearmController_0)
        {
            if (!Config.WeaponDurabilityEnabled || ___weapon_0.MalfunctionState != Weapon.EMalfunctionState.Jam)
            {
                return;
            }

            _onFireEventMethod.Invoke(__instance, new object[] { });
            ___firearmsAnimator_0.Animator.Play("JAM", 1, 0f);
            ___firearmController_0.EmitEvents();
        }
    }
}
