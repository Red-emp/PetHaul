using PetHaul.WOTGPets;
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
using PetHaul.Systems;


namespace PetHaul.Systems
{

    public class WOTGPetIDs
    {
        public static int Rattled => ModContent.ItemType<OblivionChime>();
        public static int DarkHole => ModContent.ItemType<BlackHole>();
        public static int MrWrath => ModContent.ItemType<Erilucyxwyn>();

    }

    public class WOTGLightPetIDs
    {
        public static int SeedStar => ModContent.ItemType<Starseed>();

    }
}
