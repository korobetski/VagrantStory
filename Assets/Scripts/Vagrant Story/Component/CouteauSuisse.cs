using MyBox;
using System;
using System.Collections.Generic;
using UnityEngine;
using Utils;
using VagrantStory.Core;
using VagrantStory.Database;
using VagrantStory.Items;

namespace VagrantStory.Component
{

    public class CouteauSuisse : MonoBehaviour
    {

        public Enums.eMaterial material = Enums.eMaterial.BRONZE;
        [Separator("Blade")]
        public Enums.eBladeCategory category = Enums.eBladeCategory.SWORD;
        [ConditionalField(nameof(category), false, Enums.eBladeCategory.DAGGER)] public Enums.eDaggerBlade dagger = Enums.eDaggerBlade.None;
        [ConditionalField(nameof(category), false, Enums.eBladeCategory.SWORD)] public Enums.eSwordBlade sword = Enums.eSwordBlade.None;
        [ConditionalField(nameof(category), false, Enums.eBladeCategory.GREAT_SWORD)] public Enums.eGreatSwordBlade greatSword = Enums.eGreatSwordBlade.None;
        [ConditionalField(nameof(category), false, Enums.eBladeCategory.AXE)] public Enums.eAxeBlade axe = Enums.eAxeBlade.None;
        [ConditionalField(nameof(category), false, Enums.eBladeCategory.MACE)] public Enums.eMaceBlade mace = Enums.eMaceBlade.None;
        [ConditionalField(nameof(category), false, Enums.eBladeCategory.GREAT_AXE)] public Enums.eGreatAxeBlade greatAxe = Enums.eGreatAxeBlade.None;
        [ConditionalField(nameof(category), false, Enums.eBladeCategory.STAFF)] public Enums.eStaffBlade staff = Enums.eStaffBlade.None;
        [ConditionalField(nameof(category), false, Enums.eBladeCategory.HEAVY_MACE)] public Enums.eHeavyMaceBlade heavyMace = Enums.eHeavyMaceBlade.None;
        [ConditionalField(nameof(category), false, Enums.eBladeCategory.POLEARM)] public Enums.ePolearmBlade polearm = Enums.ePolearmBlade.None;
        [ConditionalField(nameof(category), false, Enums.eBladeCategory.CROSSBOW)] public Enums.eCrossbowBlade crossbow = Enums.eCrossbowBlade.None;
        [ConditionalField(nameof(category), false, Enums.eBladeCategory.SHIELD)] public Enums.eShield shield = Enums.eShield.None;
        private ushort _bladeId = 0;

        [Separator("Grip")]
        [ReadOnly] public Enums.eGripCategory gripType = Enums.eGripCategory.Guard;
        [ConditionalField(nameof(gripType), false, Enums.eGripCategory.Guard)] public Enums.eGuard guard = Enums.eGuard.None;
        [ConditionalField(nameof(gripType), false, Enums.eGripCategory.Grip)] public Enums.eGrip grip = Enums.eGrip.None;
        [ConditionalField(nameof(gripType), false, Enums.eGripCategory.Pole)] public Enums.ePole pole = Enums.ePole.None;
        [ConditionalField(nameof(gripType), false, Enums.eGripCategory.Bolt)] public Enums.eBolt bolt = Enums.eBolt.None;
        private ushort _gripId = 0;

        [Separator("Gems")]
        [ReadOnly] public uint gemSlot = 0;
        [HideInInspector] public bool gemSlot1 = false;
        [HideInInspector] public bool gemSlot2 = false;
        [HideInInspector] public bool gemSlot3 = false;
        [ConditionalField(nameof(gemSlot1))] public Enums.eGem gem1 = Enums.eGem.None;
        [ConditionalField(nameof(gemSlot2))] public Enums.eGem gem2 = Enums.eGem.None;
        [ConditionalField(nameof(gemSlot3))] public Enums.eGem gem3 = Enums.eGem.None;


        [Separator("Statistics")]
        public byte PP = 100;
        public byte DP = 100;
        [ReadOnly] public Statistics statistics;



