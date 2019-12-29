using VagrantStory.Core;
using VagrantStory.Items;

// https://gamefaqs.gamespot.com/ps/914326-vagrant-story/faqs/29828
// http://chrysaliswiki.com/ability:attacks-of-vagrant-story#toc6


namespace VagrantStory.Database
{
    public class BreakArtsDB
    {
        // Dague
        //Power Max
        //Hémiplégie
        //Piercing Point
        //Multiple Blows
        public static BreakArt Whistle_Sting = new BreakArt("Whistle Sting", "Bludgeons foe with power from the blade", Enums.eBladeCategory.DAGGER, 25, new Enums.eAffinity[] { Enums.eAffinity.NONE }, Enums.eDamageType.BLUNT);
        public static BreakArt Shadowweave = new BreakArt("Shadowweave", "Paralyzes foe with a damaging strike", Enums.eBladeCategory.DAGGER, 40, new Enums.eAffinity[] { Enums.eAffinity.DARK }, Enums.eDamageType.BLUNT);
        public static BreakArt Double_Fang = new BreakArt("Double Fang", "Repeatedly strikes the same location", Enums.eBladeCategory.DAGGER, 55, new Enums.eAffinity[] { Enums.eAffinity.NONE }, Enums.eDamageType.PIERCING, 2);
        public static BreakArt Wyrm_Scorn = new BreakArt("Wyrm Scorn", "Splits the blade to attack from all directions", Enums.eBladeCategory.DAGGER, 75, new Enums.eAffinity[] { Enums.eAffinity.NONE }, Enums.eDamageType.PIERCING);

        // Sabre
        //Cathare
        //Parfum Fatal
        //Glacificication
        //Doigt de Dieu
        public static BreakArt Rending_Gale = new BreakArt("Rending Gale", "Launches a sonic wave to shred foe to pieces", Enums.eBladeCategory.SWORD, 25, new Enums.eAffinity[] { Enums.eAffinity.NONE }, Enums.eDamageType.PIERCING);
        public static BreakArt Vile_Scar = new BreakArt("Vile Scar", "Forms a poisonous cloud to choke the enemy", Enums.eBladeCategory.SWORD, 40, new Enums.eAffinity[] { Enums.eAffinity.NONE }, Enums.eDamageType.EDGED, 1,
            new BreakArtEffect[] { new BreakArtEffect(BreakArtEffect.Target.TARGET, BreakArtEffect.Type.ADD_STATUS, BreakArtEffect.Status.Poison) });
        public static BreakArt Cherry_Ronde = new BreakArt("Cherry Ronde", "Encases both blade and foe in an icy sheath", Enums.eBladeCategory.SWORD, 55, new Enums.eAffinity[] { Enums.eAffinity.WATER }, Enums.eDamageType.EDGED);
        public static BreakArt Papillon_Reel = new BreakArt("Papillon Reel", "Calls heavenly light down into the blade", Enums.eBladeCategory.SWORD, 75, new Enums.eAffinity[] { Enums.eAffinity.LIGHT }, Enums.eDamageType.EDGED);

        // Epée
        //Kickback
        //Catalepsie
        //Equarrissage
        //Signe Divin
        public static BreakArt Sunder = new BreakArt("Sunder", "Focused energies cut the life from foe", Enums.eBladeCategory.GREAT_SWORD, 25, new Enums.eAffinity[] { Enums.eAffinity.NONE }, Enums.eDamageType.PIERCING);
        public static BreakArt Thunderwave = new BreakArt("Thunderwave", "Paralyzes foe with a damaging strike", Enums.eBladeCategory.GREAT_SWORD, 40, new Enums.eAffinity[] { Enums.eAffinity.AIR }, Enums.eDamageType.EDGED);
        public static BreakArt Swallow_Slash = new BreakArt("Swallow Slash", "A quick snap of the blade deals double damage", Enums.eBladeCategory.GREAT_SWORD, 55, new Enums.eAffinity[] { Enums.eAffinity.NONE }, Enums.eDamageType.EDGED, 2);
        public static BreakArt Advent_Sign = new BreakArt("Advent Sign", "Rippling holy energy shreds foe", Enums.eBladeCategory.GREAT_SWORD, 75, new Enums.eAffinity[] { Enums.eAffinity.LIGHT }, Enums.eDamageType.EDGED);

