using NoxusBoss.Content.Items.Pets;
using NoxusBoss.Core.CrossCompatibility.Inbound;
using PetHaul.WOTGPets;
using PetHaul.Systems;
using PetHaul.WOTGLightPets;
using PetsOverhaul.NPCs;
using PetsOverhaul.PetEffects;
using PetsOverhaul.Systems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;




namespace PetHaul.Systems
{

    public sealed class WorldSpeed : ModSystem
    {
        
        public override void PostUpdateWorld()
        {
            
                Main.time += (double)SeedStarEffect.Instance.speed;           
        }

    }

    
}
