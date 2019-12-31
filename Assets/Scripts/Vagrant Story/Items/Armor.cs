using VagrantStory.Core;
using VagrantStory.Database;

namespace VagrantStory.Items
{

    [System.Serializable]
    public class Armor : Item
    {

        public Enums.eArmorCategory category;
        public Enums.eMaterial material = Enums.eMaterial.NONE;
        public Statistics statistics;
        public byte id;
        public byte wepID; // only usefull for shields
        public byte gemSlots = 0; // only usefull for shields


        private Enums.eArmorCategory[] armorTypes = { Enums.eArmorCategory.NONE, Enums.eArmorCategory.SHIELD, Enums.eArmorCategory.HELM, Enums.eArmorCategory.ARMOR, Enums.eArmorCategory.GLOVE, Enums.eArmorCategory.BOOTS, Enums.eArmorCategory.ACCESSORY };

        public Armor(string na, string desc, byte id, byte wepid, byte type, byte gs = 0)
        {
            category = armorTypes[type];
            statistics = new Statistics();
            SetMaterial(Enums.eMaterial.LEATHER);
            name = na;
            description = desc;
            this.id = id;
            wepID = wepid;
            gemSlots = gs;
        }

        public Armor(string na, string desc, byte id, byte wepid, byte type, short str, short inte, short agi, byte gs = 0)
        {
            category = armorTypes[type];
            statistics = new Statistics();
            SetMaterial(Enums.eMaterial.LEATHER);
            name = na;
            description = desc;
            this.id = id;
            wepID = wepid;

            statistics.STR.value = str;
            statistics.INT.value = inte;
            statistics.AGI.value = agi;
            gemSlots = gs;
        }

        public void SetMaterial(Enums.eMaterial mat)
        {
            if (material != Enums.eMaterial.NONE)
            {
                statistics -= MaterialsDB.List[(int)material].statistics;
            }

            material = mat;
            statistics += MaterialsDB.List[(int)mat].statistics;
        }

    }
}