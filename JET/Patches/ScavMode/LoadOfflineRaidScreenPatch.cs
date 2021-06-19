using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using HarmonyLib;
using EFT;
using EFT.UI.Matchmaker;
using EFT.UI.Screens;
using JET.Utilities.Patching;
using JET.Utilities.Reflection;
using MenuController = GClass1194; // .SelectedKeyCard
using WeatherSettings = GStruct92; // IsRandomTime and IsRandomWeather
using BotsSettings = GStruct232; // IsScavWars and BotAmount
using WavesSettings = GStruct93; // IsTaggedAndCursed and IsBosses
using MatchmakerScreenCreator = EFT.UI.Matchmaker.MatchmakerOfflineRaid.GClass2026; // simply go to class below and search for new gclass simple as that...
using UnityEngine;

namespace JET.Patches.ScavMode
{
    using OfflineRaidAction = Action<bool, WeatherSettings, BotsSettings, WavesSettings>;

    public class LoadOfflineRaidScreenPatch : GenericPatch<LoadOfflineRaidScreenPatch>
    {
        private const string loadReadyScreenMethod = "method_35";
        private const string readyMethod = "method_50";

        //private static Type MenuController;

        public LoadOfflineRaidScreenPatch() : base(transpiler: nameof(PatchTranspiler)) { }

        protected override MethodBase GetTargetMethod()
        {
            /*
             search for Class816 but actually its Class1010
             so i made it so it searches for that thing automatickly less burden later on ...
            */
            return typeof(MenuController).GetNestedTypes(BindingFlags.NonPublic)
                .Single(x => x.Name.StartsWith("Class") && x.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance).Any(m => m.Name == "method_4"))
                .GetMethod("method_2", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly);
        }

        static IEnumerable<CodeInstruction> PatchTranspiler(IEnumerable<CodeInstruction> instructions)
        {
            var codes = new List<CodeInstruction>(instructions);
            var index = 26;
            var callCode = new CodeInstruction(OpCodes.Call, AccessTools.Method(typeof(LoadOfflineRaidScreenPatch), "LoadOfflineRaidScreenForScav"));

            codes[index].opcode = OpCodes.Nop;
            codes[index + 1] = callCode;
            codes.RemoveAt(index + 2);

            return codes.AsEnumerable();
        }

        // this one can give you a proper naming of class for MenuController 
        // we can make a program which grabs assembly and tries to resolve and write everything for that

        //private static Type GetMenuControllerClass() {
        //    if (MenuController == null)
        //        MenuController = PatcherConstants.TargetAssembly.GetTypes().Single(IsTargetType);
        //    return MenuController;
        //}
        //private static bool IsTargetType(Type type)
        //{
        //    var methods = type.GetMethods(BindingFlags.Public | BindingFlags.Instance);
        //    var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
        //    if ( !methods.Any(m => m.Name == "OnProfileChangeApplied") || 
        //         !methods.Any(m => m.Name == "TryGetAccessToLocation"))
        //        return false;

        //    if (!properties.Any(p => p.Name == "SelectedDateTime") || 
        //        !properties.Any(p => p.Name == "MatchingType") || 
        //        !properties.Any(p => p.Name == "InventoryController"))
        //        return false;

        //    return true;
        //}

        // Refer to MatchmakerOfflineRaid's subclass's OnShowNextScreen action definitions if these structs numbers change.
        public static void LoadOfflineRaidNextScreen(bool local, WeatherSettings weatherSettings, BotsSettings botsSettings, WavesSettings wavesSettings)
        {
            var menuController = PrivateValueAccessor.GetPrivateFieldValue(typeof(MainApplication),
                                    $"{typeof(MenuController).Name.ToLower()}_0", ClientAppUtils.GetMainApp()) as MenuController;

            if (menuController.SelectedLocation.Id == "laboratory")
            {
                wavesSettings.IsBosses = true;
            }

            PrivateValueAccessor.SetPrivateFieldValue(typeof(MenuController), "bool_0", menuController, local);
            PrivateValueAccessor.SetPrivateFieldValue(typeof(MenuController), $"{typeof(BotsSettings).Name.ToLower()}_0", menuController, botsSettings);
            PrivateValueAccessor.SetPrivateFieldValue(typeof(MenuController), $"{typeof(WeatherSettings).Name.ToLower()}_0", menuController, wavesSettings);
            PrivateValueAccessor.SetPrivateFieldValue(typeof(MenuController), $"{typeof(WavesSettings).Name.ToLower()}_0", menuController, weatherSettings);

            typeof(MenuController).GetMethod(loadReadyScreenMethod, BindingFlags.NonPublic | BindingFlags.Instance).Invoke(menuController, null);
        }

        public static void LoadOfflineRaidScreenForScav()
        {
            var menuController = PrivateValueAccessor.GetPrivateFieldValue(typeof(MainApplication),
                                    $"{typeof(MenuController).Name.ToLower()}_0", ClientAppUtils.GetMainApp());
            var gclass = new MatchmakerScreenCreator();

            gclass.OnShowNextScreen += LoadOfflineRaidNextScreen;
            gclass.OnShowReadyScreen += (OfflineRaidAction)Delegate.CreateDelegate(typeof(OfflineRaidAction), menuController, readyMethod);
            gclass.ShowScreen(EScreenState.Queued);
        }
    }
}
