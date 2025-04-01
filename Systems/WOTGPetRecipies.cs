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

namespace PetHaul.Systems
{
    public class WOTGPetRecipies : ModSystem
    {
        public override void AddRecipes()
        {
            PetRecipes.MasterModePetRecipe(Recipe.Create(WOTGPetIDs.MrWrath).AddIngredient<CheatPermissionSlip>().AddIngredient<GoodApple>(10), 30000);
            PetRecipes.MasterModePetRecipe(Recipe.Create(WOTGPetIDs.DarkHole).AddIngredient<DeificTouch>(), 30000);
            PetRecipes.MasterModePetRecipe(Recipe.Create(WOTGPetIDs.Rattled).AddIngredient<EmptinessSprayer>(), 20000);

            PetRecipes.PetRecipe(Recipe.Create(WOTGLightPetIDs.SeedStar).AddIngredient<EssenceofSunlight>(50).AddIngredient<DarksunFragment>(100), 20000);
        }

    }



}
