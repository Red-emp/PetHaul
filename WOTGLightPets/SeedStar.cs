using CalamityMod.Dusts;
using PetsOverhaul.Config;
using PetsOverhaul.Systems;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using NoxusBoss.Content.Items.Pets;
using NoxusBoss.Core.CrossCompatibility.Inbound;
using PetHaul.Systems;
using PetHaul.WOTGPets;
using PetsOverhaul.NPCs;


namespace PetHaul.WOTGLightPets
{
    public sealed class SeedStarEffect : LightPetEffect
    {
        public override int LightPetItemID => WOTGLightPetIDs.SeedStar;
        public override void PostUpdateEquips()
        {
            if (Player.miscEquips[1].TryGetGlobalItem(out SeedStarPet speed))
            {
                Main.time += speed.SpeedW.CurrentStatFloat;
                Main.updateRate += speed.Uped.CurrentStatInt;
                Player.miscCounter += speed.Uped.CurrentStatInt;
            }
        }
        public sealed class SeedStarPet : LightPetItem
        {
            public LightPetStat SpeedW = new(3, 1.0f, 3.0f);
            public LightPetStat Uped = new(5, 5, 10);
            public override int LightPetItemID => WOTGLightPetIDs.SeedStar;

            public override void UpdateInventory(Item item, Player player)
            {
                SpeedW.SetRoll(player.luck);
                Uped.SetRoll(player.luck);
            }
            public override void NetSend(Item item, BinaryWriter writer)
            {
                writer.Write((byte)SpeedW.CurrentRoll);
                writer.Write((byte)Uped.CurrentRoll);
            }
            public override void NetReceive(Item item, BinaryReader reader)
            {
                SpeedW.CurrentRoll = reader.ReadByte();
                Uped.CurrentRoll = reader.ReadByte();
            }
            public override void SaveData(Item item, TagCompound tag)
            {
                tag.Add("Stat1", SpeedW.CurrentRoll);
                tag.Add("Stat2", Uped.CurrentRoll);
            }
            public override void LoadData(Item item, TagCompound tag)
            {
                if (tag.TryGet("Stat1", out int speed))
                {
                    SpeedW.CurrentRoll = speed;
                }
                if (tag.TryGet("Stat2", out int ups))
                {
                    Uped.CurrentRoll = ups;
                }

            }
            public override int GetRoll() => SpeedW.CurrentRoll;
            public override string PetsTooltip => Language.GetTextValue("Mods.PetHaul.LightPetTooltips.Starseed")
                .Replace("<world>", SpeedW.BaseAndPerQuality())
                .Replace("<worldLine>", SpeedW.StatSummaryLine());
        }
    }
}
