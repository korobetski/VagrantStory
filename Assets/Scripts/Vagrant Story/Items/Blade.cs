using VagrantStory.Core;
using VagrantStory.Database;

namespace VagrantStory.Items
{
    public class Blade : Item
    {
        public Enums.eBladeCategory bladeType;
        public Enums.eMaterial material;
        public Enums.eDamageType damageType; // Main damage type
        public Statistics statistics;
        public byte id;
        public byte wepID; // 3d model ref
        public byte range;
        public byte risk;


        private Enums.eBladeCategory[] bladeTypes = { Enums.eBladeCategory.NONE, Enums.eBladeCategory.DAGGER, Enums.eBladeCategory.SWORD, Enums.eBladeCategory.GREAT_SWORD, Enums.eBladeCategory.AXE,
            Enums.eBladeCategory.MACE, Enums.eBladeCategory.GREAT_AXE, Enums.eBladeCategory.STAFF, Enums.eBladeCategory.HEAVY_MACE, Enums.eBladeCategory.POLEARM, Enums.eBladeCategory.CROSSBOW };
        private Enums.eDamageType[] damageTypes = { Enums.eDamageType.NONE, Enums.eDamageType.BLUNT, Enums.eDamageType.EDGED, Enums.eDamageType.PIERCING };

        public Blade(Enums.eBladeCategory t)
        {
            bladeType = t;
            statistics = new Statistics();
        }

        public Blade(string na, string desc, byte id, byte wep, byte type, byte damtyp, byte risk, short str, short inte, short agi, byte range, byte damage)
        {
            bladeType = bladeTypes[type];
            statistics = new Statistics();

            name = na;
            description = desc;
            this.id = id;
            wepID = wep;
            damageType = damageTypes[damtyp];
            this.risk = risk;

            statistics.STR.value = str;
            statistics.INT.value = inte;
            statistics.AGI.value = agi;

            this.range = range;

        }
    }
}