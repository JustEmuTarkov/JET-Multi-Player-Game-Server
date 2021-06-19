using System.Reflection;
using JET.Utilities.Patching;
using MainMenuController = GClass1194; // SelectedDateTime
using IHealthController = GInterface169; // CarryingWeightAbsoluteModifier

namespace JET.Patches.Healing
{
    class MainMenuControllerPatch : GenericPatch<MainMenuControllerPatch>
    {
        static MainMenuControllerPatch()
        {
            _ = nameof(IHealthController.HydrationChangedEvent);
            _ = nameof(MainMenuController.HealthController);
        }

        public MainMenuControllerPatch() : base(postfix: nameof(PatchPostfix)) { }

        protected override MethodBase GetTargetMethod()
        {
            return typeof(MainMenuController).GetMethod("method_1", BindingFlags.NonPublic | BindingFlags.Instance);
        }

        static void PatchPostfix(MainMenuController __instance)
        {
            var healthController = __instance.HealthController;
            var listener = Utilities.Player.HealthListener.Instance;
            listener.Init(healthController, false);
        }
    }
}
