using System;
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
        public bool worldIsSpawned;
        public bool subWorldMessageIsSent;
        public bool playerSpawnIsSent;
        public bool gameSpawnedIsSent;
        public bool allPlayersSpawned;
        public bool gameStartingIsSent;
        public bool gameStartedIsSent;
        public bool playerIsSpawned;
        public bool sessionIsSpawned;

        public static T Create<T>(Transform parent, string name, string profileId, string token) where T : AbstractGameSession
        {
            var t = New<T>(parent, name, profileId, token);
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
        protected virtual void CmdSpawn()
        {
            Debug.LogError("JET.Server.SessionCall.AbstractGameSession: Call command CmdSpawn from client.");

            sessionIsSpawned = true;
        }

        // Token: 0x06004775 RID: 18293 RVA: 0x000A29D7 File Offset: 0x000A0BD7
        [Command]
        protected virtual void CmdRespawn()
        {
            Debug.LogError("JET.Server.SessionCall.AbstractGameSession: Call command CmdRespawn from client.");
        }

        // Token: 0x06004776 RID: 18294 RVA: 0x000A29D7 File Offset: 0x000A0BD7
        [Command]
        protected virtual void CmdStartGame()
        {
            Debug.LogError("JET.Server.SessionCall.AbstractGameSession: Call command CmdStartGame from client.");
        }

        // Token: 0x06004777 RID: 18295 RVA: 0x000A29D7 File Offset: 0x000A0BD7
        [Command]
        protected virtual void CmdStartGameAfterTeleport()
        {
            Debug.LogError("JET.Server.SessionCall.AbstractGameSession: Call command CmdStartGameAfterTeleport from client.");
        }

        // Token: 0x06004778 RID: 18296 RVA: 0x000A29D7 File Offset: 0x000A0BD7
        [Command]
        protected virtual void CmdRestartGameInitiate()
        {
            Debug.LogError("JET.Server.SessionCall.AbstractGameSession: Call command CmdRestartGameInitiate from client.");
        }

        // Token: 0x06004779 RID: 18297 RVA: 0x000A29D7 File Offset: 0x000A0BD7
        [Command]
        protected virtual void CmdRestartGame()
        {
            Debug.LogError("JET.Server.SessionCall.AbstractGameSession: Call command CmdRestartGame from client.");
        }

        // Token: 0x0600477A RID: 18298 RVA: 0x000A29D7 File Offset: 0x000A0BD7
        [Command]
        protected virtual void CmdGameStarted()
        {
            Debug.LogError("JET.Server.SessionCall.AbstractGameSession: Call command CmdGameStarted from client.");
            RpcSyncGameTime(GClass817.UtcNow.ToBinary());
        }

        // Token: 0x0600477B RID: 18299 RVA: 0x000A29D7 File Offset: 0x000A0BD7
        [Command]
        protected virtual void CmdStopGame()
        {
            Debug.LogError("JET.Server.SessionCall.AbstractGameSession: Call command CmdStopGame from client.");
        }

        // Token: 0x0600477C RID: 18300 RVA: 0x000A29D7 File Offset: 0x000A0BD7
        [Command]
        protected virtual void CmdSyncGameTime()
        {
            Debug.LogError("JET.Server.SessionCall.AbstractGameSession: Call command CmdSyncGameTime from client.");
            
            RpcSyncGameTime(GClass817.UtcNow.ToBinary());
            gameSyncTimeIsSent = true;
        }

        // Token: 0x0600477D RID: 18301 RVA: 0x000A29D7 File Offset: 0x000A0BD7
        [Command]
        protected virtual void CmdDevelopRequestBot()
        {
            Debug.LogError("JET.Server.SessionCall.AbstractGameSession: Call command CmdDevelopRequestBot from client.");
        }

        // Token: 0x0600477E RID: 18302 RVA: 0x000A29D7 File Offset: 0x000A0BD7
        [Command]
        protected virtual void CmdDevelopmentSpawnBotRequest(EPlayerSide side)
        {
            Debug.LogError("JET.Server.SessionCall.AbstractGameSession: Call command CmdDevelopmentSpawnBotRequest from client.");
        }

        // Token: 0x0600477F RID: 18303 RVA: 0x000A29D7 File Offset: 0x000A0BD7
        [Command]
        protected virtual void CmdDevelopmentSpawnBotOnServer(EPlayerSide side)
        {
            Debug.LogError("JET.Server.SessionCall.AbstractGameSession: Call command CmdDevelopmentSpawnBotOnServer from client.");
        }

        // Token: 0x06004780 RID: 18304 RVA: 0x000A29D7 File Offset: 0x000A0BD7
        [Command]
        protected virtual void CmdDevelopmentSpawnBotOnClient(EPlayerSide side, int instanceId)
        {
            Debug.LogError("JET.Server.SessionCall.AbstractGameSession: Call command CmdDevelopmentSpawnBotOnClient from client.");
        }

        // Token: 0x06004781 RID: 18305 RVA: 0x000A29D7 File Offset: 0x000A0BD7
        [Command]
        protected virtual void CmdDisconnectAcceptedOnClient()
        {
            Debug.LogError("JET.Server.SessionCall.AbstractGameSession: Call command CmdDisconnectAcceptedOnClient from client.");
        }

        // Token: 0x06004782 RID: 18306 RVA: 0x000A29D7 File Offset: 0x000A0BD7
        [Command]
        protected virtual void CmdWorldSpawnConfirm()
        {
            Debug.LogError("JET.Server.SessionCall.AbstractGameSession: Call command CmdWorldSpawnConfirm from client.");
            worldIsSpawned = true;
        }

        // Token: 0x06004783 RID: 18307 RVA: 0x000A29D7 File Offset: 0x000A0BD7
        [Command]
        protected virtual void CmdSpawnConfirm(int playerId)
        {
            Debug.LogError("JET.Server.SessionCall.AbstractGameSession: Call command CmdSpawnConfirm from client.");
        }

        // Token: 0x060047C2 RID: 18370 RVA: 0x0024C6C8 File Offset: 0x0024A8C8
        public void RpcGameSpawned()
        {
            NetworkWriter networkWriter = new NetworkWriter();
            networkWriter.Write((byte) 0);
            networkWriter.Write((byte) 0);
            networkWriter.Write((byte) 2);
            networkWriter.Write((byte) 0);
            networkWriter.WritePackedUInt32((uint) ID_CallRpcGameSpawned);
            networkWriter.Write(GetComponent<NetworkIdentity>().netId);
            SendRPCInternal(networkWriter, 0, "RpcGameSpawned");
        }

        // Token: 0x060047C3 RID: 18371 RVA: 0x0024C724 File Offset: 0x0024A924
        public void RpcGameMatching(ushort activitiesCounter, ushort minCounter, int seconds)
        {
            NetworkWriter networkWriter = new NetworkWriter();
            networkWriter.Write((byte) 0);
            networkWriter.Write((byte) 0);
            networkWriter.Write((byte) 2);
            networkWriter.Write((byte) 0);
            networkWriter.WritePackedUInt32((uint) ID_CallRpcGameMatching);
            networkWriter.Write(GetComponent<NetworkIdentity>().netId);
            networkWriter.WritePackedUInt32(activitiesCounter);
            networkWriter.WritePackedUInt32(minCounter);
            networkWriter.WritePackedUInt32((uint) seconds);
            SendRPCInternal(networkWriter, 0, "RpcGameMatching");
        }

        // Token: 0x060047C4 RID: 18372 RVA: 0x0024C798 File Offset: 0x0024A998
        public void RpcGameStarting(int seconds)
        {
            NetworkWriter networkWriter = new NetworkWriter();
            networkWriter.Write((byte) 0);
            networkWriter.Write((byte) 0);
            networkWriter.Write((byte) 2);
            networkWriter.Write((byte) 0);
            networkWriter.WritePackedUInt32((uint) ID_CallRpcGameStarting);
            networkWriter.Write(GetComponent<NetworkIdentity>().netId);
            networkWriter.WritePackedUInt32((uint) seconds);
            SendRPCInternal(networkWriter, 0, "RpcGameStarting");
        }

        // Token: 0x060047C5 RID: 18373 RVA: 0x0024C7FC File Offset: 0x0024A9FC
        public void RpcGameStartingWithTeleport(Vector3 position, int exfiltrationId, string entryPoint)
        {
            NetworkWriter networkWriter = new NetworkWriter();
            networkWriter.Write((byte) 0);
            networkWriter.Write((byte) 0);
            networkWriter.Write((byte) 2);
            networkWriter.Write((byte) 0);
            networkWriter.WritePackedUInt32((uint) ID_CallRpcGameStartingWithTeleport);
            networkWriter.Write(GetComponent<NetworkIdentity>().netId);
            networkWriter.Write(position);
            networkWriter.WritePackedUInt32((uint) exfiltrationId);
            networkWriter.Write(entryPoint);
            SendRPCInternal(networkWriter, 0, "RpcGameStartingWithTeleport");
        }

        // Token: 0x060047C6 RID: 18374 RVA: 0x0024C870 File Offset: 0x0024AA70
        public void RpcGameStarted(float pastTime, int escapeSeconds)
        {
            NetworkWriter networkWriter = new NetworkWriter();
            networkWriter.Write((byte) 0);
            networkWriter.Write((byte) 0);
            networkWriter.Write((byte) 2);
            networkWriter.Write((byte) 0);
            networkWriter.WritePackedUInt32((uint) ID_CallRpcGameStarted);
            networkWriter.Write(GetComponent<NetworkIdentity>().netId);
            networkWriter.Write(pastTime);
            networkWriter.WritePackedUInt32((uint) escapeSeconds);
            SendRPCInternal(networkWriter, 0, "RpcGameStarted");
        }

        // Token: 0x060047C7 RID: 18375 RVA: 0x0024C8DC File Offset: 0x0024AADC
        public void RpcGameRestarting()
        {
            NetworkWriter networkWriter = new NetworkWriter();
            networkWriter.Write((byte) 0);
            networkWriter.Write((byte) 0);
            networkWriter.Write((byte) 2);
            networkWriter.Write((byte) 0);
            networkWriter.WritePackedUInt32((uint) ID_CallRpcGameRestarting);
            networkWriter.Write(GetComponent<NetworkIdentity>().netId);
            SendRPCInternal(networkWriter, 0, "RpcGameRestarting");
        }

        // Token: 0x060047C8 RID: 18376 RVA: 0x0024C938 File Offset: 0x0024AB38
        public void RpcGameRestarted()
        {
            NetworkWriter networkWriter = new NetworkWriter();
            networkWriter.Write((byte) 0);
            networkWriter.Write((byte) 0);
            networkWriter.Write((byte) 2);
            networkWriter.Write((byte) 0);
            networkWriter.WritePackedUInt32((uint) ID_CallRpcGameRestarted);
            networkWriter.Write(GetComponent<NetworkIdentity>().netId);
            SendRPCInternal(networkWriter, 0, "RpcGameRestarted");
        }

        // Token: 0x060047C9 RID: 18377 RVA: 0x0024C994 File Offset: 0x0024AB94
        public void RpcGameStopping()
        {
            NetworkWriter networkWriter = new NetworkWriter();
            networkWriter.Write((byte) 0);
            networkWriter.Write((byte) 0);
            networkWriter.Write((byte) 2);
            networkWriter.Write((byte) 0);
            networkWriter.WritePackedUInt32((uint) ID_CallRpcGameStopping);
            networkWriter.Write(GetComponent<NetworkIdentity>().netId);
            SendRPCInternal(networkWriter, 0, "RpcGameStopping");
        }

        // Token: 0x060047CA RID: 18378 RVA: 0x0024C9F0 File Offset: 0x0024ABF0
        public void RpcGameStopped(ExitStatus exitStatus, int playTime)
        {
            NetworkWriter networkWriter = new NetworkWriter();
            networkWriter.Write((byte) 0);
            networkWriter.Write((byte) 0);
            networkWriter.Write((byte) 2);
            networkWriter.Write((byte) 0);
            networkWriter.WritePackedUInt32((uint) ID_CallRpcGameStopped);
            networkWriter.Write(GetComponent<NetworkIdentity>().netId);
            networkWriter.Write((int) exitStatus);
            networkWriter.WritePackedUInt32((uint) playTime);
            SendRPCInternal(networkWriter, 0, "RpcGameStopped");
        }

        // Token: 0x060047CB RID: 18379 RVA: 0x0024CA5C File Offset: 0x0024AC5C
        public void RpcSyncGameTime(long time)
        {
            NetworkWriter networkWriter = new NetworkWriter();
            networkWriter.Write((byte) 0);
            networkWriter.Write((byte) 0);
            networkWriter.Write((byte) 2);
            networkWriter.Write((byte) 0);
            networkWriter.WritePackedUInt32((uint) ID_CallRpcSyncGameTime);
            networkWriter.Write(GetComponent<NetworkIdentity>().netId);
            networkWriter.WritePackedUInt64((ulong) time);
            SendRPCInternal(networkWriter, 0, "RpcSyncGameTime");
        }

        // Token: 0x060047CC RID: 18380 RVA: 0x0024CAC0 File Offset: 0x0024ACC0
        public void RpcDevelopSendBotData(byte[] data)
        {
            NetworkWriter networkWriter = new NetworkWriter();
            networkWriter.Write((byte) 0);
            networkWriter.Write((byte) 0);
            networkWriter.Write((byte) 2);
            networkWriter.Write((byte) 0);
            networkWriter.WritePackedUInt32((uint) ID_CallRpcDevelopSendBotData);
            networkWriter.Write(GetComponent<NetworkIdentity>().netId);
            networkWriter.WriteBytesFull(data);
            SendRPCInternal(networkWriter, 0, "RpcDevelopSendBotData");
        }

        // Token: 0x060047CD RID: 18381 RVA: 0x0024CB24 File Offset: 0x0024AD24
        public void RpcDevelopmentSpawnBotResponse(EPlayerSide side, int instanceId)
        {
            NetworkWriter networkWriter = new NetworkWriter();
            networkWriter.Write((byte) 0);
            networkWriter.Write((byte) 0);
            networkWriter.Write((byte) 2);
            networkWriter.Write((byte) 0);
            networkWriter.WritePackedUInt32((uint) ID_CallRpcDevelopmentSpawnBotResponse);
            networkWriter.Write(GetComponent<NetworkIdentity>().netId);
            networkWriter.Write((int) side);
            networkWriter.WritePackedUInt32((uint) instanceId);
            SendRPCInternal(networkWriter, 0, "RpcDevelopmentSpawnBotResponse");
        }

        // Token: 0x060047CE RID: 18382 RVA: 0x0024CB90 File Offset: 0x0024AD90
        public void RpcSoftStopNotification(int escapeSeconds)
        {
            NetworkWriter networkWriter = new NetworkWriter();
            networkWriter.Write((byte) 0);
            networkWriter.Write((byte) 0);
            networkWriter.Write((byte) 2);
            networkWriter.Write((byte) 0);
            networkWriter.WritePackedUInt32((uint) ID_CallRpcSoftStopNotification);
            networkWriter.Write(GetComponent<NetworkIdentity>().netId);
            networkWriter.WritePackedUInt32((uint) escapeSeconds);
            SendRPCInternal(networkWriter, 0, "RpcSoftStopNotification");
        }

        // Token: 0x060047CF RID: 18383 RVA: 0x0024CBF4 File Offset: 0x0024ADF4
        public void RpcStartDisconnectionProcedure(int disconnectionCode, string additionalInfo, string technicalMessage)
        {
            NetworkWriter networkWriter = new NetworkWriter();
            networkWriter.Write((byte) 0);
            networkWriter.Write((byte) 0);
            networkWriter.Write((byte) 2);
            networkWriter.Write((byte) 0);
            networkWriter.WritePackedUInt32((uint) ID_CallRpcStartDisconnectionProcedure);
            networkWriter.Write(GetComponent<NetworkIdentity>().netId);
            networkWriter.WritePackedUInt32((uint) disconnectionCode);
            networkWriter.Write(additionalInfo);
            networkWriter.Write(technicalMessage);
            SendRPCInternal(networkWriter, 0, "RpcStartDisconnectionProcedure");
        }

        // Token: 0x060047D0 RID: 18384 RVA: 0x0024CC68 File Offset: 0x0024AE68
        static AbstractGameSession()
        {
            RegisterCommandDelegate(typeof(AbstractGameSession), ID_CmdSpawn, /*CmdSpawn*/(behaviour, reader) => ((AbstractGameSession) behaviour).CmdSpawn());
            RegisterCommandDelegate(typeof(AbstractGameSession), ID_CmdRespawn, /*CmdRespawn*/(behaviour, reader) => ((AbstractGameSession) behaviour).CmdRespawn());
            RegisterCommandDelegate(typeof(AbstractGameSession), ID_CmdStartGame, /*CmdStartGame*/(behaviour, reader) => ((AbstractGameSession) behaviour).CmdStartGame());
            RegisterCommandDelegate(typeof(AbstractGameSession), ID_CmdStartGameAfterTeleport, /*CmdStartGameAfterTeleport*/(behaviour, reader) => ((AbstractGameSession) behaviour).CmdStartGameAfterTeleport());
            RegisterCommandDelegate(typeof(AbstractGameSession), ID_CmdRestartGameInitiate, /*CmdRestartGameInitiate*/(behaviour, reader) => ((AbstractGameSession) behaviour).CmdRestartGameInitiate());
            RegisterCommandDelegate(typeof(AbstractGameSession), ID_CmdRestartGame, /*CmdRestartGame*/(behaviour, reader) => ((AbstractGameSession) behaviour).CmdRestartGame());
            RegisterCommandDelegate(typeof(AbstractGameSession), ID_CmdGameStarted, /*CmdGameStarted*/(behaviour, reader) => ((AbstractGameSession) behaviour).CmdGameStarted());
            RegisterCommandDelegate(typeof(AbstractGameSession), ID_CmdStopGame, /*CmdStopGame*/(behaviour, reader) =>((AbstractGameSession) behaviour).CmdStopGame());
            RegisterCommandDelegate(typeof(AbstractGameSession), ID_CmdSyncGameTime, /*CmdSyncGameTime*/(behaviour, reader) => ((AbstractGameSession) behaviour).CmdSyncGameTime());
            RegisterCommandDelegate(typeof(AbstractGameSession), ID_CmdDevelopRequestBot, /*CmdDevelopRequestBot*/(behaviour, reader) => ((AbstractGameSession) behaviour).CmdDevelopRequestBot());
            RegisterCommandDelegate(typeof(AbstractGameSession), ID_CmdDevelopmentSpawnBotRequest, /*CmdDevelopmentSpawnBotRequest*/(behaviour, reader) => ((AbstractGameSession) behaviour).CmdDevelopmentSpawnBotRequest((EPlayerSide) reader.ReadInt32()));
            RegisterCommandDelegate(typeof(AbstractGameSession), ID_CmdDevelopmentSpawnBotOnServer, /*CmdDevelopmentSpawnBotOnServer*/(behaviour, reader) => ((AbstractGameSession) behaviour).CmdDevelopmentSpawnBotOnServer((EPlayerSide) reader.ReadInt32()));
            RegisterCommandDelegate(typeof(AbstractGameSession), ID_CmdDevelopmentSpawnBotOnClient, /*CmdDevelopmentSpawnBotOnClient*/(behaviour, reader) => ((AbstractGameSession) behaviour).CmdDevelopmentSpawnBotOnClient((EPlayerSide) reader.ReadInt32(), (int) reader.ReadPackedUInt32()));
            RegisterCommandDelegate(typeof(AbstractGameSession), ID_CmdDisconnectAcceptedOnClient, /*CmdDisconnectAcceptedOnClient*/(behaviour, reader) => ((AbstractGameSession) behaviour).CmdDisconnectAcceptedOnClient());
            RegisterCommandDelegate(typeof(AbstractGameSession), ID_CmdWorldSpawnConfirm, /*CmdWorldSpawnConfirm*/(behaviour, reader) => ((AbstractGameSession) behaviour).CmdWorldSpawnConfirm());
            RegisterCommandDelegate(typeof(AbstractGameSession), ID_CmdSpawnConfirm, /*CmdSpawnConfirm*/(behaviour, reader) => ((AbstractGameSession) behaviour).CmdSpawnConfirm((int) reader.ReadPackedUInt32()));
            RegisterRpcDelegate(typeof(AbstractGameSession), ID_CallRpcGameSpawned, /*CallRpcGameSpawned*/(behaviour, reader) => {Debug.LogError("JET.Server.SessionCall.AbstractGameSession: CallRpcGameSpawned");});
            RegisterRpcDelegate(typeof(AbstractGameSession), ID_CallRpcGameMatching, /*CallRpcGameMatching*/(behaviour, reader) => {Debug.LogError("JET.Server.SessionCall.AbstractGameSession: CallRpcGameMatching");});
            RegisterRpcDelegate(typeof(AbstractGameSession), ID_CallRpcGameStarting, /*CallRpcGameStarting*/(behaviour, reader) => {Debug.LogError("JET.Server.SessionCall.AbstractGameSession: CallRpcGameStarting");});
            RegisterRpcDelegate(typeof(AbstractGameSession), ID_CallRpcGameStartingWithTeleport, /*CallRpcGameStartingWithTeleport*/(behaviour, reader) => {Debug.LogError("JET.Server.SessionCall.AbstractGameSession: CallRpcGameStartingWithTeleport");});
            RegisterRpcDelegate(typeof(AbstractGameSession), ID_CallRpcGameStarted, /*CallRpcGameStarted*/(behaviour, reader) => {Debug.LogError("JET.Server.SessionCall.AbstractGameSession: CallRpcGameStarted");});
            RegisterRpcDelegate(typeof(AbstractGameSession), ID_CallRpcGameRestarting, /*CallRpcGameRestarting*/(behaviour, reader) => {Debug.LogError("JET.Server.SessionCall.AbstractGameSession: CallRpcGameRestarting");});
            RegisterRpcDelegate(typeof(AbstractGameSession), ID_CallRpcGameRestarted, /*CallRpcGameRestarted*/(behaviour, reader) => {Debug.LogError("JET.Server.SessionCall.AbstractGameSession: CallRpcGameRestarted");});
            RegisterRpcDelegate(typeof(AbstractGameSession), ID_CallRpcGameStopping, /*CallRpcGameStopping*/(behaviour, reader) => {Debug.LogError("JET.Server.SessionCall.AbstractGameSession: CallRpcGameStopping");});
            RegisterRpcDelegate(typeof(AbstractGameSession), ID_CallRpcGameStopped, /*CallRpcGameStopped*/(behaviour, reader) => {Debug.LogError("JET.Server.SessionCall.AbstractGameSession: CallRpcGameStopped");});
            RegisterRpcDelegate(typeof(AbstractGameSession), ID_CallRpcSyncGameTime, /*CallRpcSyncGameTime*/(behaviour, reader) => {Debug.LogError("JET.Server.SessionCall.AbstractGameSession: CallRpcSyncGameTime");});
            RegisterRpcDelegate(typeof(AbstractGameSession), ID_CallRpcDevelopSendBotData, /*CallRpcDevelopSendBotData*/(behaviour, reader) => {Debug.LogError("JET.Server.SessionCall.AbstractGameSession: CallRpcDevelopSendBotData");});
            RegisterRpcDelegate(typeof(AbstractGameSession), ID_CallRpcDevelopmentSpawnBotResponse, /*CallRpcDevelopmentSpawnBotResponse*/(behaviour, reader) => {Debug.LogError("JET.Server.SessionCall.AbstractGameSession: CallRpcDevelopmentSpawnBotResponse");});
            RegisterRpcDelegate(typeof(AbstractGameSession), ID_CallRpcSoftStopNotification, /*CallRpcSoftStopNotification*/(behaviour, reader) => {Debug.LogError("JET.Server.SessionCall.AbstractGameSession: CallRpcSoftStopNotification");});
            RegisterRpcDelegate(typeof(AbstractGameSession), ID_CallRpcStartDisconnectionProcedure, /*CallRpcStartDisconnectionProcedure*/(behaviour, reader) => {Debug.LogError("JET.Server.SessionCall.AbstractGameSession: CallRpcStartDisconnectionProcedure");});
            NetworkCRC.RegisterBehaviour("AbstractGameSession", 0);
        }

        private static readonly int ID_CmdSpawn = -1723132743;

        // Token: 0x040049EB RID: 18923
        private static int ID_CmdRespawn = 740792038;

        // Token: 0x040049EC RID: 18924
        private static int ID_CmdStartGame = -1220356686;

        // Token: 0x040049ED RID: 18925
        private static int ID_CmdStartGameAfterTeleport = 1792897173;

        // Token: 0x040049EE RID: 18926
        private static int ID_CmdRestartGameInitiate = 273195288;

        // Token: 0x040049EF RID: 18927
        private static int ID_CmdRestartGame = -1501005473;

        // Token: 0x040049F0 RID: 18928
        private static int ID_CmdGameStarted = -40021267;

        // Token: 0x040049F1 RID: 18929
        private static int ID_CmdStopGame = -750099178;

        // Token: 0x040049F2 RID: 18930
        private static int ID_CmdSyncGameTime = 463608476;

        // Token: 0x040049F3 RID: 18931
        private static int ID_CmdDevelopRequestBot = -1035840717;

        // Token: 0x040049F4 RID: 18932
        private static int ID_CmdDevelopmentSpawnBotRequest = -1581543574;

        // Token: 0x040049F5 RID: 18933
        private static int ID_CmdDevelopmentSpawnBotOnServer = 102630535;

        // Token: 0x040049F6 RID: 18934
        private static int ID_CmdDevelopmentSpawnBotOnClient = -349255409;

        // Token: 0x040049F7 RID: 18935
        private static int ID_CmdDisconnectAcceptedOnClient = -1733636721;

        // Token: 0x040049F8 RID: 18936
        private static int ID_CmdWorldSpawnConfirm = 1240699829;

        // Token: 0x040049F9 RID: 18937
        private static int ID_CmdSpawnConfirm = -1317447737;

        // Token: 0x040049FA RID: 18938
        private static int ID_CallRpcGameSpawned = -1952818640;

        // Token: 0x040049FB RID: 18939
        private static int ID_CallRpcGameMatching = 2117859815;

        // Token: 0x040049FC RID: 18940
        private static int ID_CallRpcGameStarting = -1157222870;

        // Token: 0x040049FD RID: 18941
        private static int ID_CallRpcGameStartingWithTeleport = 1572370779;

        // Token: 0x040049FE RID: 18942
        private static int ID_CallRpcGameStarted = -1838445225;

        // Token: 0x040049FF RID: 18943
        private static int ID_CallRpcGameRestarting = 94275293;

        // Token: 0x04004A00 RID: 18944
        private static int ID_CallRpcGameRestarted = -1243884988;

        // Token: 0x04004A01 RID: 18945
        private static int ID_CallRpcGameStopping = -758380962;

        // Token: 0x04004A02 RID: 18946
        private static int ID_CallRpcGameStopped = -1825579357;

        // Token: 0x04004A03 RID: 18947
        private static int ID_CallRpcSyncGameTime = 547040626;

        // Token: 0x04004A04 RID: 18948
        private static int ID_CallRpcDevelopSendBotData = 1152897188;

        // Token: 0x04004A05 RID: 18949
        private static int ID_CallRpcDevelopmentSpawnBotResponse = -1269941968;

        // Token: 0x04004A06 RID: 18950
        private static int ID_CallRpcSoftStopNotification = -435294673;

        // Token: 0x04004A07 RID: 18951
        private static int ID_CallRpcStartDisconnectionProcedure = 1124901489;
    }
}