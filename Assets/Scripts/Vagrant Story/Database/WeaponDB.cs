using VagrantStory.Core;
using VagrantStory.Items;



namespace VagrantStory.Database
{
    // "Unique" weapon database (pre forged weapons)
    public class WeaponDB
    {
        public static Weapon Fandango = new Weapon("Fandango", Enums.eMaterial.BRONZE, BladesDB.Scimitar, GripsDB.Short_Hilt, 126, 136);
        public static Weapon Tovarisch = new Weapon("Tovarisch", Enums.eMaterial.BRONZE, BladesDB.Hand_Axe, GripsDB.Wooden_Grip, 126, 136);
    }

}