        private byte _modelId = 0;
        private int _material = 0;
        private GameObject _wepPrefab;

        private void Start()
        {
            OnValidate();
        }


        private void OnValidate()
        {
            bool reloadModel = false;

            statistics = new Statistics();
            if (material != Enums.eMaterial.NONE)
            {
                statistics += MaterialsDB.List[(int)material].statistics;
                if (_material != (int)material)
                {
                    reloadModel = true;
                }

                _material = (int)material;
            }

            if (category == Enums.eBladeCategory.DAGGER && dagger != Enums.eDaggerBlade.None)
            {
                _bladeId = (ushort)dagger;
            }
            else if (category == Enums.eBladeCategory.SWORD && sword != Enums.eSwordBlade.None)
            {
                _bladeId = (ushort)sword;
            }
            else if (category == Enums.eBladeCategory.GREAT_SWORD && greatSword != Enums.eGreatSwordBlade.None)
            {
                _bladeId = (ushort)greatSword;
            }
            else if (category == Enums.eBladeCategory.AXE && axe != Enums.eAxeBlade.None)
            {
                _bladeId = (ushort)axe;
            }
            else if (category == Enums.eBladeCategory.MACE && mace != Enums.eMaceBlade.None)
            {
                _bladeId = (ushort)mace;
            }
            else if (category == Enums.eBladeCategory.GREAT_AXE && greatAxe != Enums.eGreatAxeBlade.None)
            {
                _bladeId = (ushort)greatAxe;
            }
            else if (category == Enums.eBladeCategory.STAFF && staff != Enums.eStaffBlade.None)
            {
                _bladeId = (ushort)staff;
            }
            else if (category == Enums.eBladeCategory.HEAVY_MACE && heavyMace != Enums.eHeavyMaceBlade.None)
            {
                _bladeId = (ushort)heavyMace;
            }
            else if (category == Enums.eBladeCategory.POLEARM && polearm != Enums.ePolearmBlade.None)
            {
                _bladeId = (ushort)polearm;
            }
            else if (category == Enums.eBladeCategory.CROSSBOW && crossbow != Enums.eCrossbowBlade.None)
            {
                _bladeId = (ushort)crossbow;
            }
            else if (category == Enums.eBladeCategory.SHIELD && shield != Enums.eShield.None)
            {
                _bladeId = (ushort)shield;
            }

            if (category != Enums.eBladeCategory.SHIELD)
            {
                if (_bladeId > 0)
                {
                    statistics += BladesDB.List[_bladeId].statistics;
                    if (_modelId != BladesDB.List[_bladeId].wepID)
                    {
                        _modelId = BladesDB.List[_bladeId].wepID;
                        reloadModel = true;
                    }
                }
            } else
            {
                if (_bladeId > 0) statistics += ArmorsDB.ShieldList[_bladeId - 90].statistics;
                if (_modelId != ArmorsDB.ShieldList[_bladeId - 90].wepID)
                {
                    _modelId = ArmorsDB.ShieldList[_bladeId - 90].wepID;
                    reloadModel = true;
                }
            }

            if (category == Enums.eBladeCategory.DAGGER || category == Enums.eBladeCategory.SWORD || category == Enums.eBladeCategory.GREAT_SWORD)
            {
                gripType = Enums.eGripCategory.Guard;
                grip = Enums.eGrip.None;
                pole = Enums.ePole.None;
                bolt = Enums.eBolt.None;

                if (guard != Enums.eGuard.None)
                {
                    _gripId = (ushort)guard;
                    gemSlot = GripsDB.List[_gripId].gemSlots;
                    statistics += GripsDB.List[_gripId].statistics;
                }
                else
                {
                    gemSlot = 0;
                }

                RefreshGemSlots();
            }
            else if (category == Enums.eBladeCategory.AXE || category == Enums.eBladeCategory.MACE || category == Enums.eBladeCategory.GREAT_AXE
                || category == Enums.eBladeCategory.STAFF || category == Enums.eBladeCategory.HEAVY_MACE)
            {
                gripType = Enums.eGripCategory.Grip;
                guard = Enums.eGuard.None;
                pole = Enums.ePole.None;
                bolt = Enums.eBolt.None;
                if (grip != Enums.eGrip.None)
                {
                    _gripId = (ushort)grip;
                    gemSlot = GripsDB.List[_gripId].gemSlots;
                    statistics += GripsDB.List[_gripId].statistics;
                }
                else
                {
                    gemSlot = 0;
                }

                RefreshGemSlots();
            }
            else if (category == Enums.eBladeCategory.POLEARM)
            {
                gripType = Enums.eGripCategory.Pole;
                guard = Enums.eGuard.None;
                grip = Enums.eGrip.None;
                bolt = Enums.eBolt.None;
                if (pole != Enums.ePole.None)
                {
                    _gripId = (ushort)pole;
                    gemSlot = GripsDB.List[_gripId].gemSlots;
                    statistics += GripsDB.List[_gripId].statistics;
                }
                else
                {
                    gemSlot = 0;
                }

                RefreshGemSlots();
            }
            else if (category == Enums.eBladeCategory.CROSSBOW)
            {
                gripType = Enums.eGripCategory.Bolt;
                guard = Enums.eGuard.None;
                grip = Enums.eGrip.None;
                pole = Enums.ePole.None;
                if (bolt != Enums.eBolt.None)
                {
                    _gripId = (ushort)bolt;
                    gemSlot = GripsDB.List[_gripId].gemSlots;
                    statistics += GripsDB.List[_gripId].statistics;
                }
                else
                {
                    gemSlot = 0;
                }

                RefreshGemSlots();
            }
            else if (category == Enums.eBladeCategory.SHIELD)
            {
                // shields have no grip, but have gem slots
                _gripId = 0;
                gripType = Enums.eGripCategory.None;
                guard = Enums.eGuard.None;
                grip = Enums.eGrip.None;
                pole = Enums.ePole.None;
                bolt = Enums.eBolt.None;

                if (shield != Enums.eShield.None)
                {
                    gemSlot = ArmorsDB.ShieldList[(int)shield - 90].gemSlots;
                }
                else
                {
                    gemSlot = 0;
                }

                RefreshGemSlots();
            }
            else
            {
                _gripId = 0;
                gripType = Enums.eGripCategory.None;
                guard = Enums.eGuard.None;
                grip = Enums.eGrip.None;
                pole = Enums.ePole.None;
                bolt = Enums.eBolt.None;
                gemSlot = 0;
                RefreshGemSlots();
            }

            if (reloadModel)
            {
                //LoadWEPModel(_modelId);
            }
        }

