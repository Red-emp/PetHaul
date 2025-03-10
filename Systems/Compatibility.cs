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

namespace PetHaul.Systems
{
    internal class Compatibility
    {
        public static Dictionary<string, int> WOTGPetItemIDs = new()
        {
            {"OblivionChime", WOTGPetIDs.Rattled },
            {"BlackHole", WOTGPetIDs.DarkHole },
            {"Starseed", WOTGLightPetIDs.SeedStar },
            {"Erilucyxwyn", WOTGPetIDs.MrWrath }
        };

        public static void AddPetItemNames()
        {
            PetItemIDs.PetNamesAndItems.AddRange(WOTGPetItemIDs);
        }
    }
}
