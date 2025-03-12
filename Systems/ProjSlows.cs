using PetHaul.Systems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.ItemDropRules;
using Terraria.GameContent.Personalities;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using PetsOverhaul.Buffs;
using PetsOverhaul.Items;
using PetsOverhaul.Systems;
using Microsoft.Xna.Framework;
using Terraria.ModLoader.Config;
using PetsOverhaul.NPCs;
using PetHaul;

namespace PetHaul.Systems
{

    public sealed class SlowProj : GlobalProjectile
    {

        public struct PetSlow(float slowAmount, int slowTime, int slowId = PetSlowIDs.IndependentSlow)
        {
            public float SlowAmount = slowAmount;
            public int SlowTime = slowTime;
            public int SlowId = slowId;
        }

        public override bool InstancePerEntity => true;
        public List<PetSlow> SlowList = new();

        public float CurrentSlowAmount { get; internal set; }
        public bool electricSlow;
        public bool coldSlow;
        public bool sickSlow;

        public Vector2 FlyingVelo { get; internal set; }
        public float GroundVelo { get; internal set; }
        public bool VeloChangedFlying { get; internal set; }
        public bool VeloChangedFlying2 { get; internal set; }
        public bool VeloChangedGround { get; internal set; }
        public bool VeloChangedGround2 { get; internal set; }


        
        public override void Load()
        {
            PetHaul.BeforeProjectilePreAI += UpdateSlows;
        }

        public static void UpdateSlows(Projectile projectile)
        {
            if (projectile.active && projectile.TryGetGlobalProjectile(out SlowProj npcPet))
            {
                if (npcPet.VeloChangedGround == true)
                {
                  // projectile.velocity = npcPet.GroundVelo;

                    npcPet.VeloChangedGround2 = true;
                }
                else
                {
                    npcPet.VeloChangedGround2 = false;
                }

                if (npcPet.VeloChangedGround2 == false)
                {
                   // npcPet.GroundVelo = projectile.velocity;
                }

                if (npcPet.VeloChangedFlying == true)
                {
                    projectile.velocity = npcPet.FlyingVelo;

                    npcPet.VeloChangedFlying2 = true;
                }
                else
                {
                    npcPet.VeloChangedFlying2 = false;
                }

                if (npcPet.VeloChangedFlying2 == false)
                {
                    npcPet.FlyingVelo = projectile.velocity;
                }
            }
        }

        public override void PostAI(Projectile projectile)
        {
            if (projectile.active)
            {
                electricSlow = false;
                coldSlow = false;
                sickSlow = false;
                CurrentSlowAmount = 0;


                if (SlowList.Count > 0)
                {
                    foreach (var slow in SlowList)
                    {
                        CurrentSlowAmount += slow.SlowAmount;

                        if (PetSlowIDs.ElectricBasedSlows.Exists(x => x == slow.SlowId))
                        {
                            electricSlow = true;
                        }
                        if (PetSlowIDs.ColdBasedSlows.Exists(x => x == slow.SlowId))
                        {
                            coldSlow = true;
                        }
                        if (PetSlowIDs.SicknessBasedSlows.Exists(x => x == slow.SlowId))
                        {
                            sickSlow = true;
                        }
                    }
                    for (int i = 0; i < SlowList.Count; i++) //Since Structs in Lists acts as Readonly, we re-assign the values to the index to decrement the timer.
                    {
                        PetSlow slow = SlowList[i];
                        slow.SlowTime--;
                        SlowList[i] = slow;
                    }

                    SlowList.RemoveAll(x => x.SlowTime <= 0);
                }
                if (CurrentSlowAmount > 0)
                {
                    Slow(projectile, CurrentSlowAmount);
                }
            }
        }

        internal void Slow(Projectile projectile, float slow)
        {
            if (slow < -0.9f)
            {
                slow = -0.9f;
            }

            FlyingVelo = projectile.velocity;
           // GroundVelo = projectile.velocity;

            if (projectile.active)
            {
                projectile.velocity *= 1 / (1 + slow);
                VeloChangedGround = true;
            }
            

            if (projectile.active)
            {
                
                VeloChangedFlying = false;
            }
            


        }