        // Hache & massse
        //Aquilon
        //Blizzard
        //Télescopage
        //Anti-matière
        public static BreakArt Mistral_Edge = new BreakArt("Mistral Edge", "Whips a stunning sheet of air at foe", Enums.eBladeCategory.AXEANDMACE, 25, new Enums.eAffinity[] { Enums.eAffinity.NONE }, Enums.eDamageType.BLUNT);
        public static BreakArt Glacial_Gale = new BreakArt("Glacial Gale", "Numbs foe with a damaging strike", Enums.eBladeCategory.AXEANDMACE, 40, new Enums.eAffinity[] { Enums.eAffinity.AIR }, Enums.eDamageType.BLUNT, 1,
            new BreakArtEffect[] { new BreakArtEffect(BreakArtEffect.Target.TARGET, BreakArtEffect.Type.ADD_STATUS, BreakArtEffect.Status.Numbness) });
        public static BreakArt Killer_Mantis = new BreakArt("A blinding rush damages and saps MP from foe", "breakart_desc", Enums.eBladeCategory.AXEANDMACE, 55, new Enums.eAffinity[] { Enums.eAffinity.NONE }, Enums.eDamageType.EDGED, 1,
            new BreakArtEffect[] { new BreakArtEffect(BreakArtEffect.Target.TARGET, BreakArtEffect.Type.MODIFIER, BreakArtEffect.Mod.MP, -50) } ); // TODO : INT based MP damage
        public static BreakArt Black_Nebula = new BreakArt("Black Nebula", "Blasts foe with a burst of negative energy", Enums.eBladeCategory.AXEANDMACE, 75, new Enums.eAffinity[] { Enums.eAffinity.DARK }, Enums.eDamageType.BLUNT);

        //Francisque
        //Luminescence
        //Commotion
        //Iron Ripper
        //Souffrance
        public static BreakArt Bear_Claw = new BreakArt("Bear Claw", "Smashes foe with a luminescent downward strike", Enums.eBladeCategory.GREAT_AXE, 25, new Enums.eAffinity[] { Enums.eAffinity.NONE }, Enums.eDamageType.BLUNT);
        public static BreakArt Accursed_Umbra = new BreakArt("Accursed Umbra", "Curses foe with a damaging strike", Enums.eBladeCategory.GREAT_AXE, 40, new Enums.eAffinity[] { Enums.eAffinity.NONE }, Enums.eDamageType.BLUNT, 1,
            new BreakArtEffect[] { new BreakArtEffect(BreakArtEffect.Target.TARGET, BreakArtEffect.Type.ADD_STATUS, BreakArtEffect.Status.Curse) });
        public static BreakArt Iron_Ripper = new BreakArt("Iron Ripper", "Powerful blow that damages both armor and foe", Enums.eBladeCategory.GREAT_AXE, 55, new Enums.eAffinity[] { Enums.eAffinity.NONE }, Enums.eDamageType.BLUNT, 1,
            new BreakArtEffect[] { new BreakArtEffect(BreakArtEffect.Target.TARGET, BreakArtEffect.Type.ADD_STATUS, BreakArtEffect.Status.Tarnish) });
        public static BreakArt Emetic_Bomb = new BreakArt("Emetic Bomb", "Unleashes a series of slashing blows", Enums.eBladeCategory.GREAT_AXE, 75, new Enums.eAffinity[] { Enums.eAffinity.NONE }, Enums.eDamageType.EDGED);

        // Sceptre
        //Sirocco
        //Riskbreak
        //Ether
        //Trinity Pulse
        public static BreakArt Sirocco = new BreakArt("Sirocco", "Searing hot winds and wildfire engulf foe", Enums.eBladeCategory.STAFF, 25, new Enums.eAffinity[] { Enums.eAffinity.FIRE }, Enums.eDamageType.BLUNT);
        public static BreakArt Riskbreak = new BreakArt("Riskbreak", "Focused blow that deals damage and reduces RISK", Enums.eBladeCategory.STAFF, 40, new Enums.eAffinity[] { Enums.eAffinity.NONE }, Enums.eDamageType.PIERCING, 1,
            new BreakArtEffect[] { new BreakArtEffect(BreakArtEffect.Target.SELF, BreakArtEffect.Type.MODIFIER, BreakArtEffect.Mod.RISK, -20) }); // Reduces RISK
        public static BreakArt Gravis_Aether = new BreakArt("Gravis Aether", "Solidifies æther to crush foe", Enums.eBladeCategory.STAFF, 55, new Enums.eAffinity[] { Enums.eAffinity.EARTH }, Enums.eDamageType.BLUNT);
        public static BreakArt Trinity_Pulse = new BreakArt("Trinity Pulse", "Crushes foe with a triad of shock waves", Enums.eBladeCategory.STAFF, 75, new Enums.eAffinity[] { Enums.eAffinity.NONE }, Enums.eDamageType.BLUNT);

        // Masse lourde
        //Bonecrusher
        //Choc Céleste
        //Ardeur
        //Hex Flux
        public static BreakArt Bonecrusher = new BreakArt("Bonecrusher", "Energy release metes out a bone-crushing blow", Enums.eBladeCategory.HEAVY_MACE, 25, new Enums.eAffinity[] { Enums.eAffinity.NONE }, Enums.eDamageType.BLUNT);
        public static BreakArt Quickshock = new BreakArt("Quickshock", "Numbs foe with a damaging strike", Enums.eBladeCategory.HEAVY_MACE, 40, new Enums.eAffinity[] { Enums.eAffinity.AIR }, Enums.eDamageType.BLUNT, 1,
            new BreakArtEffect[] { new BreakArtEffect(BreakArtEffect.Target.TARGET, BreakArtEffect.Type.ADD_STATUS, BreakArtEffect.Status.Numbness) });
        public static BreakArt Ignis_Wheel = new BreakArt("Ignis Wheel", "A spreading sheet of flame engulfs foe", Enums.eBladeCategory.HEAVY_MACE, 55, new Enums.eAffinity[] { Enums.eAffinity.NONE, Enums.eAffinity.FIRE }, Enums.eDamageType.PIERCING, 2);
        public static BreakArt Hex_Flux = new BreakArt("Hex Flux", "Fuses power of light and darkness in one", Enums.eBladeCategory.HEAVY_MACE, 75, new Enums.eAffinity[] { Enums.eAffinity.LIGHT, Enums.eAffinity.DARK }, Enums.eDamageType.BLUNT, 2);

