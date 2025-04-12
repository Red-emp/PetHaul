using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NoxusBoss.Content.Items.Pets;
using NoxusBoss.Core.CrossCompatibility.Inbound;
using Terraria.ModLoader;
using PetsOverhaul.NPCs;
using PetsOverhaul.PetEffects;
using PetsOverhaul.Systems;
using Terraria.ID;
using PetHaul.WOTGPets;
using PetHaul.Systems;
using MonoMod.Utils;
using Terraria;
using NoxusBoss.Content.Items;
using NoxusBoss.Content.Items.MiscOPTools;
using CalamityMod.Items.Materials;
using NoxusBoss.Content.Items.Accessories.VanityEffects;
using NoxusBoss.Content.Buffs;
using CalamityMod.Buffs.Pets;
using PetsOverhaulCalamityAddon.CalamityPets;
using PetsOverhaulCalamityAddon.Buffs;
using Terraria.Localization;

namespace PetHaul.Systems
{
    public class WOTGModPlayer : ModPlayer
    {

        void StarPlus(int Defense, float Crit, float Damage, float SummonerKb, float AtkSpd, float MoveSpd, float MiningSpeed, int ManaSpeed)
        {
            Player.statDefense += Defense;
            Player.GetCritChance<GenericDamageClass>() += Crit;
            Player.GetDamage<GenericDamageClass>() += Damage;
            Player.GetAttackSpeed<GenericDamageClass>() = AtkSpd;
            Player.GetKnockback<SummonDamageClass>() += SummonerKb;
            Player.moveSpeed += MoveSpd;
            Player.pickSpeed -= MiningSpeed;
            Player.manaRegen += ManaSpeed;
        }
        public int defense = 8;
        public float crit = 8;
        public float damage = 0.135f;
        public float atkSpd = 1.35f;
        public float summonerKb = 1.35f;
        public float moveSpd = 1.35f;
        public float miningSpd = 0.3f;
        public int manaSpd = 5;

        public override void PostUpdateEquips()
        {
            if (Player.TryGetModPlayer(out PineappleEffect pineapple))
                if (pineapple.PetIsEquipped())
                {

                    if (Player.HasBuff(ModContent.BuffType<StarstrikinglySatiated>()))
                    {
                        ModContent.BuffType<SuperStarstrikinglySatiated>();



                    }

                    if (Player.HasBuff(ModContent.BuffType<SuperStarstrikinglySatiated>()))
                    {
                        StarPlus(defense, crit, damage, summonerKb, atkSpd, moveSpd, miningSpd, manaSpd);
                        Player.ClearBuff(ModContent.BuffType<StarstrikinglySatiated>());
                    }

                }


        }


    }

    public class SuperStarstrikinglySatiated : ModBuff
    {

        public override LocalizedText Description => Language.GetText("Mods.PetsOverhaulCalamityAddon.Buffs.TheGrandNourishmentTooltip");
        public override LocalizedText DisplayName => Language.GetText("Mods.PetsOverhaulCalamityAddon.Buffs.TheGrandNourishmentDisplayName");
    }


}
