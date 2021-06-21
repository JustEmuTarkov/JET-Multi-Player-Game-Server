using System.Diagnostics.CodeAnalysis;
using EFT;
using UnityEngine;
using UnityEngine.Networking;

#pragma warning disable 618

namespace JET.Server.Session
{
    // Token: 0x02000BBE RID: 3006
    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
    [SuppressMessage("ReSharper", "IdentifierTypo")]
    public abstract class AbstractGameSession : AbstractSession
    {
        public bool gameSyncTimeIsSent;
        public bool worldMessageIsSent;
        public bool subWorldMessageIsSent;
        public bool playerSpawnIsSent;
        public bool gameSpawnedIsSent;
        public bool allPlayersSpawned;
        public bool gameStartingIsSent;
        public bool gameStartedIsSent;
        public bool playerIsSpawned;
        public bool sessionIsSpawned;

        protected static T smethod_1<T>(Transform parent, string name, string profileId, string token) where T : AbstractGameSession
        {
            var t = smethod_0<T>(parent, name, profileId, token);
            t.GetComponent<NetworkIdentity>().localPlayerAuthority = true;
            return t;
        }

        // Token: 0x06004772 RID: 18290 RVA: 0x000B41BA File Offset: 0x000B23BA
        public override float GetNetworkSendInterval()
        {
            return 0f;
        }

        // Token: 0x06004773 RID: 18291 RVA: 0x000CD425 File Offset: 0x000CB625
        public override int GetNetworkChannel()
        {
            return 0;
        }

        // Token: 0x06004774 RID: 18292 RVA: 0x000A29D7 File Offset: 0x000A0BD7
        [Command]
        protected virtual void vmethod_0()
        {
        }

        // Token: 0x06004775 RID: 18293 RVA: 0x000A29D7 File Offset: 0x000A0BD7
        [Command]
        protected virtual void vmethod_1()
        {
        }

        // Token: 0x06004776 RID: 18294 RVA: 0x000A29D7 File Offset: 0x000A0BD7
        [Command]
        protected virtual void vmethod_2()
        {
        }

        // Token: 0x06004777 RID: 18295 RVA: 0x000A29D7 File Offset: 0x000A0BD7
        [Command]
        protected virtual void vmethod_3()
        {
        }

        // Token: 0x06004778 RID: 18296 RVA: 0x000A29D7 File Offset: 0x000A0BD7
        [Command]
        protected virtual void vmethod_4()
        {
        }

        // Token: 0x06004779 RID: 18297 RVA: 0x000A29D7 File Offset: 0x000A0BD7
        [Command]
        protected virtual void vmethod_5()
        {
        }

        // Token: 0x0600477A RID: 18298 RVA: 0x000A29D7 File Offset: 0x000A0BD7
        [Command]
        protected virtual void vmethod_6()
        {
        }

        // Token: 0x0600477B RID: 18299 RVA: 0x000A29D7 File Offset: 0x000A0BD7
        [Command]
        protected virtual void vmethod_7()
        {
        }

        // Token: 0x0600477C RID: 18300 RVA: 0x000A29D7 File Offset: 0x000A0BD7
        [Command]
        protected virtual void vmethod_8()
        {
        }

        // Token: 0x0600477D RID: 18301 RVA: 0x000A29D7 File Offset: 0x000A0BD7
        [Command]
        protected virtual void vmethod_9()
        {
        }

        // Token: 0x0600477E RID: 18302 RVA: 0x000A29D7 File Offset: 0x000A0BD7
        [Command]
        protected virtual void vmethod_10(EPlayerSide side)
        {
        }

        // Token: 0x0600477F RID: 18303 RVA: 0x000A29D7 File Offset: 0x000A0BD7
        [Command]
        protected virtual void vmethod_11(EPlayerSide side)
        {
        }

        // Token: 0x06004780 RID: 18304 RVA: 0x000A29D7 File Offset: 0x000A0BD7
        [Command]
        protected virtual void vmethod_12(EPlayerSide side, int instanceId)
        {
        }

        // Token: 0x06004781 RID: 18305 RVA: 0x000A29D7 File Offset: 0x000A0BD7
        [Command]
        protected virtual void vmethod_13()
        {
        }

        // Token: 0x06004782 RID: 18306 RVA: 0x000A29D7 File Offset: 0x000A0BD7
        [Command]
        protected virtual void vmethod_14()
        {
        }

        // Token: 0x06004783 RID: 18307 RVA: 0x000A29D7 File Offset: 0x000A0BD7
        [Command]
        protected virtual void vmethod_15(int playerId)
        {
        }

        // Token: 0x06004784 RID: 18308 RVA: 0x000A29D7 File Offset: 0x000A0BD7
        [ClientRpc]
        protected virtual void vmethod_16()
        {
        }

        // Token: 0x06004785 RID: 18309 RVA: 0x000A29D7 File Offset: 0x000A0BD7
        [ClientRpc]
        protected virtual void vmethod_17(ushort activitiesCounter, ushort minCounter, int seconds)
        {
        }

        // Token: 0x06004786 RID: 18310 RVA: 0x000A29D7 File Offset: 0x000A0BD7
        [ClientRpc]
        protected virtual void vmethod_18(int seconds)
        {
        }

        // Token: 0x06004787 RID: 18311 RVA: 0x000A29D7 File Offset: 0x000A0BD7
        [ClientRpc]
        protected virtual void vmethod_19(Vector3 position, int exfiltrationId, string entryPoint)
        {
        }

        // Token: 0x06004788 RID: 18312 RVA: 0x000A29D7 File Offset: 0x000A0BD7
        [ClientRpc]
        protected virtual void vmethod_20(float pastTime, int escapeSeconds)
        {
        }

        // Token: 0x06004789 RID: 18313 RVA: 0x000A29D7 File Offset: 0x000A0BD7
        [ClientRpc]
        protected virtual void vmethod_21()
        {
        }

        // Token: 0x0600478A RID: 18314 RVA: 0x000A29D7 File Offset: 0x000A0BD7
        [ClientRpc]
        protected virtual void vmethod_22()
        {
        }

        // Token: 0x0600478B RID: 18315 RVA: 0x000A29D7 File Offset: 0x000A0BD7
        [ClientRpc]
        protected virtual void vmethod_23()
        {
        }

