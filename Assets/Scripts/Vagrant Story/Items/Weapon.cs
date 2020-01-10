using System;
using System.Collections.Generic;
using UnityEngine;
using VagrantStory.Core;
using VagrantStory.Database;

namespace VagrantStory.Items
{

    public class Weapon : Item
    {
        public Blade blade;
        public Grip grip;
        public List<Gem> gems;
        public Statistics statistics;
        public ushort DP = 0;
        public ushort MaxDP = 0;
        public ushort PP = 0;
        public ushort MaxPP = 0;

        public Weapon(string _name, Enums.eMaterial material, Blade _blade, Grip _grip, ushort _dp = 100, ushort _pp = 100, List<Gem> _gems = null)
        {
            gems = new List<Gem>();
            name = _name;
            blade = _blade;
            grip = _grip;

            MaxDP = _dp;
            DP = _dp;
            MaxPP = _pp;
            PP = 0;
            blade.SetMaterial(material);
        }

        public Weapon(string _name, Enums.eMaterial material, Armor _shield, ushort _dp = 100, ushort _pp = 100, List<Gem> _gems = null)
        {
            gems = new List<Gem>();
            name = _name;
            blade = new Blade(Enums.eBladeCategory.SHIELD);
            blade.wepID = _shield.wepID;
            blade.SetMaterial(material);
            grip = GripsDB.List[0]; // null :D
            MaxDP = _dp;
            DP = _dp;
            MaxPP = _pp;
            PP = 0;
        }

        public GameObject GameObject
        {
            get
            {
                string wepPath = string.Concat("Prefabs/Weapons/", BitConverter.ToString(new byte[] { blade.wepID }));
                //Debug.Log(string.Concat("Instantiate : ", wepPath));
                return GameObject.Instantiate<GameObject>(Resources.Load<GameObject>(wepPath));
            }
        }

        public void SetMaterial(Enums.eMaterial mat)
        {
            blade.SetMaterial(mat);
            RefreshStats();
        }

        public void RefreshStats()
        {

            statistics = new Statistics();
            statistics += blade.statistics;
            statistics += grip.statistics;
            foreach (Gem gem in gems)
            {
                statistics += gem.statistics;
            }

        }
    }

}