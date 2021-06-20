using System.Linq;
using EFT;
using EFT.InventoryLogic;

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
    }
}