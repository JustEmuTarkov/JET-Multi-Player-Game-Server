using System.Linq;
using System.Text;
using Comfort.Common;
using ComponentAce.Compression.Libs.zlib;
using EFT;
using EFT.Interactive;
using EFT.InventoryLogic;
using JET.Utilities.Reflection;
using UnityEngine;
using UnityEngine.Networking;

#pragma warning disable 618

namespace JET.Server.Messages
{
    public class AuthResponseMessage : MessageBase
    {
        public bool EncryptionEnabled = false;
        public bool DecryptionEnabled = false;
        public GClass938 GameDateTime;
        public byte[] Prefabs = new byte[0];
        public byte[] Customizations = new byte[0];
        public byte[] Weathers = new byte[0];
        public bool CanRestart = false;
        public EMemberCategory MemberCategory;
        public float FixedDeltaTime = 0.016666668f; //// Token: 0x04005E7A RID: 24186
        public byte[] Interactables = new byte[0];
        public byte[] SessionId = new byte[0];
        public Bounds LovelBounds;
        public ushort AntiCheatPort = 0;
        public ENetLogsLevel NetLogsLevel = ENetLogsLevel.None;
        public GClass335 gclass335_0 = new GClass335(); // info about build, not used by client
        public bool SpeedLimitsEnabled = false;
        public GClass1114.Config SpeedLimitsConfig = GClass1114.DefaultSpeedLimits;

        public override void Serialize(NetworkWriter writer)
        {
            writer.Write(EncryptionEnabled);
            writer.Write(DecryptionEnabled);

#warning gameDateTime not implemented!
            GameDateTime.Serialize(writer, true);

            writer.WriteBytesFull(Prefabs);
            writer.WriteBytesFull(Customizations);
            writer.WriteBytesFull(Weathers);
            writer.Write(CanRestart);
            writer.Write((int) MemberCategory);
            writer.Write(FixedDeltaTime);
            writer.WriteBytesFull(Interactables);
            writer.WriteBytesFull(SessionId);
            writer.Write(LovelBounds.min);
            writer.Write(LovelBounds.max);
            writer.Write(AntiCheatPort);
            writer.Write((byte) NetLogsLevel);
            gclass335_0.Serialize(writer);
            writer.Write(SpeedLimitsEnabled);
            if (SpeedLimitsEnabled)
            {
                SpeedLimitsConfig.Serialize(writer);
            }

            base.Serialize(writer);
        }

        public static AuthResponseMessage GetResponseMessage(Profile profile)
        {
            var server = Singleton<ServerInstance>.Instance;
            var gameWorld = Singleton<GameWorld>.Instance;

            var weatherBytes = SimpleZlib.CompressToBytes(server.weatherNodes.ToJson(), 9);

            var allInteractiveObjects = LocationScene.GetAllObjects<WorldInteractiveObject>().ToArray();
            var networkInteractiveObjects = allInteractiveObjects.ToDictionary(
                interactiveObject => interactiveObject.Id,
                interactiveObject => interactiveObject.NetId
            );
            var interactiveObjectsBytes = SimpleZlib.CompressToBytes(networkInteractiveObjects.ToJson(), 9);

            var localTime = ClientAppUtils.GetGameLocalTime();

            var items = gameWorld.GetJsonLootItems().Select(x => x.Item).ToArray();
            var lootPrefabs = items
                .OfType<IContainerCollection>()
                .GetAllItemsFromCollections()
                .Concat(items.Where(x => !(x is IContainerCollection)))
                .SelectMany(x => x.Template.AllResources)
                .ToArray();
            var prefabBytes = SimpleZlib.CompressToBytes(lootPrefabs.ToJson(), 9);

            var customizationItems = profile.Customization.Select(pair => pair.Value).ToArray();
            var customizationBytes = SimpleZlib.CompressToBytes(customizationItems.ToJson(), 9);

            var sessionId = Encoding.UTF8.GetBytes(profile.AccountId);

            return new AuthResponseMessage
            {
                MemberCategory = profile.Info.MemberCategory,
                LovelBounds = GClass862.UsualPositionQuantizer.GetBounds(),
                Weathers = weatherBytes,
                Interactables = interactiveObjectsBytes,
                GameDateTime = localTime,
                Prefabs = prefabBytes,
                Customizations = customizationBytes,
                SessionId = sessionId
            };
        }

        public const short MessageID = 147;
    }
}