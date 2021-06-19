using Comfort.Common;
using EFT;
using UnityEngine;

namespace JET.Utilities.Reflection
{
    internal static class ClientAppUtils
    {
        public static ClientApplication GetClientApp()
        {
            return Singleton<ClientApplication>.Instance;
        }

        public static MainApplication GetMainApp()
        {
            return GetClientApp() as MainApplication;
        }

        public static bool IsGameStarted()
        {
            var app = GetMainApp();

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
        public static bool StartLocalGame(string locationId)
        {
            var app = GetMainApp();

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