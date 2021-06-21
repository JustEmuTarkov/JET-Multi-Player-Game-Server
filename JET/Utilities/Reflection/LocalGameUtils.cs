using System.Reflection;
using Comfort.Common;
using UnityEngine;
using EFT;

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


        public static bool IsGameStarted()
        {
            var app = ClientAppUtils.GetMainApp();

            var g = PrivateValueAccessor.GetPrivateFieldValue(app.GetType().BaseType, "gclass1194_0", app);
            return g != null;
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
        public static bool StartOfflineRaid(string locationId)
        {
            var app = ClientAppUtils.GetMainApp();

            var methodInfo = PrivateMethodAccessor.GetPrivateMethodInfo(app, "method_31");
            if (methodInfo == null)
                return false;

            var timeAndWeather = new GStruct92(true, true);
            var num = Random.Range(1, 6);

            var locationInfo = GClass512.Load<TextAsset>("LocalLoot/" + locationId + num).text
                .ParseJsonTo<GClass782.GClass783>();
            var localLoot = locationInfo.Location.ParseJsonTo<GClass782.GClass784>();

            try
            {
                methodInfo.Invoke(app, new object[] {localLoot, timeAndWeather, ""});
            }
            catch
            {
                return false;
            }

            return true;
        }
    }
}