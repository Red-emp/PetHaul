using CalamityMod.Buffs.DamageOverTime;
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
using CalamityMod.CalPlayer;
using NoxusBoss.Assets;
using Terraria.GameInput;
using Luminance.Common.Utilities;
using NoxusBoss.Core.World.GameScenes.RiftEclipse;
using NoxusBoss.Core.World.GameScenes.AvatarAppearances;
using NoxusBoss.Content.Projectiles.Pets;
using Extensions;
using CalamityMod;
using System.Linq;
using System.Security.Cryptography.X509Certificates;


namespace PetHaul.WOTGPets
{

    public sealed class RattledEffect : PetEffect
    {
        public override PetClasses PetClassPrimary => PetClasses.Rogue;
        public override int PetItemID => WOTGPetIDs.Rattled;
        public float maxStealth = 5.0f;

        public override void PostUpdateMiscEffects()
        {
            if (Pet.PetInUseWithSwapCd(WOTGPetIDs.Rattled))
            {
                RiftEclipseSky.IsEnabled = true;

            }
            else
            {
                RiftEclipseSky.IsEnabled = false;
            }
        }

        public override void PostUpdateEquips()
        {
            Player.Calamity().rogueStealthMax += maxStealth;
            Player.ChatColor().Equals("Red");
        }


    }

 




    public sealed class OblivionyChime : PetTooltip
    {
        public override PetEffect PetsEffect => rattled;

        public static RattledEffect rattled
        {
            get
            {
                if (Main.LocalPlayer.TryGetModPlayer(out RattledEffect pet))
                    return pet;
                else
                    return ModContent.GetInstance<RattledEffect>();
            }
        }

        public override string PetsTooltip => Language.GetTextValue("Mods.PetHaul.PetTooltips.OblivionChime")
            .Replace("<stelth>", Math.Round(rattled.maxStealth * 100, 2).ToString());

    }
}