        //Lance
        //Ruine
        //Ombre
        //Poigne d'acier
        //Typhoon
        public static BreakArt Ruination = new BreakArt("Ruination", "Lashes out with a focused thrust of energy", Enums.eBladeCategory.POLEARM, 25, new Enums.eAffinity[] { Enums.eAffinity.NONE }, Enums.eDamageType.PIERCING);
        public static BreakArt Scythe_Wind = new BreakArt("Scythe Wind", "Inflicts damage and tarnishes arms and armor", Enums.eBladeCategory.POLEARM, 40, new Enums.eAffinity[] { Enums.eAffinity.AIR }, Enums.eDamageType.PIERCING, 1,
            new BreakArtEffect[] { new BreakArtEffect(BreakArtEffect.Target.TARGET, BreakArtEffect.Type.ADD_STATUS, BreakArtEffect.Status.Tarnish) });
        public static BreakArt Giga_Tempest = new BreakArt("Giga Tempest", "Energy storm damages both armor and foe", Enums.eBladeCategory.POLEARM, 55, new Enums.eAffinity[] { Enums.eAffinity.NONE }, Enums.eDamageType.PIERCING);
        public static BreakArt Spiral_Scourge = new BreakArt("Spiral Scourge", "Whips air moisture into a penetrating whirlwind", Enums.eBladeCategory.POLEARM, 75, new Enums.eAffinity[] { Enums.eAffinity.WATER }, Enums.eDamageType.PIERCING);

        // Arbalère
        //Radial Kick
        //Combustion
        //Voile Mortuaire
        //Sanctus Flare
        public static BreakArt Brimstone_Hail = new BreakArt("Brimstone Hail", "Unleashes the fury of the Dark to damage foe", Enums.eBladeCategory.CROSSBOW, 25, new Enums.eAffinity[] { Enums.eAffinity.FIRE, Enums.eAffinity.DARK }, Enums.eDamageType.PIERCING, 2);
        public static BreakArt Heavens_Scorn = new BreakArt("Heaven's Scorn", "The shaft becomes a conduit for heaven's light", Enums.eBladeCategory.CROSSBOW, 40, new Enums.eAffinity[] { Enums.eAffinity.AIR, Enums.eAffinity.LIGHT }, Enums.eDamageType.PIERCING, 2);
        public static BreakArt Death_Wail = new BreakArt("Death Wail", "Fires a bolt of pure demonic energy", Enums.eBladeCategory.CROSSBOW, 55, new Enums.eAffinity[] { Enums.eAffinity.EARTH, Enums.eAffinity.DARK }, Enums.eDamageType.PIERCING, 2);
        public static BreakArt Sanctus_Flare = new BreakArt("Sanctus Flare", "Channels the power of the dragons of light", Enums.eBladeCategory.CROSSBOW, 75, new Enums.eAffinity[] { Enums.eAffinity.WATER, Enums.eAffinity.LIGHT }, Enums.eDamageType.PIERCING, 2);

        // mains nues
        //Humiliation
        //Vertigo
        //Reverse Aura
        //Flagellation
        public static BreakArt Lotus_Palm = new BreakArt("Lotus Palm", "Focuses spirit into Ashley's fist", Enums.eBladeCategory.NONE, 25, new Enums.eAffinity[] { Enums.eAffinity.PHYSICAL }, Enums.eDamageType.BLUNT);
        public static BreakArt Vertigo = new BreakArt("Vertigo", "Numbs foe with a damaging strike", Enums.eBladeCategory.NONE, 40, new Enums.eAffinity[] { Enums.eAffinity.PHYSICAL }, Enums.eDamageType.BLUNT, 1,
            new BreakArtEffect[] { new BreakArtEffect(BreakArtEffect.Target.TARGET, BreakArtEffect.Type.ADD_STATUS, BreakArtEffect.Status.Numbness) });
        public static BreakArt Vermillion_Aura = new BreakArt("Vermillion Aura", "Strikes the Dark using the power of light", Enums.eBladeCategory.NONE, 55, new Enums.eAffinity[] { Enums.eAffinity.LIGHT }, Enums.eDamageType.BLUNT, 2);
        public static BreakArt Retribution = new BreakArt("Retribution", "Turns the power of Dark against itself", Enums.eBladeCategory.NONE, 75, new Enums.eAffinity[] { Enums.eAffinity.DARK }, Enums.eDamageType.BLUNT);
    }

}