        // Token: 0x0600478C RID: 18316 RVA: 0x000A29D7 File Offset: 0x000A0BD7
        [ClientRpc]
        protected virtual void vmethod_24(ExitStatus exitStatus, int playTime)
        {
        }

        // Token: 0x0600478D RID: 18317 RVA: 0x000A29D7 File Offset: 0x000A0BD7
        [ClientRpc]
        protected virtual void vmethod_25(long time)
        {
        }

        // Token: 0x0600478E RID: 18318 RVA: 0x000A29D7 File Offset: 0x000A0BD7
        [ClientRpc]
        protected virtual void vmethod_26(byte[] data)
        {
        }

        // Token: 0x0600478F RID: 18319 RVA: 0x000A29D7 File Offset: 0x000A0BD7
        [ClientRpc]
        protected virtual void vmethod_27(EPlayerSide side, int instanceId)
        {
        }

        // Token: 0x06004790 RID: 18320 RVA: 0x000A29D7 File Offset: 0x000A0BD7
        [ClientRpc]
        protected virtual void vmethod_28(int escapeSeconds)
        {
        }

        // Token: 0x06004791 RID: 18321 RVA: 0x000A29D7 File Offset: 0x000A0BD7
        [ClientRpc]
        protected virtual void vmethod_29(int disconnectionCode, string additionalInfo, string technicalMessage)
        {
        }

        // Token: 0x06004792 RID: 18322 RVA: 0x000CD42C File Offset: 0x000CB62C
        protected AbstractGameSession()
        {
        }

        // Token: 0x06004793 RID: 18323 RVA: 0x000A29D7 File Offset: 0x000A0BD7
        private void method_1()
        {
        }

        // Token: 0x06004794 RID: 18324 RVA: 0x000CD434 File Offset: 0x000CB634
        protected static void smethod_2(NetworkBehaviour obj, NetworkReader reader)
        {
            if (!NetworkServer.active)
            {
                Debug.LogError("Command CmdSpawn called on client.");
                return;
            }

            ((AbstractGameSession) obj).vmethod_0();
        }

        // Token: 0x06004795 RID: 18325 RVA: 0x000CD453 File Offset: 0x000CB653
        protected static void smethod_3(NetworkBehaviour obj, NetworkReader reader)
        {
            if (!NetworkServer.active)
            {
                Debug.LogError("Command CmdRespawn called on client.");
                return;
            }

            ((AbstractGameSession) obj).vmethod_1();
        }

        // Token: 0x06004796 RID: 18326 RVA: 0x000CD472 File Offset: 0x000CB672
        protected static void smethod_4(NetworkBehaviour obj, NetworkReader reader)
        {
            if (!NetworkServer.active)
            {
                Debug.LogError("Command CmdStartGame called on client.");
                return;
            }

            ((AbstractGameSession) obj).vmethod_2();
        }

        // Token: 0x06004797 RID: 18327 RVA: 0x000CD491 File Offset: 0x000CB691
        protected static void smethod_5(NetworkBehaviour obj, NetworkReader reader)
        {
            if (!NetworkServer.active)
            {
                Debug.LogError("Command CmdStartGameAfterTeleport called on client.");
                return;
            }

            ((AbstractGameSession) obj).vmethod_3();
        }

        // Token: 0x06004798 RID: 18328 RVA: 0x000CD4B0 File Offset: 0x000CB6B0
        protected static void smethod_6(NetworkBehaviour obj, NetworkReader reader)
        {
            if (!NetworkServer.active)
            {
                Debug.LogError("Command CmdRestartGameInitiate called on client.");
                return;
            }

            ((AbstractGameSession) obj).vmethod_4();
        }

        // Token: 0x06004799 RID: 18329 RVA: 0x000CD4CF File Offset: 0x000CB6CF
        protected static void smethod_7(NetworkBehaviour obj, NetworkReader reader)
        {
            if (!NetworkServer.active)
            {
                Debug.LogError("Command CmdRestartGame called on client.");
                return;
            }

            ((AbstractGameSession) obj).vmethod_5();
        }

        // Token: 0x0600479A RID: 18330 RVA: 0x000CD4EE File Offset: 0x000CB6EE
        protected static void smethod_8(NetworkBehaviour obj, NetworkReader reader)
        {
            if (!NetworkServer.active)
            {
                Debug.LogError("Command CmdGameStarted called on client.");
                return;
            }

            ((AbstractGameSession) obj).vmethod_6();
        }

        // Token: 0x0600479B RID: 18331 RVA: 0x000CD50D File Offset: 0x000CB70D
        protected static void smethod_9(NetworkBehaviour obj, NetworkReader reader)
        {
            if (!NetworkServer.active)
            {
                Debug.LogError("Command CmdStopGame called on client.");
                return;
            }

            ((AbstractGameSession) obj).vmethod_7();
        }

        // Token: 0x0600479C RID: 18332 RVA: 0x000CD52C File Offset: 0x000CB72C
        protected static void smethod_10(NetworkBehaviour obj, NetworkReader reader)
        {
            if (!NetworkServer.active)
            {
                Debug.LogError("Command CmdSyncGameTime called on client.");
                return;
            }

            ((AbstractGameSession) obj).vmethod_8();
        }

        // Token: 0x0600479D RID: 18333 RVA: 0x000CD54B File Offset: 0x000CB74B
        protected static void smethod_11(NetworkBehaviour obj, NetworkReader reader)
        {
            if (!NetworkServer.active)
            {
                Debug.LogError("Command CmdDevelopRequestBot called on client.");
                return;
            }

            ((AbstractGameSession) obj).vmethod_9();
        }

        // Token: 0x0600479E RID: 18334 RVA: 0x000CD56A File Offset: 0x000CB76A
        protected static void smethod_12(NetworkBehaviour obj, NetworkReader reader)
        {
            if (!NetworkServer.active)
            {
                Debug.LogError("Command CmdDevelopmentSpawnBotRequest called on client.");
                return;
            }

            ((AbstractGameSession) obj).vmethod_10((EPlayerSide) reader.ReadInt32());
        }

