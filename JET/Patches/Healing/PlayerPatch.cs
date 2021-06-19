using System.Reflection;
using System.Threading.Tasks;
using EFT;
using JET.Utilities.Patching;

namespace JET.Patches.Healing
{
    class PlayerPatch : GenericPatch<PlayerPatch>
    {
        private static string _playerAccountId;

        public PlayerPatch() : base(postfix: nameof(PatchPostfix)) { }

        protected override MethodBase GetTargetMethod()
        {
            return typeof(Player).GetMethod("Init", BindingFlags.NonPublic | BindingFlags.Instance);
        }

        static async void PatchPostfix(Player __instance, Task __result)
        {
            if (_playerAccountId == null)
            {
                var backendSession = Utilities.Config.BackEndSession;
                var profile = backendSession.Profile;
                _playerAccountId = profile.AccountId;
            }

			if (__instance.Profile.AccountId != _playerAccountId)
			{
				return;
			}

            await __result;

            var listener = Utilities.Player.HealthListener.Instance;
            listener.Init(__instance.HealthController, true);
        }
    }
}
