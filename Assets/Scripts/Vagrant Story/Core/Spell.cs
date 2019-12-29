namespace VagrantStory.Core
{
    public class Spell
    {
        public string name = "";
        public string description = "";
        public Enums.eSpellCategory category;
        public uint cost; // MP cost of the spell
        public BreakArtEffect effect;

    }
}