        // Token: 0x0600479F RID: 18335 RVA: 0x000CD58F File Offset: 0x000CB78F
        protected static void smethod_13(NetworkBehaviour obj, NetworkReader reader)
        {
            if (!NetworkServer.active)
            {
                Debug.LogError("Command CmdDevelopmentSpawnBotOnServer called on client.");
                return;
            }

            ((AbstractGameSession) obj).vmethod_11((EPlayerSide) reader.ReadInt32());
        }

        // Token: 0x060047A0 RID: 18336 RVA: 0x000CD5B4 File Offset: 0x000CB7B4
        protected static void smethod_14(NetworkBehaviour obj, NetworkReader reader)
        {
            if (!NetworkServer.active)
            {
                Debug.LogError("Command CmdDevelopmentSpawnBotOnClient called on client.");
                return;
            }

            ((AbstractGameSession) obj).vmethod_12((EPlayerSide) reader.ReadInt32(), (int) reader.ReadPackedUInt32());
        }

        // Token: 0x060047A1 RID: 18337 RVA: 0x000CD5DF File Offset: 0x000CB7DF
        protected static void smethod_15(NetworkBehaviour obj, NetworkReader reader)
        {
            if (!NetworkServer.active)
            {
                Debug.LogError("Command CmdDisconnectAcceptedOnClient called on client.");
                return;
            }

            ((AbstractGameSession) obj).vmethod_13();
        }

        // Token: 0x060047A2 RID: 18338 RVA: 0x000CD5FE File Offset: 0x000CB7FE
        protected static void smethod_16(NetworkBehaviour obj, NetworkReader reader)
        {
            if (!NetworkServer.active)
            {
                Debug.LogError("Command CmdWorldSpawnConfirm called on client.");
                return;
            }

            ((AbstractGameSession) obj).vmethod_14();
        }

        // Token: 0x060047A3 RID: 18339 RVA: 0x000CD61D File Offset: 0x000CB81D
        protected static void smethod_17(NetworkBehaviour obj, NetworkReader reader)
        {
            if (!NetworkServer.active)
            {
                Debug.LogError("Command CmdSpawnConfirm called on client.");
                return;
            }

            ((AbstractGameSession) obj).vmethod_15((int) reader.ReadPackedUInt32());
        }

        // Token: 0x060047A4 RID: 18340 RVA: 0x0024BFE0 File Offset: 0x0024A1E0
        public void CallCmdSpawn()
        {
            if (!NetworkClient.active)
            {
                Debug.LogError("Command function CmdSpawn called on server.");
                return;
            }

            if (isServer)
            {
                vmethod_0();
                return;
            }

            NetworkWriter networkWriter = new NetworkWriter();
            networkWriter.Write(0);
            networkWriter.Write(5);
            networkWriter.WritePackedUInt32((uint) int_0);
            networkWriter.Write(GetComponent<NetworkIdentity>().netId);
            SendCommandInternal(networkWriter, 0, "CmdSpawn");
        }

        // Token: 0x060047A5 RID: 18341 RVA: 0x0024C04C File Offset: 0x0024A24C
        public void CallCmdRespawn()
        {
            if (!NetworkClient.active)
            {
                Debug.LogError("Command function CmdRespawn called on server.");
                return;
            }

            if (isServer)
            {
                vmethod_1();
                return;
            }

            NetworkWriter networkWriter = new NetworkWriter();
            networkWriter.Write(0);
            networkWriter.Write(5);
            networkWriter.WritePackedUInt32((uint) int_1);
            networkWriter.Write(GetComponent<NetworkIdentity>().netId);
            SendCommandInternal(networkWriter, 0, "CmdRespawn");
        }

        // Token: 0x060047A6 RID: 18342 RVA: 0x0024C0B8 File Offset: 0x0024A2B8
        public void CallCmdStartGame()
        {
            if (!NetworkClient.active)
            {
                Debug.LogError("Command function CmdStartGame called on server.");
                return;
            }

            if (isServer)
            {
                vmethod_2();
                return;
            }

            NetworkWriter networkWriter = new NetworkWriter();
            networkWriter.Write(0);
            networkWriter.Write(5);
            networkWriter.WritePackedUInt32((uint) int_2);
            networkWriter.Write(GetComponent<NetworkIdentity>().netId);
            SendCommandInternal(networkWriter, 0, "CmdStartGame");
        }

        // Token: 0x060047A7 RID: 18343 RVA: 0x0024C124 File Offset: 0x0024A324
        public void CallCmdStartGameAfterTeleport()
        {
            if (!NetworkClient.active)
            {
                Debug.LogError("Command function CmdStartGameAfterTeleport called on server.");
                return;
            }

            if (isServer)
            {
                vmethod_3();
                return;
            }

            NetworkWriter networkWriter = new NetworkWriter();
            networkWriter.Write(0);
            networkWriter.Write(5);
            networkWriter.WritePackedUInt32((uint) int_3);
            networkWriter.Write(GetComponent<NetworkIdentity>().netId);
            SendCommandInternal(networkWriter, 0, "CmdStartGameAfterTeleport");
        }

        // Token: 0x060047A8 RID: 18344 RVA: 0x0024C190 File Offset: 0x0024A390
        public void CallCmdRestartGameInitiate()
        {
            if (!NetworkClient.active)
            {
                Debug.LogError("Command function CmdRestartGameInitiate called on server.");
                return;
            }

            if (isServer)
            {
                vmethod_4();
                return;
            }

            NetworkWriter networkWriter = new NetworkWriter();
            networkWriter.Write(0);
            networkWriter.Write(5);
            networkWriter.WritePackedUInt32((uint) int_4);
            networkWriter.Write(GetComponent<NetworkIdentity>().netId);
            SendCommandInternal(networkWriter, 0, "CmdRestartGameInitiate");
        }

        // Token: 0x060047A9 RID: 18345 RVA: 0x0024C1FC File Offset: 0x0024A3FC
        public void CallCmdRestartGame()
        {
            if (!NetworkClient.active)
            {
                Debug.LogError("Command function CmdRestartGame called on server.");
                return;
            }

            if (isServer)
            {
                vmethod_5();
                return;
            }

            NetworkWriter networkWriter = new NetworkWriter();
            networkWriter.Write(0);
            networkWriter.Write(5);
            networkWriter.WritePackedUInt32((uint) int_5);
            networkWriter.Write(GetComponent<NetworkIdentity>().netId);
            SendCommandInternal(networkWriter, 0, "CmdRestartGame");
        }

