using CalamityMod.Dusts;
using PetsOverhaul.Config;
using PetsOverhaul.Systems;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using NoxusBoss.Content.Items.Pets;
using NoxusBoss.Core.CrossCompatibility.Inbound;
using NoxusBoss.Core.Graphics.RenderTargets;
using PetHaul.Systems;
using PetHaul.WOTGPets;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PetsOverhaul.NPCs;
using Terraria.ModLoader.IO;
using PetsOverhaul.Projectiles;
using Terraria.GameInput;
using Terraria.Utilities;
using Luminance.Common.Easings;
using Luminance.Common.Utilities;
using Luminance.Core.Graphics;

namespace PetHaul.WOTGPets
{
    public class DarkHoleEffect : PetEffect
    {
        public override int PetItemID => WOTGPetIDs.DarkHole;

        public override PetClasses PetClassPrimary => PetClasses.Utility;
        public override PetClasses PetClassSecondary => PetClasses.Offensive;

        public int oneRange = 800;
        public int twoRange = 400;
        public int threeRange = 200;
        public float oneSlow = 0.9f;
        public float twoSlow = 2.0f;
        public float threeSlow = 3.0f;
        public float onepSlow = 0.9f;
        public float twopSlow = 2.0f;
        public float threepSlow = 3.0f;

        public override void PostUpdateMiscEffects()
        {
            if (PetIsEquipped())
            {
                GlobalPet.CircularDustEffect(Player.Center, DustID.Snow, oneRange, 20);
                GlobalPet.CircularDustEffect(Player.Center, DustID.RedTorch, twoRange, 20);
                GlobalPet.CircularDustEffect(Player.Center, DustID.Shadowflame, threeRange, 20);

                foreach (var npc in Main.ActiveNPCs)
                {
                    if (Player.Distance(npc.Center) < oneRange && Player.Distance(npc.Center) > twoRange)
                    {
                        NpcPet.AddSlow(new NpcPet.PetSlow(oneSlow, 1, PetSlowIDs.Grinch), npc);
                    }
                    else if (Player.Distance(npc.Center) < twoRange && Player.Distance(npc.Center) > threeRange)
                    {
                        NpcPet.AddSlow(new NpcPet.PetSlow(twoSlow, 1, PetSlowIDs.PrinceSlime), npc);
                    }
                    else if (Player.Distance(npc.Center) < threeRange)
                    {
                        NpcPet.AddSlow(new NpcPet.PetSlow(threeSlow, 1, PetSlowIDs.IndependentSlow), npc);
                    }

                }

                foreach (var projectile in Main.ActiveProjectiles)
                {
                    if (Player.Distance(projectile.Center) < oneRange && Player.Distance(projectile.Center) > twoRange)
                    {
                        SlowProj.AddSlow(new SlowProj.PetSlow(onepSlow, 1, PetSlowIDs.Grinch), projectile);
                    }
                    else if (Player.Distance(projectile.Center) < twoRange && Player.Distance(projectile.Center) > threeRange)
                    {
                        SlowProj.AddSlow(new SlowProj.PetSlow(twopSlow, 1, PetSlowIDs.PrinceSlime), projectile);
                    }
                    else if (Player.Distance(projectile.Center) < threeRange)
                    {
                        SlowProj.AddSlow(new SlowProj.PetSlow(threepSlow, 1, PetSlowIDs.IndependentSlow), projectile);
                    }

                }




            }
        }
    }

   /* public sealed class SlowNPC : GlobalNPC
    {
        public override bool InstancePerEntity => true;
        

        
        public override bool PreAI(NPC npc)
        {
            //if (!npc.Active) return false;

            if (this.Owner.HasBuff(BlackHole.BuffID))
            {
                float remainderAfterThisPass = 2 - (float)this.go;
                if (remainderAfterThisPass < 1f && Utils.NextFloat(Main.rand) > remainderAfterThisPass)
                {
                    this.go--;
                    return true;
                }
                this.go++;
                npc.AI();
                float speedToAdd = 0.5f;
                Vector2 newPos = npc.position - npc.velocity * speedToAdd;
                if (npc.noTileCollide || !Collision.SolidCollision(newPos, npc.width, npc.height))
                {
                    npc.position = newPos;
                }

                return true;
            }
        }
        private int go = 1;
    }
   */
    public sealed class DarkHole : GlobalItem
    {
        public override bool AppliesToEntity(Item entity, bool lateInstantiation)
        {
            return entity.type == WOTGPetIDs.DarkHole;
        }


        /*
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            if (ModContent.GetInstance<PetPersonalization>().EnableTooltipToggle && !PetKeybinds.PetTooltipHide.Current)
            {
                return;
            }

            DarkHoleEffect darkholed = Main.LocalPlayer.GetModPlayer<DarkHoleEffect>();
            tooltips.Add(new(Mod, "Tooltip0", Language.GetTextValue("Mods.PetsOverhaul.PetItemTooltips.CompanionCube")
                        ));
        }
        */
    }
}
