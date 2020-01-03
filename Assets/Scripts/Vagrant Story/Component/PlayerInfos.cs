using MyBox;
using System;
using System.Collections.Generic;
using UnityEngine;
using VagrantStory.Component;
using VagrantStory.Core;
using VagrantStory.Database;
using VagrantStory.Items;



namespace VagrantStory.Component
{
    public class PlayerInfos : MonoBehaviour
    {
        [Separator("Jauges")]
        public ushort HP = 250;
        public ushort MaxHP = 250;
        public ushort MP = 100;
        public ushort MaxMP = 100;
        public ushort Risk = 0;
        public ushort MaxRisk = 100;

        [Separator("Current Map")]
        public string Map = "Map009";

        // Equipement HELM, ARMOR, GLOVE, BOOTS, ACCESSORY

        [Separator("Equipement")]
        public Enums.eHelm Helm;
        public Enums.eArmor BodyArmor;
        public Enums.eGlove LeftGlove;
        public Enums.eGlove RightGlove;
        public Enums.eBoots Boots;
        public Enums.eAccessory Accessory;
        public Weapon MainHand;
        public Weapon OffHand; // only shields can be off handed in Vagrant Story

        public bool BattleMode = false;
        public Transform WeaponRootTransfrom;
        public Transform ShieldRootTransfrom;

        // Body status
        [Separator("Health Status")]
        public Enums.eBodyPartStatus HeadStatus = Enums.eBodyPartStatus.Excellent;
        public Enums.eBodyPartStatus BodyStatus = Enums.eBodyPartStatus.Excellent;
        public Enums.eBodyPartStatus RightArmStatus = Enums.eBodyPartStatus.Excellent;
        public Enums.eBodyPartStatus LeftArmStatus = Enums.eBodyPartStatus.Excellent;
        public Enums.eBodyPartStatus LegsStatus = Enums.eBodyPartStatus.Excellent;

        [Separator("Other")]
        public List<Item> Inventory;
        public List<Spell> Spells;
        public List<BreakArt> BreakArts;
        public List<CombatTech> CombatTechs;



        private GameObject weaponGO;
        private GameObject shieldGO;


        private Animator animator;
        private CouteauSuisse _weaponManager;
        private CouteauSuisse _shieldManager;
        // Start is called before the first frame update
        public void Start()
        {
            animator = GetComponent<Animator>();
            CouteauSuisse[] managers = GetComponents<CouteauSuisse>();
            _weaponManager = managers[0];
            _shieldManager = managers[1];

            Inventory = new List<Item>();
            Spells = new List<Spell>();
            BreakArts = new List<BreakArt>();
            CombatTechs = new List<CombatTech>();

            // new game equipements
            Helm = Enums.eHelm.Bandana;
            BodyArmor = Enums.eArmor.Jerkin;
            LeftGlove = Enums.eGlove.Buffle;
            RightGlove = Enums.eGlove.Buffle;
            Boots = Enums.eBoots.Bandage;
            Accessory = Enums.eAccessory.Rood_Necklace;


            //_weaponManager.weapon = WeaponDB.Fandango;
            //_shieldManager.weapon = WeaponDB.Fandango;
            MainHand = _weaponManager.weapon;
            OffHand = _shieldManager.weapon;
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetButtonDown("Weapon Switch"))
            {
                BattleMode = !BattleMode;
                if (BattleMode)
                {
                    BattleModeOn();
                }
                else
                {
                    BattleModeOff();
                }
            }
        }

        public void BattleModeOn()
        {
            weaponGO = MainHand.GameObject;
            weaponGO.transform.parent = WeaponRootTransfrom;
            weaponGO.transform.localPosition = Vector3.zero;
            weaponGO.transform.localRotation = Quaternion.Euler(0, 0, 0);
            weaponGO.transform.localScale = Vector3.one;
            if (OffHand != null)
            {
                shieldGO = OffHand.GameObject;
                shieldGO.transform.parent = ShieldRootTransfrom;
                shieldGO.transform.localPosition = Vector3.zero;
                shieldGO.transform.localRotation = Quaternion.Euler(0, 0, 0);
                shieldGO.transform.localScale = Vector3.one;
            }
            animator.SetInteger("Weapon Type", (int)MainHand.blade.bladeType);
            animator.SetLayerWeight(0, 0f);
            animator.SetLayerWeight((int)MainHand.blade.bladeType, 1f);

        }

        public void BattleModeOff()
        {
            Destroy(weaponGO);
            if (OffHand != null) Destroy(shieldGO);
            animator.SetInteger("Weapon Type", 0);
            animator.SetLayerWeight(0, 1f);
            animator.SetLayerWeight((int)MainHand.blade.bladeType, 0f);
        }

    }


}