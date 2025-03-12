using CalamityMod.Dusts;
using PetsOverhaul.Config;
using PetsOverhaul.Systems;

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
        public static SeedStarEffect Instance;
        public float world;
        

        public override void PostUpdateEquips()
        {
            if (Player.miscEquips[1].TryGetGlobalItem(out SeedStarPet speed))
            {
               world += speed.SpeedW.CurrentStatFloat;
                
            }
        }
        
    }

    public sealed class SeedStarPet : LightPetItem
    {
        public LightPetStat SpeedW = new(3, 1.5f, 3.0f);
        public override int LightPetItemID => WOTGLightPetIDs.SeedStar;


        public override void UpdateInventory(Item item, Player player)
        {
            SpeedW.SetRoll(player.luck);           
        }
        public override void NetSend(Item item, BinaryWriter writer)
        {
            writer.Write((byte)SpeedW.CurrentRoll);   
        }
        public override void NetReceive(Item item, BinaryReader reader)
        {
            SpeedW.CurrentRoll = reader.ReadByte();  
        }
        public override void SaveData(Item item, TagCompound tag)
        {
            tag.Add("SpeedW", SpeedW.CurrentRoll);       
        }
        public override void LoadData(Item item, TagCompound tag)
        {
            if (tag.TryGet("SpeedW", out int speed))
            {
                SpeedW.CurrentRoll = speed;
            }
        }
        public override int GetRoll() => SpeedW.CurrentRoll;
        public override string PetsTooltip => Language.GetTextValue("Mods.PetHaul.LightPetTooltips.SeedStar")
            .Replace("<world>", SpeedW.BaseAndPerQuality())
            .Replace("<worldLine>", SpeedW.StatSummaryLine());


        /*   public sealed class SeedStar : GlobalItem
       {
           public override bool AppliesToEntity(Item entity, bool lateInstantiation)
           {
               return entity.type == WOTGLightPetIDs.SeedStar;
           }

           public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
           {
               if (ModContent.GetInstance<PetPersonalization>().EnableTooltipToggle && !PetKeybinds.PetTooltipHide.Current)
               {
                   return;
               }

               SeedStarEffect seedy = Main.LocalPlayer.GetModPlayer<SeedStarEffect>();
               tooltips.Add(new(Mod, "Tooltip0", Language.GetTextValue("Mods.PetsOverhaul.PetItemTooltips.CompanionCube")
                           ));
           }
          */
    }

}
