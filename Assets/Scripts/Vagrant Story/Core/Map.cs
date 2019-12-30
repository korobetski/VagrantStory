namespace VagrantStory.Core
{

    public class Map
    {
        public uint ZNDId = 0; // ref to .ZND
        public uint MPDId = 0; // ref to .MPD
        public uint mapId = 0; // relative to the ZND
        public Enums.eZone zone = Enums.eZone.None;
        public string name = "";
        /*
         * All of things to do here :
         * Exits, Doors (lock, keys, etc...)
         * Monsters
         * Chests
         * Traps
         * Save Point ? Container ?
         * Workshop ? (available smithing materials)
         */

        public Map(uint znd, uint mpd, uint map, Enums.eZone zo, string na)
        {
            ZNDId = znd;
            MPDId = mpd;
            mapId = map;
            zone = zo;
            name = na;
        }
    }
}