        // Token: 0x060047AA RID: 18346 RVA: 0x0024C268 File Offset: 0x0024A468
        public void CallCmdGameStarted()
        {
            if (!NetworkClient.active)
            {
                Debug.LogError("Command function CmdGameStarted called on server.");
                return;
            }

            if (isServer)
            {
                vmethod_6();
                return;
            }

            NetworkWriter networkWriter = new NetworkWriter();
            networkWriter.Write(0);
            networkWriter.Write(5);
            networkWriter.WritePackedUInt32((uint) int_6);
            networkWriter.Write(GetComponent<NetworkIdentity>().netId);
            SendCommandInternal(networkWriter, 0, "CmdGameStarted");
        }

        // Token: 0x060047AB RID: 18347 RVA: 0x0024C2D4 File Offset: 0x0024A4D4
        public void CallCmdStopGame()
        {
            if (!NetworkClient.active)
            {
                Debug.LogError("Command function CmdStopGame called on server.");
                return;
            }

            if (isServer)
            {
                vmethod_7();
                return;
            }

            NetworkWriter networkWriter = new NetworkWriter();
            networkWriter.Write(0);
            networkWriter.Write(5);
            networkWriter.WritePackedUInt32((uint) int_7);
            networkWriter.Write(GetComponent<NetworkIdentity>().netId);
            SendCommandInternal(networkWriter, 0, "CmdStopGame");
        }

        // Token: 0x060047AC RID: 18348 RVA: 0x0024C340 File Offset: 0x0024A540
        public void CallCmdSyncGameTime()
        {
            if (!NetworkClient.active)
            {
                Debug.LogError("Command function CmdSyncGameTime called on server.");
                return;
            }

            if (isServer)
            {
                vmethod_8();
                return;
            }

            NetworkWriter networkWriter = new NetworkWriter();
            networkWriter.Write(0);
            networkWriter.Write(5);
            networkWriter.WritePackedUInt32((uint) int_8);
            networkWriter.Write(GetComponent<NetworkIdentity>().netId);
            SendCommandInternal(networkWriter, 0, "CmdSyncGameTime");
        }

        // Token: 0x060047AD RID: 18349 RVA: 0x0024C3AC File Offset: 0x0024A5AC
        public void CallCmdDevelopRequestBot()
        {
            if (!NetworkClient.active)
            {
                Debug.LogError("Command function CmdDevelopRequestBot called on server.");
                return;
            }

            if (isServer)
            {
                vmethod_9();
                return;
            }

            NetworkWriter networkWriter = new NetworkWriter();
            networkWriter.Write(0);
            networkWriter.Write(5);
            networkWriter.WritePackedUInt32((uint) int_9);
            networkWriter.Write(GetComponent<NetworkIdentity>().netId);
            SendCommandInternal(networkWriter, 0, "CmdDevelopRequestBot");
        }

        // Token: 0x060047AE RID: 18350 RVA: 0x0024C418 File Offset: 0x0024A618
        public void CallCmdDevelopmentSpawnBotRequest(EPlayerSide side)
        {
            if (!NetworkClient.active)
            {
                Debug.LogError("Command function CmdDevelopmentSpawnBotRequest called on server.");
                return;
            }

            if (isServer)
            {
                vmethod_10(side);
                return;
            }

            NetworkWriter networkWriter = new NetworkWriter();
            networkWriter.Write(0);
            networkWriter.Write(5);
            networkWriter.WritePackedUInt32((uint) int_10);
            networkWriter.Write(GetComponent<NetworkIdentity>().netId);
            networkWriter.Write((int) side);
            SendCommandInternal(networkWriter, 0, "CmdDevelopmentSpawnBotRequest");
        }

        // Token: 0x060047AF RID: 18351 RVA: 0x0024C48C File Offset: 0x0024A68C
        public void CallCmdDevelopmentSpawnBotOnServer(EPlayerSide side)
        {
            if (!NetworkClient.active)
            {
                Debug.LogError("Command function CmdDevelopmentSpawnBotOnServer called on server.");
                return;
            }

            if (isServer)
            {
                vmethod_11(side);
                return;
            }

            NetworkWriter networkWriter = new NetworkWriter();
            networkWriter.Write(0);
            networkWriter.Write(5);
            networkWriter.WritePackedUInt32((uint) int_11);
            networkWriter.Write(GetComponent<NetworkIdentity>().netId);
            networkWriter.Write((int) side);
            SendCommandInternal(networkWriter, 0, "CmdDevelopmentSpawnBotOnServer");
        }

        // Token: 0x060047B0 RID: 18352 RVA: 0x0024C500 File Offset: 0x0024A700
        public void CallCmdDevelopmentSpawnBotOnClient(EPlayerSide side, int instanceId)
        {
            if (!NetworkClient.active)
            {
                Debug.LogError("Command function CmdDevelopmentSpawnBotOnClient called on server.");
                return;
            }

            if (isServer)
            {
                vmethod_12(side, instanceId);
                return;
            }

            NetworkWriter networkWriter = new NetworkWriter();
            networkWriter.Write(0);
            networkWriter.Write(5);
            networkWriter.WritePackedUInt32((uint) int_12);
            networkWriter.Write(GetComponent<NetworkIdentity>().netId);
            networkWriter.Write((int) side);
            networkWriter.WritePackedUInt32((uint) instanceId);
            SendCommandInternal(networkWriter, 0, "CmdDevelopmentSpawnBotOnClient");
        }

        // Token: 0x060047B1 RID: 18353 RVA: 0x0024C57C File Offset: 0x0024A77C
        public void CallCmdDisconnectAcceptedOnClient()
        {
            if (!NetworkClient.active)
            {
                Debug.LogError("Command function CmdDisconnectAcceptedOnClient called on server.");
                return;
            }

            if (isServer)
            {
                vmethod_13();
                return;
            }

            NetworkWriter networkWriter = new NetworkWriter();
            networkWriter.Write(0);
            networkWriter.Write(5);
            networkWriter.WritePackedUInt32((uint) int_13);
            networkWriter.Write(GetComponent<NetworkIdentity>().netId);
            SendCommandInternal(networkWriter, 0, "CmdDisconnectAcceptedOnClient");
        }

