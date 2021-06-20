using EFT;
using EFT.InventoryLogic;

namespace JET.Server.Player
{
    public class PlayerHealthController : GClass1438
    {
        public PlayerHealthController(Profile.GClass1127 profileHealth, GClass1731 inventory, GClass1143 skills) : base(
            profileHealth, inventory, skills)
        {
            
        }

        public override void ApplyItem(Item item, EBodyPart bodyPart, float? amount = null)
        {
            throw new System.NotImplementedException();
        }

        public override void CancelApplyingItem()
        {
            throw new System.NotImplementedException();
        }

        protected override bool _sendNetworkSyncPackets
        {
            get { return true; }
        }
    }
}