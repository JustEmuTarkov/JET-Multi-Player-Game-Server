using EFT;
using JET.Utilities.App;
using JET.Utilities.HTTP;

namespace JET.Utilities.Player
{
	class SaveLootUtil
	{
		public static void SaveProfileProgress(string backendUrl, string session, ExitStatus exitStatus, Profile profileData, PlayerHealth currentHealth, bool isPlayerScav)
		{
			SaveProfileRequest request = new SaveProfileRequest
			{
				exit = exitStatus.ToString().ToLower(),
				profile = profileData,
				health = currentHealth,
				isPlayerScav = isPlayerScav
			};

			// ToJson() uses an internal converter which prevents loops and do other internal things
			new Request(session, backendUrl).PutJson("/raid/profile/save", request.ToJson());
		}

		internal class SaveProfileRequest
		{
			public string exit = "left";
			public Profile profile;
			public bool isPlayerScav;
			public PlayerHealth health;
		}
	}
}
