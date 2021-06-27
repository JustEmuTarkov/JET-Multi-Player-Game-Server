using System;
using System.Reflection;
using Comfort.Common;
using EFT;
using EFT.UI.Screens;
using UnityEngine;
using Random = UnityEngine.Random;

namespace JET.Utilities.Reflection
{
    internal static class LocalGameUtils
    {
        public static LocalGame GetLocalGame()
        {
            return Singleton<AbstractGame>.Instance as LocalGame;
        }

        public static FieldInfo GetFinishCallBack(AbstractGame game)
        {
            FieldInfo callBackField = PrivateValueAccessor.GetPrivateFieldInfo(game.GetType().BaseType, "callback_0");

            if (callBackField == null)
            {
                return null;
            }

            return callBackField;
        }

        public static FieldInfo GetCreatePlayerOwnerFunc(AbstractGame game)
        {
            FieldInfo createOwnerFunc = PrivateValueAccessor.GetPrivateFieldInfo(game.GetType().BaseType, "func_1");

            if (createOwnerFunc == null)
            {
                return null;
            }

            return createOwnerFunc;
        }

        public static FieldInfo GetCreatePlayerFunc(AbstractGame game)
        {
            FieldInfo createOwnerFunc = PrivateValueAccessor.GetPrivateFieldInfo(game.GetType().BaseType, "func_0");

            if (createOwnerFunc == null)
            {
                return null;
            }

            return createOwnerFunc;
        }

        public static GClass1194 GetMainMenu()
        {
            var app = ClientAppUtils.GetMainApp();

            return PrivateValueAccessor.GetPrivateFieldValue(app.GetType(), "gclass1194_0", app) as GClass1194;
        }


        public static bool IsGameReadyForStart()
        {
            return GClass2029.CheckCurrentScreen(EScreenType.MainMenu);
        }


        /**
         AvailableMaps 
		{
			"develop",
			"Woods",
			"factory4_day",
			"factory4_night",
			"bigmap",
			"Shoreline",
			"Interchange",
			"RezervBase",
			"laboratory"
		};
         */
        public static GClass782.GClass784 StartOfflineRaid(string locationId)
        {
            var app = ClientAppUtils.GetMainApp();
            if (app == null)
            {
                Debug.LogError("JET.Utilities.Reflection.LocalGameUtils.StartOfflineRaid: ERROR!!! app is empty");
                return null;
            }

            if (typeof(MainApplication) != app.GetType())
            {
                Debug.LogError("JET.Utilities.Reflection.LocalGameUtils.StartOfflineRaid: ERROR!!! instance of app is not equal to MainApplication!");
                return null;
            }

            var methodInfo = PrivateMethodAccessor.GetPrivateMethodByType(app.GetType(), "method_31");
            if (methodInfo == null)
            {
                Debug.LogError("JET.Utilities.Reflection.LocalGameUtils.StartOfflineRaid: ERROR!!! method_31 info is empty");
                return null;
            }

            GStruct92 timeAndWeather = default;
            var num = Random.Range(1, 6);

            var locationInfo = GClass512.Load<TextAsset>("LocalLoot/" + locationId + num).text
                .ParseJsonTo<GClass782.GClass783>();
            var localLoot = locationInfo.Location.ParseJsonTo<GClass782.GClass784>();

            PrivateValueAccessor.SetPrivateFieldValue(app.GetType(), "_localGame", app, true);

            try
            {
                methodInfo.Invoke(app, new object[] {localLoot, timeAndWeather, "factory4_day"});
                return localLoot;
            }
            catch (Exception e)
            {
                Debug.LogError("JET.Utilities.Reflection.LocalGameUtils.StartOfflineRaid: ERROR!!! methodInfo.Invoke ");
                Debug.LogError(e);
                throw;
            }

            return null;
        }
    }
}