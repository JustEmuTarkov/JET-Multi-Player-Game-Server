using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ComponentAce.Compression.Libs.zlib;
using EFT;
using UnityEngine;
using UnityEngine.Networking;

#pragma warning disable 618

namespace JET.Server.Messages
{
    public class PlayerSpawnMessage : MessageBase
    {
        public int Id;
        public byte ChannelId;
        public Vector3 Position1;
        public byte ChannelIndex;
        public bool IsAlive;
        public Vector3 Position2;
        public Quaternion Rotation;
        public bool IsInPronePose;
        public float PoseLevel;
        public GClass1715 Inventory;
        public Profile PlayerProfile;


        public override void Serialize(NetworkWriter writer)
        {
            writer.Write(Id);
            writer.Write(ChannelId);
            writer.Write(Position1);
            writer.Write(ChannelIndex);
            writer.Write(IsAlive);
            writer.Write(Position2);
            writer.Write(Rotation);
            writer.Write(IsInPronePose);
            writer.Write(PoseLevel);

            using (var memoryStream = new MemoryStream())
            {
                using (var binaryWriter = new BinaryWriter(memoryStream))
                {
                    binaryWriter.Write(GClass970.SerializeInventory(Inventory));
                    byte[] buff = memoryStream.ToArray();
                    writer.WriteBytesAndSize(buff, buff.Length);
                }
            }

            byte[] profileData = SimpleZlib.CompressToBytes(PlayerProfile.ToJson(), 9);
            writer.WriteBytesAndSize(profileData, profileData.Length);

            base.Serialize(writer);
        }
    }
}