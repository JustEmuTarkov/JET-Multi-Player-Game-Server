using System.Linq;
using Comfort.Common;
using EFT;
using EFT.InventoryLogic;
using JET.Utilities.Reflection;

namespace JET.Server.Utils
{
    public static class Extensions
    {
        public static ResourceKey[] GetAllInventoryPrefabs(this Profile profile)
        {
            Item[] sources = profile.Inventory.AllPlayerItems
                .Concat(profile.Inventory.GetAllEquipmentItems()).ToArray();

            return sources.SelectMany(x => x.Template.AllResources).ToArray();
        }

        public static EFT.World GetWorld(this GameWorld gameWorld)
        {
            return gameWorld.GetComponent<EFT.World>();
        }
    }
}