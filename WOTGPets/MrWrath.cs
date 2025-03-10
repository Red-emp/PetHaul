using CalamityMod.Dusts;
using PetsOverhaul.Config;
using PetsOverhaul.Systems;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using NoxusBoss.Content.Items.Pets;
using NoxusBoss.Core.CrossCompatibility.Inbound;
using PetHaul.Systems;
using PetHaul.WOTGPets;
using NoxusBoss.Content.NPCs.Bosses.NamelessDeity.SpecificEffectManagers;
using Terraria.GameInput;
using NoxusBoss.Content.Projectiles.Visuals;
using Microsoft.Xna.Framework;
using Terraria.GameInput;
using NoxusBoss.Core.BaseEntities;
using NoxusBoss.Content.Projectiles;

namespace PetHaul.WOTGPets
{

    public class MrWrathEffect : PetEffect
    {
        public override int PetItemID => WOTGPetIDs.MrWrath;

        public override PetClasses PetClassPrimary => PetClasses.Utility;
        public int damage = 350;
        public int cooldown = 20;
    


        // private int internalCooldownToInitiateAttack = 0;

        public override void PostUpdateMiscEffects()
        {
            if (Pet.PetInUseWithSwapCd(WOTGPetIDs.MrWrath))
            {
                //  Player.buffImmune[BuffID.Obstructed] = false;
                // Player.AddBuff(BuffID.Obstructed, 1);
                

                NamelessDeityDimensionSkyGenerator.InProximityOfMonolith = true;
                NamelessDeityDimensionSkyGenerator.TimeSinceCloseToMonolith = 5;
            }

            if (Pet.AbilityPressCheck() && PetIsEquipped())
            {
                
                Projectile petProjectile = Projectile.NewProjectileDirect(GlobalPet.GetSource_Pet(EntitySourcePetIDs.PetProjectile), Player.Center, new Vector2(Main.MouseWorld.X - Player.Center.X, Main.MouseWorld.Y - Player.Center.Y) * 0, ModContent.ProjectileType<GenesisOmegaDeathray>(), Pet.PetDamage(damage, DamageClass.Generic), 4f, Player.whoAmI);
                petProjectile.DamageType = DamageClass.Generic;
                petProjectile.CritChance = (int)Player.GetTotalCritChance(DamageClass.Generic);
                Pet.timer = Pet.timerMax;
                petProjectile.hostile = false; 
                petProjectile.friendly = true;
                

            }


        }

        

        public override int PetAbilityCooldown => cooldown;


        public sealed class MrWrathGuy : GlobalItem
        {
            public override bool AppliesToEntity(Item entity, bool lateInstantiation)
            {
                return entity.type == WOTGPetIDs.MrWrath;
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
}
