namespace VagrantStory.Items
{

    public class Key : Item
    {
        public uint lockId = 0; // the Key lockId must match with the Door lockId to unlock a Door.
        public bool isSigil = false;
        public Key(uint id, string name = "Key")
        {
            stackable = false;
            quantity = 1;

            lockId = id;
            this.name = name;
        }
    }
}