        // Token: 0x060047B2 RID: 18354 RVA: 0x0024C5E8 File Offset: 0x0024A7E8
        public void CallCmdWorldSpawnConfirm()
        {
            if (!NetworkClient.active)
            {
                Debug.LogError("Command function CmdWorldSpawnConfirm called on server.");
                return;
            }

            if (isServer)
            {
                vmethod_14();
                return;
            }

            NetworkWriter networkWriter = new NetworkWriter();
            networkWriter.Write(0);
            networkWriter.Write(5);
            networkWriter.WritePackedUInt32((uint) int_14);
            networkWriter.Write(GetComponent<NetworkIdentity>().netId);
            SendCommandInternal(networkWriter, 0, "CmdWorldSpawnConfirm");
        }

        // Token: 0x060047B3 RID: 18355 RVA: 0x0024C654 File Offset: 0x0024A854
        public void CallCmdSpawnConfirm(int playerId)
        {
            if (!NetworkClient.active)
            {
                Debug.LogError("Command function CmdSpawnConfirm called on server.");
                return;
            }

            if (isServer)
            {
                vmethod_15(playerId);
                return;
            }

            NetworkWriter networkWriter = new NetworkWriter();
            networkWriter.Write(0);
            networkWriter.Write(5);
            networkWriter.WritePackedUInt32((uint) int_15);
            networkWriter.Write(GetComponent<NetworkIdentity>().netId);
            networkWriter.WritePackedUInt32((uint) playerId);
            SendCommandInternal(networkWriter, 0, "CmdSpawnConfirm");
        }

        // Token: 0x060047B4 RID: 18356 RVA: 0x000CD642 File Offset: 0x000CB842
        protected static void RpcGameSpawned(NetworkBehaviour obj, NetworkReader reader)
        {
            if (!NetworkClient.active)
            {
                Debug.LogError("RPC RpcGameSpawned called on server.");
                return;
            }

            ((AbstractGameSession) obj).vmethod_16();
        }

        // Token: 0x060047B5 RID: 18357 RVA: 0x000CD661 File Offset: 0x000CB861
        protected static void RpcGameMatching(NetworkBehaviour obj, NetworkReader reader)
        {
            if (!NetworkClient.active)
            {
                Debug.LogError("RPC RpcGameMatching called on server.");
                return;
            }

            ((AbstractGameSession) obj).vmethod_17((ushort) reader.ReadPackedUInt32(), (ushort) reader.ReadPackedUInt32(), (int) reader.ReadPackedUInt32());
        }

        // Token: 0x060047B6 RID: 18358 RVA: 0x000CD692 File Offset: 0x000CB892
        protected static void RpcGameStarting(NetworkBehaviour obj, NetworkReader reader)
        {
            if (!NetworkClient.active)
            {
                Debug.LogError("RPC RpcGameStarting called on server.");
                return;
            }

            ((AbstractGameSession) obj).vmethod_18((int) reader.ReadPackedUInt32());
        }

        // Token: 0x060047B7 RID: 18359 RVA: 0x000CD6B7 File Offset: 0x000CB8B7
        protected static void RpcGameStartingWithTeleport(NetworkBehaviour obj, NetworkReader reader)
        {
            if (!NetworkClient.active)
            {
                Debug.LogError("RPC RpcGameStartingWithTeleport called on server.");
                return;
            }

            ((AbstractGameSession) obj).vmethod_19(reader.ReadVector3(), (int) reader.ReadPackedUInt32(), reader.ReadString());
        }

        // Token: 0x060047B8 RID: 18360 RVA: 0x000CD6E8 File Offset: 0x000CB8E8
        protected static void RpcGameStarted(NetworkBehaviour obj, NetworkReader reader)
        {
            if (!NetworkClient.active)
            {
                Debug.LogError("RPC RpcGameStarted called on server.");
                return;
            }

            ((AbstractGameSession) obj).vmethod_20(reader.ReadSingle(), (int) reader.ReadPackedUInt32());
        }

        // Token: 0x060047B9 RID: 18361 RVA: 0x000CD714 File Offset: 0x000CB914
        protected static void RpcGameRestarting(NetworkBehaviour obj, NetworkReader reader)
        {
            if (!NetworkClient.active)
            {
                Debug.LogError("RPC RpcGameRestarting called on server.");
                return;
            }

            ((AbstractGameSession) obj).vmethod_21();
        }

        // Token: 0x060047BA RID: 18362 RVA: 0x000CD733 File Offset: 0x000CB933
        protected static void RpcGameRestarted(NetworkBehaviour obj, NetworkReader reader)
        {
            if (!NetworkClient.active)
            {
                Debug.LogError("RPC RpcGameRestarted called on server.");
                return;
            }

            ((AbstractGameSession) obj).vmethod_22();
        }

        // Token: 0x060047BB RID: 18363 RVA: 0x000CD752 File Offset: 0x000CB952
        protected static void RpcGameStopping(NetworkBehaviour obj, NetworkReader reader)
        {
            if (!NetworkClient.active)
            {
                Debug.LogError("RPC RpcGameStopping called on server.");
                return;
            }

            ((AbstractGameSession) obj).vmethod_23();
        }

        // Token: 0x060047BC RID: 18364 RVA: 0x000CD771 File Offset: 0x000CB971
        protected static void RpcGameStopped(NetworkBehaviour obj, NetworkReader reader)
        {
            if (!NetworkClient.active)
            {
                Debug.LogError("RPC RpcGameStopped called on server.");
                return;
            }

            ((AbstractGameSession) obj).vmethod_24((ExitStatus) reader.ReadInt32(), (int) reader.ReadPackedUInt32());
        }

        // Token: 0x060047BD RID: 18365 RVA: 0x000CD79C File Offset: 0x000CB99C
        protected static void RpcSyncGameTime(NetworkBehaviour obj, NetworkReader reader)
        {
            if (!NetworkClient.active)
            {
                Debug.LogError("RPC RpcSyncGameTime called on server.");
                return;
            }

            ((AbstractGameSession) obj).vmethod_25((long) reader.ReadPackedUInt64());
        }