        public Weapon weapon
        {
            get
            {
                OnValidate();
                List<Gem> gems = new List<Gem>();
                if (gem1 != Enums.eGem.None) gems.Add(GemsDB.List[(int)gem1]);
                if (gem2 != Enums.eGem.None) gems.Add(GemsDB.List[(int)gem2]);
                if (gem3 != Enums.eGem.None) gems.Add(GemsDB.List[(int)gem3]);
                //  public static Weapon Fandango = new Weapon("Fandango", Enums.eMaterial.BRONZE, BladesDB.Scimitar, GripsDB.Short_Hilt, 126, 136);

                if (_bladeId != 0)
                {
                    if (category == Enums.eBladeCategory.SHIELD)
                    {
                        return new Weapon("shield", material, ArmorsDB.ShieldList[_bladeId - 90], DP, PP, gems);
                    }
                    else
                    {
                        return new Weapon("weapon", material, BladesDB.List[_bladeId], GripsDB.List[_gripId], DP, PP, gems);
                    }
                }

                return null;
            }
            set
            {
                Weapon weap = value;
                SetBlade(weap.blade);
                material = weap.blade.material;
                if (weap.gems.Count > 0) gem1 = (Enums.eGem)GemsDB.List.IndexOfItem<Gem>(weap.gems[0]);
                if (weap.gems.Count > 1) gem2 = (Enums.eGem)GemsDB.List.IndexOfItem<Gem>(weap.gems[1]);
                if (weap.gems.Count > 2) gem3 = (Enums.eGem)GemsDB.List.IndexOfItem<Gem>(weap.gems[2]);
            }
        }

