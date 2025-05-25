using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NoxusBoss.Content.Items.Pets;
using Terraria.ModLoader;
using PetsOverhaul.NPCs;
using PetsOverhaul.PetEffects;
using PetsOverhaul.Systems;
using Terraria.ID;
using PetHaul.WOTGPets;
using PetHaul.Systems;
using MonoMod.Utils;
using Terraria;
using NoxusBoss.Content.Buffs;
using CalamityMod.Buffs.Pets;
using PetsOverhaulCalamityAddon.CalamityPets;
using Terraria.Localization;
using PetsOverhaulCalamityAddon;
using rail;
using CalamityMod;
using System.Security.Cryptography.X509Certificates;

namespace PetHaul.Systems
{
    public class WOTGModPlayer : ModPlayer
    {
       /* public class SuperStar : ModBuff
        {
            public override LocalizedText Description
            {             
                get
                {
                    return Language.GetText
                        ("Mods.PetHaul.Buffs.SuperStarstrikinglySatiatedTooltip");
                }              
            }

            public override LocalizedText DisplayName
            {
                get
                {
                    return Language.GetText("Mods.PetHaul.Buffs.SuperStarstrikinglySatiatedDisplayName");
                }
            }
        }
       */

        public class SuperStarstrikinglySatiated : GlobalBuff
        {
            public override void Update(int type, Player player, ref int buffIndex)
            {
                if (player.HasBuff(ModContent.BuffType<StarstrikinglySatiated>()))
                {
                    if (player.GetModPlayer<PineappleEffect>().PetIsEquipped(true))
                    {
                        player.wellFed = true;
                        player.statDefense += 8;
                        player.GetAttackSpeed<GenericDamageClass>() += 0.135f;
                        player.GetDamage<GenericDamageClass>() += 0.135f;
                        player.GetCritChance<GenericDamageClass>() += 5.5f;
                        player.GetKnockback<SummonDamageClass>() += 1.2f;
                        player.moveSpeed += 0.55f;
                        player.pickSpeed -= 0.3f;
                        player.manaRegen += 5;
                        
                       
                    }
                }
            }           
        }
    }
}
