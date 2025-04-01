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
using Terraria.Audio;

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

        public static Dictionary<int, SoundStyle[]> WOTGPetHurtSounds = new()
        {
            {
                WOTGPetIDs.MrWrath,
                [new SoundStyle("NoxusBoss/Assets/Sounds/NPCHit/NamelessDeityGFBHurt1") with { Volume = 0.5f},
                new SoundStyle("NoxusBoss/Assets/Sounds/NPCHit/NamelessDeityGFBHurt2") with { Volume = 0.5f},
                    new SoundStyle("NoxusBoss/Assets/Sounds/NPCHit/NamelessDeityGFBHurt3") with { Volume = 0.5f},
                    new SoundStyle("NoxusBoss/Assets/Sounds/NPCHit/NamelessDeityGFBHurt4") with { Volume = 0.5f},
                    new SoundStyle("NoxusBoss/Assets/Sounds/NPCHit/NamelessDeityGFBHurt5") with { Volume = 0.5f},
                    new SoundStyle("NoxusBoss/Assets/Sounds/NPCHit/NamelessDeityGFBHurt6") with { Volume = 0.5f},
                    new SoundStyle("NoxusBoss/Assets/Sounds/NPCHit/NamelessDeityGFBHurt7") with { Volume = 0.5f},
                    new SoundStyle("NoxusBoss/Assets/Sounds/NPCHit/NamelessDeityGFBHurt8") with { Volume = 0.5f}

                ]
            },
            {
                WOTGPetIDs.Rattled,
                [
                    new SoundStyle("NoxusBoss/Assets/Sounds/NPCHit/AvatarHurt1") with { Volume = 0.5f},
                new SoundStyle("NoxusBoss/Assets/Sounds/NPCHit/AvatarHurt2") with { Volume = 0.5f},
                    new SoundStyle("NoxusBoss/Assets/Sounds/NPCHit/AvatarHurt3") with { Volume = 0.5f},
                ]
            }
        };

        public static Dictionary<int, SoundStyle[]> WOTGPetAmbientSounds = new()
        {
            {
            WOTGPetIDs.Rattled,
            [
                new SoundStyle("NoxusBoss/Assets/Sounds/Custom/Environment/AvatarHorror1") with { Volume = 0.5f},
                new SoundStyle("NoxusBoss/Assets/Sounds/Custom/Avatar/Chirp1"),
                new SoundStyle("NoxusBoss/Assets/Sounds/Custom/Avatar/Chirp2")

            ]
            },
            {
                WOTGPetIDs.MrWrath,
                [
                new SoundStyle("NoxusBoss/Assets/Sounds/Custom/NamelessDeity/ChantLoop1") with { Volume = 0.5f},
                new SoundStyle("NoxusBoss/Assets/Sounds/Custom/NamelessDeity/ChantLoop2") with { Volume = 0.5f},
                new SoundStyle("NoxusBoss/Assets/Sounds/Custom/NamelessDeity/Chuckle") with { Volume = 0.5f}
                ]
            }
        };
        public static Dictionary<int, SoundStyle> WOTGPetKillSounds = new()
        {
            {
                WOTGPetIDs.Rattled,
                new SoundStyle("NoxusBoss/Assets/Sounds/Custom/Avatar/Scream") with { Volume = 0.5f}
            },
            {
                WOTGPetIDs.MrWrath,
                new SoundStyle("NoxusBoss/Assets/Sounds/Custom/NamelessDeity/ScreamShort") with {Volume = 0.5f}
            }
        };
        public static void AddWOTGSoundEffects()
        {
            PetSounds.PetItemIdToHurtSound.AddRange(WOTGPetHurtSounds);
            PetSounds.PetItemIdToAmbientSound.AddRange(WOTGPetAmbientSounds);
            PetSounds.PetItemidToKillSound.AddRange(WOTGPetKillSounds);
        }
    }
}