        // Token: 0x060047BE RID: 18366 RVA: 0x000CD7C1 File Offset: 0x000CB9C1
        protected static void RpcDevelopSendBotData(NetworkBehaviour obj, NetworkReader reader)
        {
            if (!NetworkClient.active)
            {
                Debug.LogError("RPC RpcDevelopSendBotData called on server.");
                return;
            }

            ((AbstractGameSession) obj).vmethod_26(reader.ReadBytesAndSize());
        }

        // Token: 0x060047BF RID: 18367 RVA: 0x000CD7E6 File Offset: 0x000CB9E6
        protected static void RpcDevelopmentSpawnBotResponse(NetworkBehaviour obj, NetworkReader reader)
        {
            if (!NetworkClient.active)
            {
                Debug.LogError("RPC RpcDevelopmentSpawnBotResponse called on server.");
                return;
            }

            ((AbstractGameSession) obj).vmethod_27((EPlayerSide) reader.ReadInt32(), (int) reader.ReadPackedUInt32());
        }

        // Token: 0x060047C0 RID: 18368 RVA: 0x000CD811 File Offset: 0x000CBA11
        protected static void RpcSoftStopNotification(NetworkBehaviour obj, NetworkReader reader)
        {
            if (!NetworkClient.active)
            {
                Debug.LogError("RPC RpcSoftStopNotification called on server.");
                return;
            }

            ((AbstractGameSession) obj).vmethod_28((int) reader.ReadPackedUInt32());
        }

        // Token: 0x060047C1 RID: 18369 RVA: 0x000CD836 File Offset: 0x000CBA36
        protected static void RpcStartDisconnectionProcedure(NetworkBehaviour obj, NetworkReader reader)
        {
            if (!NetworkClient.active)
            {
                Debug.LogError("RPC RpcStartDisconnectionProcedure called on server.");
                return;
            }

            ((AbstractGameSession) obj).vmethod_29((int) reader.ReadPackedUInt32(), reader.ReadString(), reader.ReadString());
        }

        // Token: 0x060047C2 RID: 18370 RVA: 0x0024C6C8 File Offset: 0x0024A8C8
        public void CallRpcGameSpawned()
        {
            if (!NetworkServer.active)
            {
                Debug.LogError("RPC Function RpcGameSpawned called on client.");
                return;
            }

            NetworkWriter networkWriter = new NetworkWriter();
            networkWriter.Write(0);
            networkWriter.Write(2);
            networkWriter.WritePackedUInt32((uint) int_16);
            networkWriter.Write(GetComponent<NetworkIdentity>().netId);
            SendRPCInternal(networkWriter, 0, "RpcGameSpawned");
        }

        // Token: 0x060047C3 RID: 18371 RVA: 0x0024C724 File Offset: 0x0024A924
        public void CallRpcGameMatching(ushort activitiesCounter, ushort minCounter, int seconds)
        {
            if (!NetworkServer.active)
            {
                Debug.LogError("RPC Function RpcGameMatching called on client.");
                return;
            }

            NetworkWriter networkWriter = new NetworkWriter();
            networkWriter.Write(0);
            networkWriter.Write(2);
            networkWriter.WritePackedUInt32((uint) int_17);
            networkWriter.Write(GetComponent<NetworkIdentity>().netId);
            networkWriter.WritePackedUInt32(activitiesCounter);
            networkWriter.WritePackedUInt32(minCounter);
            networkWriter.WritePackedUInt32((uint) seconds);
            SendRPCInternal(networkWriter, 0, "RpcGameMatching");
        }

        // Token: 0x060047C4 RID: 18372 RVA: 0x0024C798 File Offset: 0x0024A998
        public void CallRpcGameStarting(int seconds)
        {
            if (!NetworkServer.active)
            {
                Debug.LogError("RPC Function RpcGameStarting called on client.");
                return;
            }

            NetworkWriter networkWriter = new NetworkWriter();
            networkWriter.Write(0);
            networkWriter.Write(2);
            networkWriter.WritePackedUInt32((uint) int_18);
            networkWriter.Write(GetComponent<NetworkIdentity>().netId);
            networkWriter.WritePackedUInt32((uint) seconds);
            SendRPCInternal(networkWriter, 0, "RpcGameStarting");
        }

        // Token: 0x060047C5 RID: 18373 RVA: 0x0024C7FC File Offset: 0x0024A9FC
        public void CallRpcGameStartingWithTeleport(Vector3 position, int exfiltrationId, string entryPoint)
        {
            if (!NetworkServer.active)
            {
                Debug.LogError("RPC Function RpcGameStartingWithTeleport called on client.");
                return;
            }

            NetworkWriter networkWriter = new NetworkWriter();
            networkWriter.Write(0);
            networkWriter.Write(2);
            networkWriter.WritePackedUInt32((uint) int_19);
            networkWriter.Write(GetComponent<NetworkIdentity>().netId);
            networkWriter.Write(position);
            networkWriter.WritePackedUInt32((uint) exfiltrationId);
            networkWriter.Write(entryPoint);
            SendRPCInternal(networkWriter, 0, "RpcGameStartingWithTeleport");
        }

        // Token: 0x060047C6 RID: 18374 RVA: 0x0024C870 File Offset: 0x0024AA70
        public void CallRpcGameStarted(float pastTime, int escapeSeconds)
        {
            if (!NetworkServer.active)
            {
                Debug.LogError("RPC Function RpcGameStarted called on client.");
                return;
            }

            NetworkWriter networkWriter = new NetworkWriter();
            networkWriter.Write(0);
            networkWriter.Write(2);
            networkWriter.WritePackedUInt32((uint) int_20);
            networkWriter.Write(GetComponent<NetworkIdentity>().netId);
            networkWriter.Write(pastTime);
            networkWriter.WritePackedUInt32((uint) escapeSeconds);
            SendRPCInternal(networkWriter, 0, "RpcGameStarted");
        }

        // Token: 0x060047C7 RID: 18375 RVA: 0x0024C8DC File Offset: 0x0024AADC
        public void CallRpcGameRestarting()
        {
            if (!NetworkServer.active)
            {
                Debug.LogError("RPC Function RpcGameRestarting called on client.");
                return;
            }

            NetworkWriter networkWriter = new NetworkWriter();
            networkWriter.Write(0);
            networkWriter.Write(2);
            networkWriter.WritePackedUInt32((uint) int_21);
            networkWriter.Write(GetComponent<NetworkIdentity>().netId);
            SendRPCInternal(networkWriter, 0, "RpcGameRestarting");
        }

