using PetHaul.Systems;
using PetsOverhaul.NPCs;
using PetsOverhaul.PetEffects;
using PetsOverhaul.Systems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using Terraria.ModLoader;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using MonoMod.RuntimeDetour;


namespace PetHaul
{
	
	public class PetHaul : Mod
	{
        public static Action<Projectile> BeforeProjectilePreAI;
        private delegate bool orig_ProjectileLoaderPreAI(Projectile projectile);
        private delegate bool hook_ProjectileLoaderPreAI(orig_ProjectileLoaderPreAI orig, Projectile projectile);
        private readonly List<Hook> hooks = new();
        private static readonly MethodInfo PreAIInfo = typeof(ProjectileLoader).GetMethod("PreAI");

        public override void Load()
		{
            Compatibility.AddPetItemNames();
            Compatibility.AddWOTGSoundEffects();

            hooks.Add(new(PreAIInfo, ProjectileLoaderPreAIDetour));
            foreach (Hook hook in hooks)
            {
                hook.Apply();
            }

        }

        private static bool ProjectileLoaderPreAIDetour(orig_ProjectileLoaderPreAI orig, Projectile projectile)
        {
            BeforeProjectilePreAI?.Invoke(projectile);

            return orig(projectile);
        }


    }
}
