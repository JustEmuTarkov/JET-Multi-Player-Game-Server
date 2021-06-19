using System;
using System.Linq;
using System.Reflection;

namespace JET.Utilities.Patching
{
    public static class PatcherConstants
    {
        public const BindingFlags DefaultBindingFlags = BindingFlags.NonPublic
                                               | BindingFlags.Public
                                               | BindingFlags.Instance
                                               | BindingFlags.DeclaredOnly;

        public static Assembly TargetAssembly = typeof(EFT.Player).Assembly;
        public static Type PreloaderUIType = TargetAssembly.GetTypes().Single(x => x.Name == "PreloaderUI");
        public static Type MainApplicationType = TargetAssembly.GetTypes().Single(x => x.Name == "MainApplication");
        public static Type BaseLocalGameType = TargetAssembly.GetTypes().Single(x => x.Name.ToLower().Contains("baselocalgame"));
        public static Type LocalGameType = TargetAssembly.GetTypes().Single(x => x.Name == "LocalGame");
        public static Type MatchmakerOfflineRaidType = TargetAssembly.GetTypes().Single(x => x.Name == "MatchmakerOfflineRaid");
        public static Type MenuControllerType = TargetAssembly.GetTypes().Single(x => x.GetProperty("QuestController") != null);

        public static Type BackendInterfaceType = TargetAssembly.GetTypes().Single(
            x => x.GetMethods().Select(y => y.Name).Contains("CreateClientSession") && x.IsInterface);
        public static Type SessionInterfaceType = TargetAssembly.GetTypes().Single(
            x => x.GetMethods().Select(y => y.Name).Contains("GetPhpSessionId") && x.IsInterface);

        public static Type ExfilPointManagerType = TargetAssembly.GetTypes().Single(x => x.GetMethod("InitAllExfiltrationPoints") != null);
        public static Type ProfileInfoType = TargetAssembly.GetTypes().Single(x => x.GetMethod("GetExperience") != null);

        public static Type FirearmControllerType = typeof(EFT.Player.FirearmController).GetNestedTypes().Single(x => x.GetFields(DefaultBindingFlags).
            Count(y => y.Name.Contains("gclass")) > 0 && x.GetFields(DefaultBindingFlags).Count(y => y.Name.Contains("callback")) > 0 && x.GetMethod("UseSecondMagForReload", DefaultBindingFlags) != null);
        public static string WeaponControllerFieldName = FirearmControllerType.GetFields(DefaultBindingFlags).
                Single(x => x.Name.Contains("gclass")).Name;

    }
}
