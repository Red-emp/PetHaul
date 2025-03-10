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
using NoxusBoss.Content.NPCs.Bosses.Avatar.SpecificEffectManagers;
using NoxusBoss.Content.NPCs.Bosses.Avatar.FirstPhaseForm;
using NoxusBoss.Core.Graphics.Shaders.Screen;
using Luminance.Common.Utilities;
using NoxusBoss.Core.World.GameScenes.RiftEclipse;
using NoxusBoss.Core.World.GameScenes.AvatarAppearances;

namespace PetHaul.WOTGPets
{
	
	public sealed class RattledEffect : PetEffect
	{		
		public override PetClasses PetClassPrimary => PetClasses.Offensive;
        public override int PetItemID => WOTGPetIDs.Rattled;

        public override void PostUpdateMiscEffects()
		{

			if (Pet.PetInUseWithSwapCd(WOTGPetIDs.Rattled))
			{
				// Player.buffImmune[BuffID.Obstructed] = false;
				// Player.AddBuff(BuffID.Obstructed, 1);
				RiftEclipseSky.IsEnabled = true;


            }
			else
			{
                RiftEclipseSky.IsEnabled = false;
            }
		}
        



    }


		
		


	}

	public sealed class Rattle : GlobalItem
	{
		public override bool AppliesToEntity(Item entity, bool lateInstantiation)
		{
			return entity.type == WOTGPetIDs.Rattled;
		}

		public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
		{
			if (ModContent.GetInstance<PetPersonalization>().EnableTooltipToggle && !PetKeybinds.PetTooltipHide.Current)
			{
				return;
			}

			RattledEffect rattled = Main.LocalPlayer.GetModPlayer<RattledEffect>();
			tooltips.Add(new(Mod, "Tooltip0", Language.GetTextValue("Mods.PetsOverhaul.PetItemTooltips.CompanionCube")                       
						));
		}

		
	}


