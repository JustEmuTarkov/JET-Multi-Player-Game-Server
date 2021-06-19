using JET.Utilities.App;
using JET.Utilities.HTTP;
using System.Reflection;

namespace JET.Utilities
{
    public static class Offline
    {
        [ObfuscationAttribute(Exclude = true)]
        public class OfflineMode
        {
            public bool OfflineLootPatch= true;
            public bool OfflineSaveProfilePatch= true;
            public bool OfflineSpawnPointPatch= true;
            public bool WeaponDurabilityPatch= true;
            public bool SingleModeJamPatch= true;
            public bool ExperienceGainPatch= true;
            public bool MainMenuControllerPatch= true;
            public bool PlayerPatch= true;
            public bool MatchmakerOfflineRaidPatch= true;
            public bool MatchMakerSelectionLocationScreenPatch= true;
            public bool InsuranceScreenPatch= true;
            public bool BossSpawnChancePatch= true;
            public bool BotTemplateLimitPatch= true;
            public bool GetNewBotTemplatesPatch= true;
            public bool RemoveUsedBotProfilePatch= true;
            public bool SpawnPmcPatch= true;
            public bool CoreDifficultyPatch= true;
            public bool BotDifficultyPatch= true;
            public bool OnDeadPatch= true;
            public bool OnShellEjectEventPatch= true;
            public bool BotStationaryWeaponPatch= true;
            public bool BeaconPatch= true;
            public bool DogtagPatch= true;
            public bool LoadOfflineRaidScreenPatch= true;
            public bool ScavPrefabLoadPatch= true;
            public bool ScavProfileLoadPatch= true;
            public bool ScavSpawnPointPatch= true;
            public bool ScavExfilPatch= true;
            public bool EndByTimerPatch= true;
            public bool SpawnRandomizationPatch = true;
        }

        public static OfflineMode LoadModules()
        {
            try
            {
                var request = new Request(null, Utilities.Config.BackendUrl);
                var json = request.GetJson("/mode/offline");
                OfflineMode __offlineClass = Json.Deserialize<OfflineMode>(json);
                return __offlineClass;
            }
            catch
            { // if somehow this fails load offline anyway
                return new OfflineMode();
            }
        }
    }
}
