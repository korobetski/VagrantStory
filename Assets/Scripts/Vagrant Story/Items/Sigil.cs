namespace VagrantStory.Items
{
    public class Sigil : Key
    {
        // Sigil is an auto desctructible key (one time usage)
        public Sigil(uint id, string name = "Key") : base(id, name)
        {
            stackable = false;
            quantity = 1;
            isSigil = true;
            lockId = id;
            this.name = name;
        }
    }
}