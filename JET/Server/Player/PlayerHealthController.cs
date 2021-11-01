using EFT;
using EFT.InventoryLogic;
using UnityEngine;
using System.Collections.Generic;
using HealthEffect = GClass1440.GClass1444;

namespace JET.Server.Player
{
    public class PlayerHealthController : GClass1438
    {
        private bool isStarted = false;

        public PlayerHealthController(Profile.GClass1127 profileHealth, GClass1731 inventory, GClass1143 skills, bool aiHealth = false)
            : base(profileHealth, inventory, skills)
        {
            base.method_7<GClass1438.Existence>(EBodyPart.Head, null, null, null, null, null);
            //var inv = new GClass1731(PlayerProfile, IdGeneratorId, true);
            //var skills = new GClass1143(EPlayerSide.Bear);
            //HealthController = new PlayerHealthController(PlayerProfile.Health, inv, skills);          
        }

        public void Start()
        {
            if(this.isStarted)
            {
                return;
            }
            base.UpdateTime = GClass817.UtcNowUnixInt;
            this.isStarted = true;
        }

        public void InitHealthState()
        {
            //Health
            this.gclass1490_0 = new GClass1490(100.0f, 100.0f);
            //Hydratation
            this.gclass1490_1 = new GClass1490(100.0f, 100.0f);
            //Energy
            this.gclass1490_2 = new GClass1490(100.0f, 100.0f);
            //Healing rate
            this.float_6 = 0.0f;
            //Damage rate
            this.float_7 = 0.0f;
            this.DamageMultiplier = 0.0f;
            this.EnergyRate = 0.0f;
            this.HydrationRate = 0.0f;
            this.TemperatureRate = 0.0f;
            this.DamageCoeff = 0.0f;

            //if(this.dictionary_0 != null)
            //{
            //    this.dictionary_0.Clear();
            //}
            //else
            //{
            //    this.dictionary_0 = new Dictionary<EBodyPart, GClass1437<GClass1436>.BodyPartState>();
            //}

            //InitBodyPartHealth(EBodyPart.Head, 35.0f, 35.0f);
            //InitBodyPartHealth(EBodyPart.Chest, 85.0f, 85.0f);
            //InitBodyPartHealth(EBodyPart.Stomach, 70.0f, 70.0f);
            //InitBodyPartHealth(EBodyPart.RightArm, 100.0f, 100.0f);
            //InitBodyPartHealth(EBodyPart.LeftArm, 60.0f, 60.0f);
            //InitBodyPartHealth(EBodyPart.RightLeg, 65.0f, 65.0f);
            //InitBodyPartHealth(EBodyPart.LeftLeg, 65.0f, 65.0f);


            //Clear all health effects
            //this.list_0.Clear();
        }

        protected void InitBodyPartHealth(EBodyPart bodyPart, float cur, float max)
        {
            if(this.dictionary_0 != null)
            {
                if(this.dictionary_0.ContainsKey(bodyPart))
                {
                    this.dictionary_0.Remove(bodyPart);
                    var bps = new GClass1437<GClass1438.GClass1436>.BodyPartState();
                    bps.IsDestroyed = false;
                    bps.Health = new GClass1490(cur, max);
                    this.dictionary_0.Add(bodyPart, bps);                    
                }
            }
        }

        public override void ApplyItem(Item item, EBodyPart bodyPart, float? amount = null)
        {


            Debug.LogError("JET.Server.Player.PlayerHealthController.PlayerHealthController.ApplyItem: not implemented");
        }

        public override void CancelApplyingItem()
        {
            Debug.LogError("JET.Server.Player.PlayerHealthController.PlayerHealthController.CancelApplyingItem: not implemented");
        }

        protected override bool _sendNetworkSyncPackets => true;
    }
}