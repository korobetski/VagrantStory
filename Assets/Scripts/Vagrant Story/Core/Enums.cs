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
            Buckler_Shield = 1,
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
    }

}
