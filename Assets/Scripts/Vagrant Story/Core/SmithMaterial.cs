namespace VagrantStory.Core
{

    public class SmithMaterial
    {
        // Bois - Cuir - Etain - Fer - Hagane - Argent - Damascus
        public string name = "";
        public Enums.eMaterial type;
        public Statistics statistics;
        public short DP = 0;



        private Enums.eMaterial[] types = { Enums.eMaterial.NONE, Enums.eMaterial.WOOD, Enums.eMaterial.LEATHER, Enums.eMaterial.BRONZE,
            Enums.eMaterial.IRON, Enums.eMaterial.HAGANE, Enums.eMaterial.SILVER, Enums.eMaterial.DAMASCUS };

        public SmithMaterial(string na, byte t, short _h, short _b, short _u, short _p, short _d, short _e, short _phy, short _ai, short _fi, short _ea, short _wa, short _li, short _da, short _str, short _int, short _agi, short _dp)
        {
            name = na;
            type = types[t];
            statistics = new Statistics();

            statistics.HUMAN.value = _h;
            statistics.BEAST.value = _b;
            statistics.UNDEAD.value = _u;
            statistics.PHANTOM.value = _p;
            statistics.DRAGON.value = _d;
            statistics.EVIL.value = _e;
            statistics.PHYSICAL.value = _phy;
            statistics.AIR.value = _ai;
            statistics.FIRE.value = _fi;
            statistics.EARTH.value = _ea;
            statistics.WATER.value = _wa;
            statistics.LIGHT.value = _li;
            statistics.DARK.value = _da;
            statistics.STR.value = _str;
            statistics.INT.value = _int;
            statistics.AGI.value = _agi;
            DP = _dp;
        }
    }
}

