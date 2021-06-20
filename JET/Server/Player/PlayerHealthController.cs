using System;
using EFT;
using EFT.InventoryLogic;

namespace JET.Server.Player
{
    public class PlayerHealthController : GClass1438
    {
        public PlayerHealthController(Profile.GClass1127 profileHealth, GClass1731 inventory, GClass1143 skills) : base(profileHealth, inventory, skills)
        {
        }

        public override void ApplyItem(Item item, EBodyPart bodyPart, float? amount = null)
        {
            Console.WriteLine("JET.Server.Player.PlayerHealthController.PlayerHealthController.ApplyItem: not implemented");
        }

        public override void CancelApplyingItem()
        {
            Console.WriteLine("JET.Server.Player.PlayerHealthController.PlayerHealthController.CancelApplyingItem: not implemented");
        }

        protected override bool _sendNetworkSyncPackets => true;
    }
}