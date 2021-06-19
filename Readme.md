# JustEmuTarkov - DLL Mod
Client-side runtime patches with usage of harmony and reflection to alter the client's behaviour without editing game files.

## Modules
- JET: Whole Module Edition Package Contains everything.
- JET.MultiPlayer: simulating full online game server using packets creation functions.
- JET.Launcher: a custom game launcher allows the game to be launched offline.

## Requirements
- Visual Studio 2017 or newer
- .NET Framework 4.6.1 or newer
- E.F.T. 0.12.7.9767

## Setup
All dependencies are provided, no additional setup required.

## Build
1. Visual Studio -> menubar -> rebuild solution.
2. Copy-paste all files inside `Build` into `game root directory`, overwrite when prompted.
  
## Credits
- TheMaoci  
- Apofis (MultiPlayer)  
- JET Team  
  
## Disclaimer
This repository is for research purposes only, the use of this code is your responsibility.  
I take NO responsibility and/or liability for how you choose to use any of the source code available here. By using any of the files available in this repository, you understand that you are AGREEING TO USE AT YOUR OWN RISK. Once again, ALL files available here are for EDUCATION and/or RESEARCH purposes ONLY. 
  
# Other  
  
## Refferences folder  
- 0Harmony.dll  
- Assembly-CSharp.dll (drag dropped on de4dot.exe to remove unicode's)  
- Comfort.dll  
- Newtonsoft.Json.dll  
- NLog.dll  
- NLog.JET.dll (for Launcher)  
- UnityEngine.dll  
- UnityEngine.AssetBundleModule.dll  
- UnityEngine.CoreModule.dll 
- UnityEngine.ImageConversionModule.dll   
- UnityEngine.UI.dll  
- UnityEngine.UnityWebRequestAssetBundleModule.dll  
- UnityEngine.UnityWebRequestModule.dll  
- UnityEngine.UnityWebRequestTextureModule.dll  
- zlib.net.dll  
  
## JustEmuTarkov File Structure
```bat
~\Hook\Target.cs --> NLog Main Load Function
~\Instance.cs --> Main Instance of this library
~\Patches\Core\BattleEyePatch.cs --> Patch To Remove Batteye
~\Patches\Bots\BossSpawnChancePatch.cs --> 
~\Patches\Bots\BotDifficultyPatch.cs --> 
~\Patches\Bots\BotTemplateLimitPatch.cs --> 
~\Patches\Bots\CoreDifficultyPatch.cs --> 
~\Patches\Bots\GetNewBotTemplatesPatch.cs --> 
~\Patches\Bots\RemoveUsedBotProfilePatch.cs --> 
~\Patches\Bots\SpawnPmcPatch.cs --> 
~\Patches\Bundles\BundleLoadPatch.cs --> 
~\Patches\Bundles\EasyAssetsPatch.cs --> 
~\Patches\Bundles\EasyBundlePatch.cs --> 
~\Patches\Healing\MainMenuControllerPatch.cs --> 
~\Patches\Healing\PlayerPatch.cs --> 
~\Patches\Matchmaker\InsuranceScreenPatch.cs --> 
~\Patches\Matchmaker\MatchmakerOfflineRaidPatch.cs --> 
~\Patches\Matchmaker\MatchMakerSelectionLocationScreenPatch.cs --> 
~\Patches\Core\NotificationSslPatch.cs --> Allow to use unsigned https certificate for Notifications
~\Patches\Progression\EndByTimerPatch.cs --> 
~\Patches\Progression\OfflineLootPatch.cs --> 
~\Patches\Progression\OfflineSavePatch.cs --> 
~\Patches\Progression\OfflineSpawnPointPatch.cs --> 
~\Patches\Progression\SingleModeJamPatch.cs --> 
~\Patches\Progression\WeaponDurabilityPatch.cs --> 
~\Patches\Quests\BeaconPatch.cs --> 
~\Patches\Quests\DogtagPatch.cs --> 
~\Patches\RaidFix\BotStationaryWeaponPatch.cs --> 
~\Patches\RaidFix\OnDeadPatch.cs --> 
~\Patches\RaidFix\OnShellEjectEventPatch.cs --> 
~\Patches\ScavMode\LoadOfflineRaidScreenPatch.cs --> 
~\Patches\ScavMode\ScavExfilPatch.cs --> 
~\Patches\ScavMode\ScavPrefabLoadPatch.cs --> 
~\Patches\ScavMode\ScavProfileLoadPatch.cs --> 
~\Patches\ScavMode\ScavSpawnPointPatch.cs --> 
~\Patches\Core\SslCertificatePatch.cs --> Allow to use unsigned https certificate for connecting client server overall
~\Patches\Core\UnityWebRequestPatch.cs --> 
~\Utilities\App\Json.cs --> Json Handler
~\Utilities\App\Logger.cs --> Logger Handler
~\Utilities\App\ProcessMonitor.cs --> Monitor Process (if running etc.)
~\Utilities\Config.cs --> 
~\Utilities\DefaultSettings\DefaultRaidSettings.cs --> 
~\Utilities\EasyBundleHelper.cs --> 
~\Utilities\Hook\Loader.cs --> Instance Loader Handler
~\Utilities\HTTP\Request.cs --> Https Request to URL handler
~\Utilities\Patching\AbstractPatch.cs --> 
~\Utilities\Patching\GenericPatch.cs --> 
~\Utilities\Patching\PatcherConstants.cs --> 
~\Utilities\Patching\PatcherUtil.cs --> 
~\Utilities\PatchLogger.cs --> 
~\Utilities\Player\HealthListener.cs --> 
~\Utilities\Player\PlayerHealth.cs --> 
~\Utilities\Player\SaveLootUtil.cs --> 
~\Utilities\Reflection\ClientAppUtils.cs --> 
~\Utilities\Reflection\CodeWrapper\Code.cs --> 
~\Utilities\Reflection\CodeWrapper\CodeGenerator.cs --> 
~\Utilities\Reflection\CodeWrapper\CodeWithLabel.cs --> 
~\Utilities\Reflection\LocalGameUtils.cs --> 
~\Utilities\Reflection\PrivateMethodAccessor.cs --> 
~\Utilities\Reflection\PrivateValueAccessor.cs --> 
~\Utilities\Settings.cs --> 
```



 
