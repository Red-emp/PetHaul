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

        public override PetClasses PetClassPrimary => PetClasses.Defensive;

        public int oneRange = 600;
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

                

                GlobalPet.CircularDustEffect(Player.Center, DustID.Ash, oneRange, 20);
                GlobalPet.CircularDustEffect(Player.Center, DustID.Ash, twoRange, 20);
                GlobalPet.CircularDustEffect(Player.Center, DustID.Ash, threeRange, 20);

                foreach (var npc in Main.ActiveNPCs)
                {
                    if (Player.Distance(npc.Center) < oneRange && Player.Distance(npc.Center) > twoRange)
                    {
                        NpcPet.AddSlow(new NpcPet.PetSlow(oneSlow, 1, PetSlowIDs.IndependentSlow), npc);
                    }
                    else if (Player.Distance(npc.Center) < twoRange && Player.Distance(npc.Center) > threeRange)
                    {
                        NpcPet.AddSlow(new NpcPet.PetSlow(twoSlow, 1, PetSlowIDs.IndependentSlow), npc);
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
                        SlowProj.AddSlow(new SlowProj.PetSlow(onepSlow, 1, PetSlowIDs.IndependentSlow), projectile);
                    }
                    else if (Player.Distance(projectile.Center) < twoRange && Player.Distance(projectile.Center) > threeRange)
                    {
                        SlowProj.AddSlow(new SlowProj.PetSlow(twopSlow, 1, PetSlowIDs.IndependentSlow), projectile);
                    }
                    else if (Player.Distance(projectile.Center) < threeRange)
                    {
                        SlowProj.AddSlow(new SlowProj.PetSlow(threepSlow, 1, PetSlowIDs.IndependentSlow), projectile);
                    }

                }

            }
        }
    }

    public sealed class BlackyHole : PetTooltip
    {
        public override PetEffect PetsEffect => darkHole;

        public static DarkHoleEffect darkHole
        {
            get
            {
                if (Main.LocalPlayer.TryGetModPlayer(out DarkHoleEffect pet))
                    return pet;
                else
                    return ModContent.GetInstance<DarkHoleEffect>();
            }
        }

        public override string PetsTooltip => Language.GetTextValue("Mods.PetHaul.PetTooltips.BlackHole")
            .Replace("<won>", darkHole.oneSlow.ToString())
            .Replace("<too>", darkHole.twoSlow.ToString())
            .Replace("<threy>", darkHole.threeSlow.ToString());

    }
}
