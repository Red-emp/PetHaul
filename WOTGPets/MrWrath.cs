using CalamityMod.Dusts;
using PetsOverhaul.Config;
using PetsOverhaul.Systems;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.Audio;
using Terraria.Localization;
using Terraria.ModLoader;
using PetHaul.Systems;
using PetHaul.WOTGPets;
using NoxusBoss.Content.NPCs.Bosses.NamelessDeity.SpecificEffectManagers;
using Microsoft.Xna.Framework;
using NoxusBoss.Content.Projectiles;
using PetsOverhaul.PetEffects;
using CalamityMod;
using NoxusBoss.Content.NPCs.Bosses.NamelessDeity.Projectiles;
using NoxusBoss.Content.NPCs.Bosses.NamelessDeity;
using NoxusBoss.Core.AdvancedProjectileOwnership;



namespace PetHaul.WOTGPets
{

    public class MrWrathEffect : PetEffect
    {
        public override int PetItemID => WOTGPetIDs.MrWrath;

        public override PetClasses PetClassPrimary => PetClasses.Offensive;
        public int damage = 1700;
        public int cooldown = 100;

       

        public override void PostUpdateMiscEffects()
        {
            if (Pet.PetInUseWithSwapCd(WOTGPetIDs.MrWrath))
            {          
                NamelessDeityDimensionSkyGenerator.InProximityOfMonolith = true;
                NamelessDeityDimensionSkyGenerator.TimeSinceCloseToMonolith = 5;
            }


            if (Pet.AbilityPressCheck() && PetIsEquipped())
            {
                 SoundEngine.PlaySound(new SoundStyle("NoxusBoss/Assets/Sounds/Custom/Genesis/GenesisFire"));
                 Projectile petProjectile = Projectile.NewProjectileDirect(GlobalPet.GetSource_Pet(EntitySourcePetIDs.PetProjectile), Player.Center, new Vector2(Main.MouseWorld.X, Main.MouseWorld.Y) * 0, ModContent.ProjectileType<GenesisOmegaDeathray>(), Pet.PetDamage(damage, DamageClass.Generic), 0f, Player.whoAmI);
                 petProjectile.DamageType = DamageClass.Generic;
                 petProjectile.CritChance = (int)Player.GetTotalCritChance(DamageClass.Generic);
                 Pet.timer = Pet.timerMax;
                 petProjectile.hostile = false; 
                 petProjectile.friendly = true;
                 petProjectile.ExpandHitboxBy(600,0);
                 petProjectile.height = 4000;
                 petProjectile.localNPCHitCooldown = 1;
                 petProjectile.usesLocalNPCImmunity = true;
                 petProjectile.ResetLocalNPCHitImmunity();
                
                
                
            }
            

        }

        public override int PetAbilityCooldown => cooldown;


        public sealed class Erilucyxwyn : PetTooltip
        {
            public override PetEffect PetsEffect => mrWrath;

            public static MrWrathEffect mrWrath
            {
                get
                {
                    if (Main.LocalPlayer.TryGetModPlayer(out MrWrathEffect pet))
                        return pet;
                    else
                        return ModContent.GetInstance<MrWrathEffect>();
                }
            }

            public override string PetsTooltip => Language.GetTextValue("Mods.PetHaul.PetTooltips.Erilucyxwyn")
                .Replace("<keybind>", PetTextsColors.KeybindText(PetKeybinds.UsePetAbility))
                .Replace("<cooldown>", mrWrath.cooldown.ToString());
               
        }
    }
}