        // Token: 0x060047C8 RID: 18376 RVA: 0x0024C938 File Offset: 0x0024AB38
        public void CallRpcGameRestarted()
        {
            if (!NetworkServer.active)
            {
                Debug.LogError("RPC Function RpcGameRestarted called on client.");
                return;
            }

            NetworkWriter networkWriter = new NetworkWriter();
            networkWriter.Write(0);
            networkWriter.Write(2);
            networkWriter.WritePackedUInt32((uint) int_22);
            networkWriter.Write(GetComponent<NetworkIdentity>().netId);
            SendRPCInternal(networkWriter, 0, "RpcGameRestarted");
        }

        // Token: 0x060047C9 RID: 18377 RVA: 0x0024C994 File Offset: 0x0024AB94
        public void CallRpcGameStopping()
        {
            if (!NetworkServer.active)
            {
                Debug.LogError("RPC Function RpcGameStopping called on client.");
                return;
            }

            NetworkWriter networkWriter = new NetworkWriter();
            networkWriter.Write(0);
            networkWriter.Write(2);
            networkWriter.WritePackedUInt32((uint) int_23);
            networkWriter.Write(GetComponent<NetworkIdentity>().netId);
            SendRPCInternal(networkWriter, 0, "RpcGameStopping");
        }

        // Token: 0x060047CA RID: 18378 RVA: 0x0024C9F0 File Offset: 0x0024ABF0
        public void CallRpcGameStopped(ExitStatus exitStatus, int playTime)
        {
            if (!NetworkServer.active)
            {
                Debug.LogError("RPC Function RpcGameStopped called on client.");
                return;
            }

            NetworkWriter networkWriter = new NetworkWriter();
            networkWriter.Write(0);
            networkWriter.Write(2);
            networkWriter.WritePackedUInt32((uint) int_24);
            networkWriter.Write(GetComponent<NetworkIdentity>().netId);
            networkWriter.Write((int) exitStatus);
            networkWriter.WritePackedUInt32((uint) playTime);
            SendRPCInternal(networkWriter, 0, "RpcGameStopped");
        }

        // Token: 0x060047CB RID: 18379 RVA: 0x0024CA5C File Offset: 0x0024AC5C
        public void CallRpcSyncGameTime(long time)
        {
            if (!NetworkServer.active)
            {
                Debug.LogError("RPC Function RpcSyncGameTime called on client.");
                return;
            }

            NetworkWriter networkWriter = new NetworkWriter();
            networkWriter.Write(0);
            networkWriter.Write(2);
            networkWriter.WritePackedUInt32((uint) int_25);
            networkWriter.Write(GetComponent<NetworkIdentity>().netId);
            networkWriter.WritePackedUInt64((ulong) time);
            SendRPCInternal(networkWriter, 0, "RpcSyncGameTime");
        }

        // Token: 0x060047CC RID: 18380 RVA: 0x0024CAC0 File Offset: 0x0024ACC0
        public void CallRpcDevelopSendBotData(byte[] data)
        {
            if (!NetworkServer.active)
            {
                Debug.LogError("RPC Function RpcDevelopSendBotData called on client.");
                return;
            }

            NetworkWriter networkWriter = new NetworkWriter();
            networkWriter.Write(0);
            networkWriter.Write(2);
            networkWriter.WritePackedUInt32((uint) int_26);
            networkWriter.Write(GetComponent<NetworkIdentity>().netId);
            networkWriter.WriteBytesFull(data);
            SendRPCInternal(networkWriter, 0, "RpcDevelopSendBotData");
        }

        // Token: 0x060047CD RID: 18381 RVA: 0x0024CB24 File Offset: 0x0024AD24
        public void CallRpcDevelopmentSpawnBotResponse(EPlayerSide side, int instanceId)
        {
            if (!NetworkServer.active)
            {
                Debug.LogError("RPC Function RpcDevelopmentSpawnBotResponse called on client.");
                return;
            }

            NetworkWriter networkWriter = new NetworkWriter();
            networkWriter.Write(0);
            networkWriter.Write(2);
            networkWriter.WritePackedUInt32((uint) int_27);
            networkWriter.Write(GetComponent<NetworkIdentity>().netId);
            networkWriter.Write((int) side);
            networkWriter.WritePackedUInt32((uint) instanceId);
            SendRPCInternal(networkWriter, 0, "RpcDevelopmentSpawnBotResponse");
        }

        // Token: 0x060047CE RID: 18382 RVA: 0x0024CB90 File Offset: 0x0024AD90
        public void CallRpcSoftStopNotification(int escapeSeconds)
        {
            if (!NetworkServer.active)
            {
                Debug.LogError("RPC Function RpcSoftStopNotification called on client.");
                return;
            }

            NetworkWriter networkWriter = new NetworkWriter();
            networkWriter.Write(0);
            networkWriter.Write(2);
            networkWriter.WritePackedUInt32((uint) int_28);
            networkWriter.Write(GetComponent<NetworkIdentity>().netId);
            networkWriter.WritePackedUInt32((uint) escapeSeconds);
            SendRPCInternal(networkWriter, 0, "RpcSoftStopNotification");
        }

        // Token: 0x060047CF RID: 18383 RVA: 0x0024CBF4 File Offset: 0x0024ADF4
        public void CallRpcStartDisconnectionProcedure(int disconnectionCode, string additionalInfo, string technicalMessage)
        {
            if (!NetworkServer.active)
            {
                Debug.LogError("RPC Function RpcStartDisconnectionProcedure called on client.");
                return;
            }

            NetworkWriter networkWriter = new NetworkWriter();
            networkWriter.Write(0);
            networkWriter.Write(2);
            networkWriter.WritePackedUInt32((uint) int_29);
            networkWriter.Write(GetComponent<NetworkIdentity>().netId);
            networkWriter.WritePackedUInt32((uint) disconnectionCode);
            networkWriter.Write(additionalInfo);
            networkWriter.Write(technicalMessage);
            SendRPCInternal(networkWriter, 0, "RpcStartDisconnectionProcedure");
        }