        internal static void AddToSlowList(PetSlow slowToBeAdded, Projectile projectile)
        {
            if (projectile.active && (projectile.friendly == false) && projectile.TryGetGlobalProjectile(out SlowProj npcPet))
            {
                if (slowToBeAdded.SlowId <= -1)
                {
                    npcPet.SlowList.Add(slowToBeAdded);
                    return;
                }
                int indexToReplace;
                if (npcPet.SlowList.Exists(x => x.SlowId == slowToBeAdded.SlowId && x.SlowAmount < slowToBeAdded.SlowAmount))
                {
                    indexToReplace = npcPet.SlowList.FindIndex(x => x.SlowId == slowToBeAdded.SlowId && x.SlowAmount < slowToBeAdded.SlowAmount);
                    npcPet.SlowList[indexToReplace] = slowToBeAdded;
                }
                else if (npcPet.SlowList.Exists(x => x.SlowId == slowToBeAdded.SlowId && x.SlowAmount == slowToBeAdded.SlowAmount && x.SlowTime < slowToBeAdded.SlowTime))
                {
                    indexToReplace = npcPet.SlowList.FindIndex(x => x.SlowId == slowToBeAdded.SlowId && x.SlowAmount == slowToBeAdded.SlowAmount && x.SlowTime < slowToBeAdded.SlowTime);
                    npcPet.SlowList[indexToReplace] = slowToBeAdded;
                }
                else if (npcPet.SlowList.Exists(x => x.SlowId == slowToBeAdded.SlowId) == false)
                {
                    npcPet.SlowList.Add(slowToBeAdded);
                }
            }
        }

        public static void AddSlow(PetSlow petSlow, Projectile projectile)
        {
            if (Main.netMode == NetmodeID.MultiplayerClient)
            {
                int npcArrayId = Math.Clamp(projectile.whoAmI, byte.MinValue, byte.MaxValue);
                int slowId = Math.Clamp(petSlow.SlowId, sbyte.MinValue, sbyte.MaxValue);
                ModPacket packet = ModContent.GetInstance<PetHaul>().GetPacket();
                packet.Write((byte)MessageType.PetSlow);
                packet.Write((byte)npcArrayId);
                packet.Write(petSlow.SlowAmount);
                packet.Write(petSlow.SlowTime);
                packet.Write((sbyte)slowId);
                packet.Send();
            }
            if (Main.netMode == NetmodeID.SinglePlayer)
            {
                AddToSlowList(petSlow, projectile);
            }
        }

        public class PetSlowIDs
        {
            /// <summary>
            /// This type of slows creates Electricity dusts on enemy.
            /// </summary>
            public static List<int> ElectricBasedSlows = [VoltBunny, PhantasmalLightning];
            /// <summary>
            /// This type of slows creates ice water dusts on enemy.
            /// </summary>
            public static List<int> ColdBasedSlows = [Grinch, Snowman, Deerclops, IceQueen, PhantasmalIce];
            /// <summary>
            /// This type of slows creates 'poisoned' dusts on enemy.
            /// </summary>
            public static List<int> SicknessBasedSlows = [PrincessSlime, PrinceSlime];
            /// <summary>
            /// Slows with ID lower than 0 won't be overriden by itself by any means and can have multiples of the same ID this way. This value defaults to be PetSlowIDs.ColdBasedSlows[Type] == true.
            /// </summary>
            public const int IndependentSlow = -1;
            public const int Grinch = 0;
            public const int Snowman = 1;
            public const int PrincessSlime = 2;
            public const int Deerclops = 3;
            public const int IceQueen = 4;
            public const int VoltBunny = 5;
            public const int PhantasmalIce = 6;
            public const int PhantasmalLightning = 7;
            public const int PrinceSlime = 8;
        }
    }

}
