using EFT.UI.Map;

namespace JET.Server.Utils
{
    public class GameUtils
    {
        public static MapPoints GetMapPoints(ESideType sideType, string locationId)
        {
            return GClass1376.Pop<MapPoints>("MapPointConfigs/" + locationId + (sideType == ESideType.Savage ? "_scav" : string.Empty));
        }
    }
}