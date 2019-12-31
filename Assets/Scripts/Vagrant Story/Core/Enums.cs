namespace VagrantStory.Core
{
    public class Enums
    {
        public enum eAffinity
        {
            NONE = 0, PHYSICAL, AIR, FIRE, EARTH, WATER, LIGHT, DARK
        }
        public enum eMaterial { NONE = 0, WOOD = 1, LEATHER = 2, BRONZE = 3, IRON = 4, HAGANE = 5, SILVER = 6, DAMASCUS = 7 }
        public enum eDamageType { NONE = 0, BLUNT, EDGED, PIERCING };
        public enum eBladeCategory { NONE = 0, DAGGER = 1, SWORD = 2, GREAT_SWORD = 3, AXE = 4, MACE = 5, GREAT_AXE = 6, STAFF = 7, HEAVY_MACE = 8, POLEARM = 9, CROSSBOW = 10, SHIELD, AXEANDMACE };

        public enum eSpellCategory { NONE = 0, SHAMAN, ENCHANTER, WARLOCK, SORCERER, OTHER };
        public enum eCombatTechType { NONE = 0, ATTACK, DEFENSE };

        /*
        Excellent 100% Excellente condition.
        Good 99% - 75% Satisfaisant.
        Average 75% - 25% Blessé, soins requis.
        Bad moins de 24% Blessures graves.
        Dying moins de 2 HP Etat critique, aucune mobilité.
        */
        public enum eBodyPartStatus { Excellent, Good, Average, Bad, Dying }; // blue, green, yellow, red : 100% - 75% - 50% - 25% -0%
        public enum eDaggerBlade
        {
            None = 0,
            Battle_Knife = 1,
            Scramasax,
            Dirk,
            Throwing_Knife,
            Kudi,
            Cinquedea,
            Kris,
            Hatchet,
            Khukuri,
            Baselard,
            Stiletto,
            Jamadhar
        };
        public enum eSwordBlade
        {
            None = 0,
            Spatha = 13,
            Scimitar,
            Rapier,
            Short_Sword,
            Firangi,
            Shamshir,
            Falchion,
            Shotel,
            Khora,
            Khophish,
            Wakizashi,
            Rhomphaia
        };
        public enum eGreatSwordBlade
        {
            None = 0,
            Broad_Sword = 25,
            Norse_Sword,
            Katana,
            Executioner,
            Claymore,
            Schiavona,
            Bastard_Sword,
            Nodachi,
            Rune_Blade,
            Holy_Wind
        };
        public enum eAxeBlade
        {
            None = 0,
            Hand_Axe = 35,
            Battle_Axe,
            Francisca,
            Tabarzin,
            Chamkaq,
            Tabar,
            Bullova,
            Crescent
        };
        public enum eMaceBlade
        {
            None = 0,
            Goblin_Club = 43,
            Spiked_Club,
            Ball_Mace,
            Footmans_Mace,
            Morning_Star,
            War_Hammer,
            Bec_de_Corbin,
            War_Maul

        };
        public enum eGreatAxeBlade
        {
            None = 0,
            Guisarme = 51,
            Large_Crescent,
            Sabre_Halberd,
            Balbriggin,
            Double_Blade,
            Halberd
        };
        public enum eStaffBlade
        {
            None = 0,
            Wizard_Staff = 57,
            Clergy_Rod,
            Summoner_Baton,
            Shamanic_Staff,
            Bishops_Crosier,
            Sages_Cane
        };
        public enum eHeavyMaceBlade
        {
            None = 0,
            Langdebeve = 63,
            Sabre_Mace,
            Footmans_Mace,
            Gloomwing,
            Mjolnir,
            Griever,
            Destroyer,
            Hand_Of_Light
        };
        public enum ePolearmBlade
        {
            None = 0,
            Spear = 71,
            Glaive,
            Scorpion,
            Corcesca,
            Trident,
            Awl_Pike,
            Boar_Spear,
            Fauchard,
            Voulge,
            Pole_Axe,
            Bardysh,
            Brandestoc
        };
        public enum eCrossbowBlade
        {
            None = 0,
            Gastraph_Bow = 83,
            Light_Crossbow,
            Target_Bow,
            Windlass,
            Cranquein,
            Lug_Crossbow,
            Siege_Bow,
            Arbalest
        };


        public enum eShield
        {
            None = 0,
            Buckler_Shield = 91,
            Hoplite_Shield,
            Round_Shield,
            Targe_Shield,
            Quad_Shield,
            Tower_Shield,
            Oval_Shield,
            Pelta_Shield,
            Circle_Shield,
            Heater_Shield,
            Spiked_Shield,
            Kite_Shield,
            Casserole_Shield,
            Jazeraint_Shield,
            Dread_Shield,
            Knight_Shield
        };

        public enum eGripCategory { None, Guard, Grip, Pole, Bolt };
        public enum eGuard { None = 0, Short_Hilt = 1, Swept_Hilt, Cross_Guard, Knuckle_Guard, Counter_Guard, Side_Ring, Power_Palm, Murderers_Hilt, Spiral_Hilt }
        public enum eGrip { None = 0, Wooden_Grip = 10, Sand_Face, Czekan_Type, Sarissa_Grip, Gendarme, Heavy_Grip, Runkastyle, Bhuj_Type, Grimoire_Grip, Elephant }
        public enum ePole { None = 0, Wooden_Pole = 20, Spiculum_Pole, Winged_Pole, Framea_Pole, Ahlspies, Spiral_Pole }
        public enum eBolt { None = 0, Simple_Bolt = 26, Steel_Bolt, Javelin_Bolt, Falarica_Bolt, Stone_Bullet, Sonic_Bullet }

        public enum eGem
        {
            None,
            Talos_Feldspear, Titan_Malachite, Sylphid_Topaz, Djinn_Amber, Salamander_Ruby, Ifrit_Carnelian, Gnome_Emerald, Dao_Moonstone,
            Undine_Jasper, Marid_Aquamarine, Angel_Pearl, Seraphim_Diamond, Morlock_Jet, Berial_Black_Pearl, Haeralis, Orlandu,
            Orion, Ogmius, Iocus, Balvus, Trinity, Beowulf, Dragonite, Sigguld,
            Demonia, Altema, Polaris, Basivalin, Galerian, Vedivier, Berion, Gervin,
            Tertia, Lancer, Arturos, Braveheart, Hellraiser, Nightkiller, Manabreaker, Powerfist,
            Brainshield, Speedster, Silent_Queen, Dark_Queen, Death_Queen, White_Queen,
        };


        public enum eArmorCategory { NONE, SHIELD, HELM, ARMOR, GLOVE, BOOTS, ACCESSORY };

        public enum eHelm
        {
            None,
            Bandana, Bear_Mask, Wizard_Hat, Bone_Helm, Chain_Coif, Spangenhelm, Cabasset, Sallet,
            Barbut, Basinet, Armet, Close_Helm, Burgonet, Hoplite_Helm, Jazeraint_Helm, Dread_Helm
        };
        public enum eArmor
        {
            None,
            Jerkin, Hauberk, Wizard_Robe, Cuirass, Banded_Mail, Ring_Mail, Chain_Mail, Breastplate,
            Segementata, Scale_Armor, Brigandine, Plate_Mail, Fluted_Armor, Hoplite_Armor, Jazeraint_Armor, Dread_Armor
        };
        public enum eBoots
        {
            None,
            Bandage, Sandals, Boots, Long_Boots, Light_Grieve, Ring_Leggings, Chain_Leggings, Fusskampf,
            Poleyn, Jambeau, Missaglia, Plate_Leggings, Fluted_Leggings, Hoplite_Leggings, Jazeraint_Leggings, Dread_Leggings
        };
        public enum eGlove
        {
            None,
            Buffle, Leather_Glove, Reinforced_Glove, Knuckles, Ring_Sleeve, Chain_Sleeve, Gauntlet, Vambrace,
            Plate_Glove, Rondanche, Tilt_Glove, Freiturnier, Fluted_Glove, Hoplite_Glove, Jazeraint_Glove, Dread_Glove
        };

        public enum eAccessory
        {
            None,
            Rood_Necklace, Rune_Earrings, Lionhead, Rusted_Nails, Sylphid_Ring, Marduk, Salamander_Ring, Tamulis_Tongue,
            Gnome_Bracelet, Palolos_Ring, Undine_Bracelet, Talian_Ring, Agriass_Balm, Kadesh_Ring, Agrippas_Choker, Diadras_Earring,
            Titans_Ring, Lau_Feis_Armlet, Swan_Song, Pushpaka, Edgars_Ring, Cross_Choker, Ghost_Hound, Beaded_Amulet, Dragonhead,
            Faufnirs_Tear, Agaless_Chain, Balams_Ring, Ninja_Coif, Morgans_Nails, Marlenes_Ring
        };

        public enum eZone
        {
            None,
            Wine_Cellar,
            Catacombs,
            Sanctum,
            Abandoned_Mines_B1,
            Abandoned_Mines_B2,
            Limestone_Quarry,
            Templ_of_Kiltia,
            Great_Cathedral_B1,
            Great_Cathedral_L1,
            Great_Cathedral_L2,
            Great_Cathedral_L3,
            Great_Cathedral_L4,
            Forgotten_Pathway,
            Escapeway,
            Iron_Maiden_B1,
            Iron_Maiden_B2,
            Iron_Maiden_B3,
            Undercity_West = 19,
            Undercity_East,
            The_Keep,
            City_Walls_West,
            City_Walls_South,
            City_Walls_East,
            City_Walls_North,
            Snowfly_Forest,
            Snowfly_Forest_East,
            Town_Center_West,
            Town_Center_South,
            Town_Center_East
        }
    }

}