        private void SetBlade(Blade blade)
        {
            _bladeId = blade.id;
            category = blade.bladeType;

            if (category == Enums.eBladeCategory.DAGGER)
            {
                dagger = (Enums.eDaggerBlade)_bladeId;
            }
            else if (category == Enums.eBladeCategory.SWORD)
            {
                sword = (Enums.eSwordBlade)_bladeId;
            }
            else if (category == Enums.eBladeCategory.GREAT_SWORD)
            {
                greatSword = (Enums.eGreatSwordBlade)_bladeId;
            }
            else if (category == Enums.eBladeCategory.AXE)
            {
                axe = (Enums.eAxeBlade)_bladeId;
            }
            else if (category == Enums.eBladeCategory.MACE)
            {
                mace = (Enums.eMaceBlade)_bladeId;
            }
            else if (category == Enums.eBladeCategory.GREAT_AXE)
            {
                greatAxe = (Enums.eGreatAxeBlade)_bladeId;
            }
            else if (category == Enums.eBladeCategory.STAFF)
            {
                staff = (Enums.eStaffBlade)_bladeId;
            }
            else if (category == Enums.eBladeCategory.HEAVY_MACE)
            {
                heavyMace = (Enums.eHeavyMaceBlade)_bladeId;
            }
            else if (category == Enums.eBladeCategory.POLEARM)
            {
                polearm = (Enums.ePolearmBlade)_bladeId;
            }
            else if (category == Enums.eBladeCategory.CROSSBOW && crossbow != Enums.eCrossbowBlade.None)
            {
                crossbow = (Enums.eCrossbowBlade)_bladeId;
            }
            else if (category == Enums.eBladeCategory.SHIELD && shield != Enums.eShield.None)
            {
                shield = (Enums.eShield)_bladeId;
            }
        }

        private void LoadWEPModel(byte wepId)
        {
            ToolBox.DestroyChildren(gameObject, true);

            string wepPath = string.Concat("Prefabs/Weapons/", BitConverter.ToString(new byte[] { wepId }));
            _wepPrefab = Instantiate(Resources.Load(wepPath)) as GameObject;
            _wepPrefab.transform.parent = gameObject.transform;

            Vector2[] offsets = new Vector2[8] { Vector2.zero, Vector2.zero, new Vector2(0, 0.25f), new Vector2(0, 0.5f), new Vector2(0, 0.75f),
                new Vector2(0.5f, 0.25f), new Vector2(0.5f, 0.5f), new Vector2(0.5f, 0.75f) };
            // need to check ingame textures to fit

            _wepPrefab.GetComponent<MeshRenderer>().sharedMaterial.SetTextureOffset("_MainTex", offsets[(int)material]);
        }

        private void RefreshGemSlots()
        {
            gemSlot1 = (gemSlot > 0);
            gemSlot2 = (gemSlot > 1);
            gemSlot3 = (gemSlot > 2);

            if (!gemSlot1)
            {
                gem1 = Enums.eGem.None;
            }
            else
            {
                if (gem1 != Enums.eGem.None)
                {
                    statistics += GemsDB.List[(int)gem1].statistics;
                }
            }

            if (!gemSlot2)
            {
                gem2 = Enums.eGem.None;
            }
            else
            {
                if (gem2 != Enums.eGem.None)
                {
                    statistics += GemsDB.List[(int)gem2].statistics;
                }
            }

            if (!gemSlot3)
            {
                gem3 = Enums.eGem.None;
            }
            else
            {
                if (gem3 != Enums.eGem.None)
                {
                    statistics += GemsDB.List[(int)gem3].statistics;
                }
            }
        }
    }

}
