namespace VagrantStory.Core
{
    public class BreakArt
    {
        public string name = "";
        public string description = "";
        public Enums.eBladeCategory category;
        public uint cost; // HP cost of the break art
        public Enums.eAffinity[] affinities;
        public Enums.eDamageType damageType;
        public uint hits; // number of hits inflicted
        public BreakArtEffect[] effects; // side effects (numb, curse, etc..)

        public BreakArt(string na, string desc, Enums.eBladeCategory cat, uint co, Enums.eAffinity[] aff, Enums.eDamageType dt, uint hi = 1, BreakArtEffect[] eff = null)
        {
            name = na;
            description = desc;
            category = cat;
            cost = co;
            affinities = aff;
            damageType = dt;
            hits = hi;
            effects = eff;
        }
    }
}
