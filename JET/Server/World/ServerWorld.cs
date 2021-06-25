using System;
using BitPacking;
using Comfort.Common;
using EFT;
using EFT.Interactive;

namespace JET.Server.World
{
    public class ServerWorld : ClientWorld
    {
        private void Awake()
        {
            Singleton<ServerWorld>.Create(this);
            RegisterNetworkInteractionObjects();

            InitializeVariables();
        }


        private void InitializeVariables()
        {
            list_0.Clear();
            foreach (var worldInteractiveObject in worldInteractiveObject_0)
            {
                list_0.Add(worldInteractiveObject.GetStatusInfo(true));
            }

            Singleton<GameWorld>.Instance.RegisterBorderZones();
        }

        public void AddInteractiveObjectsStatusPacket()
        {
            var writer = new GClass740(new byte[ushort.MaxValue]);
            var interactiveObjects = worldInteractiveObject_0;

            writer.WriteUInt32UsingBitRange((uint) interactiveObjects.Length, new[] {4, 8, 10}, BitPackingTag.Unknown);

            foreach (var door in interactiveObjects)
            {
                var info = door.GetStatusInfo(true);

                writer.WriteLimitedInt32(info.NetId, 0, 2047, BitPackingTag.Unknown);
                writer.WriteBits(info.State, 5);

                if ((info.State & (uint) EDoorState.Interacting) == 0) continue;

                var angle = (info.Angle + 180f) / 15;
                writer.WriteBits((uint) angle, 5);
            }

            writer.Flush();

            var buffer = new byte[writer.BytesWritten];
            Array.Copy(writer.Buffer, buffer, writer.BytesWritten);

            var segment = new ArraySegment<byte>(buffer);
            base.AddInteractiveObjectsStatusPacket(segment);
        }
    }
}