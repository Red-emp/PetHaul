using PetHaul.Systems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;


namespace PetHaul
{
	
	public class PetHaul : Mod
	{
		public override void Load()
		{
            Compatibility.AddPetItemNames();

        }


	}
}
