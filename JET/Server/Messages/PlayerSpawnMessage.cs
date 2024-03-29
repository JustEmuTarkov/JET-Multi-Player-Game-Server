﻿using System;
using System.IO;
using Comfort.Common;
using ComponentAce.Compression.Libs.zlib;
using EFT;
using EFT.InventoryLogic;
using JET.Server.Player;
using JET.Server.Trash;
using JET.Server.Utils;
using UnityEngine;
using UnityEngine.Networking;
using System.Collections.Generic;

#pragma warning disable 618

namespace JET.Server.Messages
{
    public class PlayerSpawnMessage : MessageBase
    {
        public int PlayerID = -1;
        public byte ChannelId = Byte.MinValue;
        public Vector3 Position = new Vector3(57.9f, 0.06f, 21.998f);
        public byte ChannelIndex = Byte.MinValue;
        public bool IsAlive = true;
        public Vector3 SpawnPosition = new Vector3(57.9f, 0.1f, 22.0f);
        public Quaternion Rotation = new Quaternion(0.0f, 0.5f, 0.0f, 0.9f);
        public bool IsInPronePose = false;
        public float PoseLevel = Single.NaN;
        public GClass1715 Inventory = new GClass1715();
        public Profile PlayerProfile = new Profile();
        public int IdGeneratorId = -1;
        public int ScavExfilMask = -1;
        public int AnimationVariant = -1;
        public EController Econtroller = EController.Empty;
        public bool IsInSpawnOperation = false;
        public PlayerSpawnMessageTrash.SetupInfo MisFireInfo = new PlayerSpawnMessageTrash.SetupInfo();
        public PlayerSpawnMessageTrash.SetupInfo JamInfo = new PlayerSpawnMessageTrash.SetupInfo();
        public bool IsStationaryWeapon = false;
        public string ItemId = String.Empty;
        public string[] SearchItemIds = new string[0]; // it's always 0 length, should be...
        public PlayerHealthController HealthController = null;

        public override void Serialize(NetworkWriter writer)
        {
            writer.Write(PlayerID);
            writer.Write(ChannelId);
            writer.Write(Position);
            writer.Write(ChannelIndex);
            writer.Write(IsAlive);
            writer.Write(SpawnPosition);
            writer.Write(Rotation);
            writer.Write(IsInPronePose);
            writer.Write(PoseLevel);

            // write inventory data
            using (var memoryStream = new MemoryStream())
            {
                using (var binaryWriter = new BinaryWriter(memoryStream))
                {
                    binaryWriter.Write(GClass970.SerializeInventory(Inventory));
                    var buff = memoryStream.ToArray();
                    writer.SafeWriteSizeAndBytes(buff, buff.Length);
                }
            }

            // write profile data
            byte[] profileData = SimpleZlib.CompressToBytes(PlayerProfile.ToJson(), 9);
            writer.SafeWriteSizeAndBytes(profileData, profileData.Length);

            // write searchable info
            writer.SerializeSearchableInfo(Inventory.AllPlayerItems);

            writer.Write(IdGeneratorId);

            if (IsAlive)
            {
                writer.Write(IsAlive);
                writer.Write(ScavExfilMask);

                var inv = new GClass1731(PlayerProfile, IdGeneratorId, true);
                var skills = new GClass1143(EPlayerSide.Bear);
                HealthController = new PlayerHealthController(PlayerProfile.Health, inv, skills);

                var healthState = HealthController.SerializeState();
                writer.SafeWriteSizeAndBytes(healthState, healthState.Length);

                writer.Write(AnimationVariant);
                writer.Write((byte) Econtroller);
                switch (Econtroller)
                {
                    case EController.None:
                        Debug.LogError(
                            "JET.Server.Messages.PlayerSpawnMessage.Serialize: WARNING! no hands controllers");
                        return;
                    case EController.Empty:
                        break;
                    case EController.Firearm:
                        writer.Write(IsInSpawnOperation);
                        MisFireInfo.SerializeSetupInfo(writer);
                        JamInfo.SerializeSetupInfo(writer);
                        writer.Write(IsStationaryWeapon);

                        writer.Write(ItemId);
                        break;
                    case EController.Meds:
                        writer.Write(ItemId);
                        break;
                    case EController.Grenade:
                        writer.Write(ItemId);
                        break;
                    case EController.Knife:
                        writer.Write(ItemId);
                        break;
                    case EController.QuickGrenade:
                        writer.Write(ItemId);
                        break;
                    case EController.QuickKnife:
                        writer.Write(ItemId);
                        break;
                    default:
                        throw new Exception(
                            "JET.Server.Messages.PlayerSpawnMessage.Serialize: Invalid EController enum value:" +
                            Econtroller);
                }
                //SearchItemIds - it is supposed to be 0, so lets just set length to 0 and leave SearchItemIds = null for now
                writer.Write((byte) 0);
                foreach (var t in SearchItemIds)
                {
                    writer.Write(t);
                }
            }

            base.Serialize(writer);
        }

        public static PlayerSpawnMessage FromProfile(int channelId, Profile profile)
        {
            var spawnMessage = new PlayerSpawnMessage
            {
                ChannelId = (byte) channelId, PlayerID = channelId, ChannelIndex = (byte) channelId,
                PlayerProfile = profile.Clone()
            };

            var server = Singleton<ServerInstance>.Instance;
            var mapPoints = GameUtils.GetMapPoints(profile.Info.Side == EPlayerSide.Savage ? ESideType.Savage : ESideType.Pmc, server.MapLootSettings.Id);
            spawnMessage.PlayerProfile.Info.EntryPoint = mapPoints.EntryPoints[0].Name; // this is not exact value, just random
            spawnMessage.Position = mapPoints.EntryPoints[0].PositionOnMap;

            spawnMessage.PlayerProfile.Inventory = default;
            spawnMessage.PlayerProfile.Inventory = profile.Inventory;
            spawnMessage.Inventory = profile.Inventory;

            return spawnMessage;
        }

        public const short MessageID = 155;
    }
}