using EFT;

namespace JET.Server.Player
{
    public class PlayerInventoryController : EFT.Player.SinglePlayerInventoryController, GInterface197
    {
        public PlayerInventoryController(EFT.Player player, Profile profile, int idGeneratorId) : base(player, profile, idGeneratorId)
        {
        }
    }
    
}