        // Token: 0x060047D0 RID: 18384 RVA: 0x0024CC68 File Offset: 0x0024AE68
        static AbstractGameSession()
        {
            RegisterCommandDelegate(typeof(AbstractGameSession), int_0, smethod_2);
            int_1 = 740792038;
            RegisterCommandDelegate(typeof(AbstractGameSession), int_1, smethod_3);
            int_2 = -1220356686;
            RegisterCommandDelegate(typeof(AbstractGameSession), int_2, smethod_4);
            int_3 = 1792897173;
            RegisterCommandDelegate(typeof(AbstractGameSession), int_3, smethod_5);
            int_4 = 273195288;
            RegisterCommandDelegate(typeof(AbstractGameSession), int_4, smethod_6);
            int_5 = -1501005473;
            RegisterCommandDelegate(typeof(AbstractGameSession), int_5, smethod_7);
            int_6 = -40021267;
            RegisterCommandDelegate(typeof(AbstractGameSession), int_6, smethod_8);
            int_7 = -750099178;
            RegisterCommandDelegate(typeof(AbstractGameSession), int_7, smethod_9);
            int_8 = 463608476;
            RegisterCommandDelegate(typeof(AbstractGameSession), int_8, smethod_10);
            int_9 = -1035840717;
            RegisterCommandDelegate(typeof(AbstractGameSession), int_9, smethod_11);
            int_10 = -1581543574;
            RegisterCommandDelegate(typeof(AbstractGameSession), int_10, smethod_12);
            int_11 = 102630535;
            RegisterCommandDelegate(typeof(AbstractGameSession), int_11, smethod_13);
            int_12 = -349255409;
            RegisterCommandDelegate(typeof(AbstractGameSession), int_12, smethod_14);
            int_13 = -1733636721;
            RegisterCommandDelegate(typeof(AbstractGameSession), int_13, smethod_15);
            int_14 = 1240699829;
            RegisterCommandDelegate(typeof(AbstractGameSession), int_14, smethod_16);
            int_15 = -1317447737;
            RegisterCommandDelegate(typeof(AbstractGameSession), int_15, smethod_17);
            int_16 = -1952818640;
            RegisterRpcDelegate(typeof(AbstractGameSession), int_16, RpcGameSpawned);
            int_17 = 2117859815;
            RegisterRpcDelegate(typeof(AbstractGameSession), int_17, RpcGameMatching);
            int_18 = -1157222870;
            RegisterRpcDelegate(typeof(AbstractGameSession), int_18, RpcGameStarting);
            int_19 = 1572370779;
            RegisterRpcDelegate(typeof(AbstractGameSession), int_19, RpcGameStartingWithTeleport);
            int_20 = -1838445225;
            RegisterRpcDelegate(typeof(AbstractGameSession), int_20, RpcGameStarted);
            int_21 = 94275293;
            RegisterRpcDelegate(typeof(AbstractGameSession), int_21, RpcGameRestarting);
            int_22 = -1243884988;
            RegisterRpcDelegate(typeof(AbstractGameSession), int_22, RpcGameRestarted);
            int_23 = -758380962;
            RegisterRpcDelegate(typeof(AbstractGameSession), int_23, RpcGameStopping);
            int_24 = -1825579357;
            RegisterRpcDelegate(typeof(AbstractGameSession), int_24, RpcGameStopped);
            int_25 = 547040626;
            RegisterRpcDelegate(typeof(AbstractGameSession), int_25, RpcSyncGameTime);
            int_26 = 1152897188;
            RegisterRpcDelegate(typeof(AbstractGameSession), int_26, RpcDevelopSendBotData);
            int_27 = -1269941968;
            RegisterRpcDelegate(typeof(AbstractGameSession), int_27, RpcDevelopmentSpawnBotResponse);
            int_28 = -435294673;
            RegisterRpcDelegate(typeof(AbstractGameSession), int_28, RpcSoftStopNotification);
            int_29 = 1124901489;
            RegisterRpcDelegate(typeof(AbstractGameSession), int_29, RpcStartDisconnectionProcedure);
            NetworkCRC.RegisterBehaviour("AbstractGameSession", 0);
        }

        private static int int_0 = -1723132743;

        // Token: 0x040049EB RID: 18923
        private static int int_1;

        // Token: 0x040049EC RID: 18924
        private static int int_2;

        // Token: 0x040049ED RID: 18925
        private static int int_3;

        // Token: 0x040049EE RID: 18926
        private static int int_4;

        // Token: 0x040049EF RID: 18927
        private static int int_5;

        // Token: 0x040049F0 RID: 18928
        private static int int_6;

        // Token: 0x040049F1 RID: 18929
        private static int int_7;

        // Token: 0x040049F2 RID: 18930
        private static int int_8;

        // Token: 0x040049F3 RID: 18931
        private static int int_9;

        // Token: 0x040049F4 RID: 18932
        private static int int_10;

        // Token: 0x040049F5 RID: 18933
        private static int int_11;

        // Token: 0x040049F6 RID: 18934
        private static int int_12;

        // Token: 0x040049F7 RID: 18935
        private static int int_13;

        // Token: 0x040049F8 RID: 18936
        private static int int_14;

        // Token: 0x040049F9 RID: 18937
        private static int int_15;

        // Token: 0x040049FA RID: 18938
        private static int int_16;

        // Token: 0x040049FB RID: 18939
        private static int int_17;

        // Token: 0x040049FC RID: 18940
        private static int int_18;

        // Token: 0x040049FD RID: 18941
        private static int int_19;

        // Token: 0x040049FE RID: 18942
        private static int int_20;

        // Token: 0x040049FF RID: 18943
        private static int int_21;

        // Token: 0x04004A00 RID: 18944
        private static int int_22;

        // Token: 0x04004A01 RID: 18945
        private static int int_23;

        // Token: 0x04004A02 RID: 18946
        private static int int_24;

        // Token: 0x04004A03 RID: 18947
        private static int int_25;

        // Token: 0x04004A04 RID: 18948
        private static int int_26;

        // Token: 0x04004A05 RID: 18949
        private static int int_27;

        // Token: 0x04004A06 RID: 18950
        private static int int_28;

        // Token: 0x04004A07 RID: 18951
        private static int int_29;
    }
}