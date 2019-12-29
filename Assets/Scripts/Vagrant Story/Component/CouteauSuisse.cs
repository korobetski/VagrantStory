using MyBox;
using System;
using UnityEngine;
using Utils;
using VagrantStory.Core;
using VagrantStory.Database;

namespace VagrantStory.Component
{

    public class CouteauSuisse : MonoBehaviour
    {

        public MaterialsDB.eMaterials material = MaterialsDB.eMaterials.Bronze;
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

        [Separator("Grip")]
        [ReadOnly] public Enums.eGripCategory gripType = Enums.eGripCategory.Guard;
        [ConditionalField(nameof(gripType), false, Enums.eGripCategory.Guard)] public Enums.eGuard guard = Enums.eGuard.None;
        [ConditionalField(nameof(gripType), false, Enums.eGripCategory.Grip)] public Enums.eGrip grip = Enums.eGrip.None;
        [ConditionalField(nameof(gripType), false, Enums.eGripCategory.Pole)] public Enums.ePole pole = Enums.ePole.None;
        [ConditionalField(nameof(gripType), false, Enums.eGripCategory.Bolt)] public Enums.eBolt bolt = Enums.eBolt.None;

        [Separator("Gems")]
        [ReadOnly] public uint gemSlot = 0;
        [HideInInspector] public bool gemSlot1 = false;
        [HideInInspector] public bool gemSlot2 = false;
        [HideInInspector] public bool gemSlot3 = false;
        [ConditionalField(nameof(gemSlot1))] public Enums.eGem gem1 = Enums.eGem.None;
        [ConditionalField(nameof(gemSlot2))] public Enums.eGem gem2 = Enums.eGem.None;
        [ConditionalField(nameof(gemSlot3))] public Enums.eGem gem3 = Enums.eGem.None;


        [Separator("Statistics")]
        [ReadOnly] public Statistics statistics;



        private byte _modelId = 0;
        private int _material = 0;
        private GameObject _wepPrefab;

        private void Start()
        {
        }


        private void OnValidate()
        {
            bool reloadModel = false;

            statistics = new Statistics();
            if (material != MaterialsDB.eMaterials.None)
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
                statistics += BladesDB.List[(int)dagger].statistics;
                if (_modelId != BladesDB.List[(int)dagger].wepID)
                {
                    _modelId = BladesDB.List[(int)dagger].wepID;
                    reloadModel = true;
                }
            }
            else if (category == Enums.eBladeCategory.SWORD && sword != Enums.eSwordBlade.None)
            {
                statistics += BladesDB.List[(int)sword].statistics;
                if (_modelId != BladesDB.List[(int)sword].wepID)
                {
                    _modelId = BladesDB.List[(int)sword].wepID;
                    reloadModel = true;
                }
            }
            else if (category == Enums.eBladeCategory.GREAT_SWORD && greatSword != Enums.eGreatSwordBlade.None)
            {
                statistics += BladesDB.List[(int)greatSword].statistics;
                if (_modelId != BladesDB.List[(int)greatSword].wepID)
                {
                    _modelId = BladesDB.List[(int)greatSword].wepID;
                    reloadModel = true;
                }
            }
            else if (category == Enums.eBladeCategory.AXE && axe != Enums.eAxeBlade.None)
            {
                statistics += BladesDB.List[(int)axe].statistics;
                if (_modelId != BladesDB.List[(int)axe].wepID)
                {
                    _modelId = BladesDB.List[(int)axe].wepID;
                    reloadModel = true;
                }
            }
            else if (category == Enums.eBladeCategory.MACE && mace != Enums.eMaceBlade.None)
            {
                statistics += BladesDB.List[(int)mace].statistics;
                if (_modelId != BladesDB.List[(int)mace].wepID)
                {
                    _modelId = BladesDB.List[(int)mace].wepID;
                    reloadModel = true;
                }
            }
            else if (category == Enums.eBladeCategory.GREAT_AXE && greatAxe != Enums.eGreatAxeBlade.None)
            {
                statistics += BladesDB.List[(int)greatAxe].statistics;
                if (_modelId != BladesDB.List[(int)greatAxe].wepID)
                {
                    _modelId = BladesDB.List[(int)greatAxe].wepID;
                    reloadModel = true;
                }
            }
            else if (category == Enums.eBladeCategory.STAFF && staff != Enums.eStaffBlade.None)
            {
                statistics += BladesDB.List[(int)staff].statistics;
                if (_modelId != BladesDB.List[(int)staff].wepID)
                {
                    _modelId = BladesDB.List[(int)staff].wepID;
                    reloadModel = true;
                }
            }
            else if (category == Enums.eBladeCategory.HEAVY_MACE && heavyMace != Enums.eHeavyMaceBlade.None)
            {
                statistics += BladesDB.List[(int)heavyMace].statistics;
                if (_modelId != BladesDB.List[(int)heavyMace].wepID)
                {
                    _modelId = BladesDB.List[(int)heavyMace].wepID;
                    reloadModel = true;
                }
            }
            else if (category == Enums.eBladeCategory.POLEARM && polearm != Enums.ePolearmBlade.None)
            {
                statistics += BladesDB.List[(int)polearm].statistics;
                if (_modelId != BladesDB.List[(int)polearm].wepID)
                {
                    _modelId = BladesDB.List[(int)polearm].wepID;
                    reloadModel = true;
                }
            }
            else if (category == Enums.eBladeCategory.CROSSBOW && crossbow != Enums.eCrossbowBlade.None)
            {
                statistics += BladesDB.List[(int)crossbow].statistics;
                if (_modelId != BladesDB.List[(int)crossbow].wepID)
                {
                    _modelId = BladesDB.List[(int)crossbow].wepID;
                    reloadModel = true;
                }
            }
            else if (category == Enums.eBladeCategory.SHIELD && shield != Enums.eShield.None)
            {
                statistics += ArmorsDB.ShieldList[(int)shield].statistics;
                if (_modelId != ArmorsDB.ShieldList[(int)shield].wepID)
                {
                    _modelId = ArmorsDB.ShieldList[(int)shield].wepID;
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
                    gemSlot = GripsDB.List[(int)guard].gemSlots;
                    statistics += GripsDB.List[(int)guard].statistics;
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
                    gemSlot = GripsDB.List[(int)grip].gemSlots; statistics += GripsDB.List[(int)grip].statistics;
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
                if (pole != Enums.ePole.None) { gemSlot = GripsDB.List[(int)pole].gemSlots; statistics += GripsDB.List[(int)pole].statistics; }
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
                if (bolt != Enums.eBolt.None) { gemSlot = GripsDB.List[(int)bolt].gemSlots; statistics += GripsDB.List[(int)bolt].statistics; }
                else
                {
                    gemSlot = 0;
                }

                RefreshGemSlots();
            }
            else if (category == Enums.eBladeCategory.SHIELD)
            {
                // shields have no grip, but have gem slots
                gripType = Enums.eGripCategory.None;
                guard = Enums.eGuard.None;
                grip = Enums.eGrip.None;
                pole = Enums.ePole.None;
                bolt = Enums.eBolt.None;

                if (shield != Enums.eShield.None)
                {
                    gemSlot = ArmorsDB.ShieldList[(int)shield].gemSlots;
                }
                else
                {
                    gemSlot = 0;
                }

                RefreshGemSlots();
            }
            else
            {
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
                LoadWEPModel(_modelId);
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
