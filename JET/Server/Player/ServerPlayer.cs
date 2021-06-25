using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Comfort.Common;
using EFT;
using JET.Server.Session;
using JET.Utilities.Reflection;
using UnityEngine;

namespace JET.Server.Player
{
    public class ServerPlayer : ObservedPlayer
    {
        public GStruct143 CurrentPacket = new GStruct143();
        public PlayerSession Session;
        public override byte ChannelIndex => channelIndex;
        public byte channelIndex;
        public GClass1731 InventoryController => _inventoryController;

        public static ServerPlayer Create(int playerId, Vector3 position, GInterface62 frameIndexer)
        {
            var createPlayerInfo = PrivateMethodAccessor.GetPrivateStaticGenericMethodByType<ServerPlayer>(typeof(NetworkPlayer), "smethod_2");
            if (createPlayerInfo == null)
            {
                Console.WriteLine(
                    "JET.Server.Player.ServerPlayer.Create: ERROR!!! createPlayerInfo is null\n");
                return null;
            }

            try
            {
                var player = createPlayerInfo.Invoke(null, new object[]
                {
                    GClass855.PLAYER_BUNDLE_NAME,
                    playerId, position,
                    "Observed_",
                    frameIndexer,
                    EUpdateQueue.Update, EUpdateMode.Manual, EUpdateMode.Auto,
                    GClass333.Config.CharacterController.ObservedPlayerMode,
                    new Func<float>(GetFloat), new Func<float>(GetFloat), true
                }) as ServerPlayer;

                if (player == null)
                    return player;

                player._triggerColliderOnEnterInfo = PrivateMethodAccessor.GetPrivateMethodByType(typeof(ObservedPlayer), "method_109");
                player._triggerColliderOnExitInfo = PrivateMethodAccessor.GetPrivateMethodByType(typeof(ObservedPlayer), "method_110");

                if (player._triggerColliderSearcher != null)
                {
                    player._triggerColliderSearcher.OnEnter += player.ColliderSearcherOnEnter;
                    player._triggerColliderSearcher.OnExit += player.ColliderSearcherOnExit;
                }

                player.EnabledAnimators = 0;
                player._armsUpdateQueue = EUpdateQueue.FixedUpdate;

                //player.ginterface104_0 = new GClass1237(player);
                PrivateValueAccessor
                    .SetPrivateFieldValue(typeof(ObservedPlayer), "ginterface104_0", player, new GClass1237(player));

                //observedPlayer.method_92();
                PrivateMethodAccessor.GetPrivateMethodInfo(player, "method_92").Invoke(player, new object[] { });

                return player;
            }
            catch (Exception e)
            {
                Console.WriteLine(
                    "JET.Server.Player.ServerPlayer.Create: error occurred while creating player instance!!!");
                Console.WriteLine(e);
            }

            return null;
        }

        public async Task Init(Profile profile)
        {
            //this.gclass680_0 = new GClass680(2000);
            PrivateValueAccessor.SetPrivateFieldValue(typeof(ObservedPlayer), "gclass680_0", this, new GClass680(1));

            await Singleton<GClass1168>.Instance.LoadBundlesAndCreatePools(
                GClass1168.PoolsCategory.Raid, GClass1168.AssemblyType.Local, profile.GetAllPrefabPaths().ToArray(), GClass2146.General
            );

            await Init(Quaternion.identity, "Player", EPointOfView.ThirdPerson, profile,
                new Player.PlayerInventoryController(this, profile, 0),
                new PlayerHealthController(profile.Health, this._inventoryController, profile.Skills),
                new StatisticsManager(), null, new GClass909()
            );

            foreach (GClass1663 magazine in profile.Inventory.NonQuestItems.OfType<GClass1663>())
            {
                _inventoryController.StrictCheckMagazine(magazine, true, profile.MagDrillsMastering, false, false);
            }

            AIData = new GClass271(null, this);
            PlacingBeacon = false;
            AggressorFound = false;
            _animators[0].enabled = true;

            if (GClass333.Config.UseSpiritPlayer)
            {
                Spirit.ConnectToPlayerEvents();
            }

            _handsController = EmptyHandsController.smethod_5<ObservedEmptyHandsController>(this);
            _handsController.Spawn(1f, () => { });

            Location = Singleton<ServerInstance>.Instance.LootSettings._Id;
        }

        public override GClass423 CreatePhysical()
        {
            return new GClass423
            {
                EncumberDisabled = _healthController.IsAlive
            };
        }

        public override void ManualUpdate(float deltaTime, int loop = 1)
        {
            LastDeltaTime = deltaTime;
            if (Mathf.Approximately(deltaTime, 0f))
            {
                Console.WriteLine("[ServerPlayer.ManualUpdate] deltaTime = {0}", deltaTime);
                return;
            }

            _healthController?.ManualUpdate(deltaTime);

            base.ManualUpdate(deltaTime, loop);
        }

        // private methods, fields, reflections
        private MethodInfo _triggerColliderOnEnterInfo;
        private MethodInfo _triggerColliderOnExitInfo;

        private void ColliderSearcherOnEnter(GInterface17 trigger)
        {
            try
            {
                _triggerColliderOnEnterInfo.Invoke(this, new object[] {trigger});
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private void ColliderSearcherOnExit(GInterface17 trigger)
        {
            try
            {
                _triggerColliderOnExitInfo.Invoke(this, new object[] {trigger});
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private static float GetFloat()
        {
            return 1f;
        }
    }
}