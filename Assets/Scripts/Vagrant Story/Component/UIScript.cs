using UnityEngine;
using UnityEngine.UI;
using VagrantStory.Component;

namespace VagrantStory.Core
{

    public class UIScript : MonoBehaviour
    {

        public PlayerInfos playerInfos;


        public Sprite ExcellentHead;
        public Sprite ExcellentBody;
        public Sprite ExcellentBatModeRightArm;
        public Sprite ExcellentBatModeLeftArm;
        public Sprite ExcellentComModeRightArm;
        public Sprite ExcellentComModeLeftArm;
        public Sprite ExcellentLegs;

        public Sprite WellHead;
        public Sprite WellBody;
        public Sprite WellBatModeRightArm;
        public Sprite WellBatModeLeftArm;
        public Sprite WellComModeRightArm;
        public Sprite WellComModeLeftArm;
        public Sprite WellLegs;

        public Sprite AverageHead;
        public Sprite AverageBody;
        public Sprite AverageBatModeRightArm;
        public Sprite AverageBatModeLeftArm;
        public Sprite AverageComModeRightArm;
        public Sprite AverageComModeLeftArm;
        public Sprite AverageLegs;

        public Sprite BadHead;
        public Sprite BadBody;
        public Sprite BadBatModeRightArm;
        public Sprite BadBatModeLeftArm;
        public Sprite BadComModeRightArm;
        public Sprite BadComModeLeftArm;
        public Sprite BadLegs;

        public Sprite DeadHead;
        public Sprite DeadBody;
        public Sprite DeadBatModeRightArm;
        public Sprite DeadBatModeLeftArm;
        public Sprite DeadComModeRightArm;
        public Sprite DeadComModeLeftArm;
        public Sprite DeadLegs;


        private Slider uiHP;
        private Slider uiMP;
        //public Slider uiRisk;

        private GameObject _head;
        private GameObject _body;
        private GameObject _rightArm;
        private GameObject _leftArm;
        private GameObject _legs;


        private bool _paused = false;
        private GameObject _menu;

        // Start is called before the first frame update
        void Start()
        {
            uiHP = GameObject.Find("SliderHP").GetComponent<Slider>();
            uiMP = GameObject.Find("SliderMP").GetComponent<Slider>();

            uiHP.maxValue = playerInfos.MaxHP;
            uiMP.maxValue = playerInfos.MaxMP;

            _head = GameObject.Find("body_status_head");
            _body = GameObject.Find("body_status_body");
            _rightArm = GameObject.Find("body_status_right_arm");
            _leftArm = GameObject.Find("body_status_left_arm");
            _legs = GameObject.Find("body_status_legs");
        }

        // Update is called once per frame
        void Update()
        {
            uiHP.value = playerInfos.HP;
            uiMP.value = playerInfos.MP;

            Sprite BatModeRightArm = null;
            Sprite BatModeLeftArm = null;
            Sprite ComModeRightArm = null;
            Sprite ComModeLeftArm = null;

            switch (playerInfos.HeadStatus)
            {
                case Enums.eBodyPartStatus.Excellent:
                    _head.GetComponent<SpriteRenderer>().sprite = ExcellentHead;
                    break;
                case Enums.eBodyPartStatus.Good:
                    _head.GetComponent<SpriteRenderer>().sprite = WellHead;
                    break;
                case Enums.eBodyPartStatus.Average:
                    _head.GetComponent<SpriteRenderer>().sprite = AverageHead;
                    break;
                case Enums.eBodyPartStatus.Bad:
                    _head.GetComponent<SpriteRenderer>().sprite = BadHead;
                    break;
                case Enums.eBodyPartStatus.Dying:
                    _head.GetComponent<SpriteRenderer>().sprite = DeadHead;
                    break;
            }

            switch (playerInfos.BodyStatus)
            {
                case Enums.eBodyPartStatus.Excellent:
                    _body.GetComponent<SpriteRenderer>().sprite = ExcellentBody;
                    break;
                case Enums.eBodyPartStatus.Good:
                    _body.GetComponent<SpriteRenderer>().sprite = WellBody;
                    break;
                case Enums.eBodyPartStatus.Average:
                    _body.GetComponent<SpriteRenderer>().sprite = AverageBody;
                    break;
                case Enums.eBodyPartStatus.Bad:
                    _body.GetComponent<SpriteRenderer>().sprite = BadBody;
                    break;
                case Enums.eBodyPartStatus.Dying:
                    _body.GetComponent<SpriteRenderer>().sprite = DeadBody;
                    break;
            }

            switch (playerInfos.RightArmStatus)
            {
                case Enums.eBodyPartStatus.Excellent:
                    BatModeRightArm = ExcellentBatModeRightArm;
                    ComModeRightArm = ExcellentComModeRightArm;
                    break;
                case Enums.eBodyPartStatus.Good:
                    BatModeRightArm = WellBatModeRightArm;
                    ComModeRightArm = WellComModeRightArm;
                    break;
                case Enums.eBodyPartStatus.Average:
                    BatModeRightArm = AverageBatModeRightArm;
                    ComModeRightArm = AverageComModeRightArm;
                    break;
                case Enums.eBodyPartStatus.Bad:
                    BatModeRightArm = BadBatModeRightArm;
                    ComModeRightArm = BadComModeRightArm;
                    break;
                case Enums.eBodyPartStatus.Dying:
                    BatModeRightArm = DeadBatModeRightArm;
                    ComModeRightArm = DeadComModeRightArm;
                    break;
            }

            switch (playerInfos.LeftArmStatus)
            {
                case Enums.eBodyPartStatus.Excellent:
                    BatModeLeftArm = ExcellentBatModeLeftArm;
                    ComModeLeftArm = ExcellentComModeLeftArm;
                    break;
                case Enums.eBodyPartStatus.Good:
                    BatModeLeftArm = WellBatModeLeftArm;
                    ComModeLeftArm = WellComModeLeftArm;
                    break;
                case Enums.eBodyPartStatus.Average:
                    BatModeLeftArm = AverageBatModeLeftArm;
                    ComModeLeftArm = AverageComModeLeftArm;
                    break;
                case Enums.eBodyPartStatus.Bad:
                    BatModeLeftArm = BadBatModeLeftArm;
                    ComModeLeftArm = BadComModeLeftArm;
                    break;
                case Enums.eBodyPartStatus.Dying:
                    BatModeLeftArm = DeadBatModeLeftArm;
                    ComModeLeftArm = DeadComModeLeftArm;
                    break;
            }

            switch (playerInfos.LegsStatus)
            {
                case Enums.eBodyPartStatus.Excellent:
                    _legs.GetComponent<SpriteRenderer>().sprite = ExcellentLegs;
                    break;
                case Enums.eBodyPartStatus.Good:
                    _legs.GetComponent<SpriteRenderer>().sprite = WellLegs;
                    break;
                case Enums.eBodyPartStatus.Average:
                    _legs.GetComponent<SpriteRenderer>().sprite = AverageLegs;
                    break;
                case Enums.eBodyPartStatus.Bad:
                    _legs.GetComponent<SpriteRenderer>().sprite = BadLegs;
                    break;
                case Enums.eBodyPartStatus.Dying:
                    _legs.GetComponent<SpriteRenderer>().sprite = DeadLegs;
                    break;
            }


            if (playerInfos.BattleMode)
            {
                _rightArm.GetComponent<SpriteRenderer>().sprite = BatModeRightArm;
                _leftArm.GetComponent<SpriteRenderer>().sprite = BatModeLeftArm;
            }
            else
            {
                _rightArm.GetComponent<SpriteRenderer>().sprite = ComModeRightArm;
                _leftArm.GetComponent<SpriteRenderer>().sprite = ComModeLeftArm;
            }




            if (Input.GetButtonDown("Open Menu"))
            {
                _paused = toggleMenu();
            }



            if (Input.GetButtonDown("Cancel"))
            {
                toggleMenu();
            }
        }

        bool toggleMenu()
        {
            if (Time.timeScale == 0f)
            {
                if (_menu == null || GameMenuScript.openned == false)
                {
                    Time.timeScale = 1f;
                    DestroyMenu();
                    return (false);
                }
                else
                {
                    return true;
                }
            }
            else
            {
                Time.timeScale = 0f;
                OpenMenu();
                return (true);
            }


        }

        private void OpenMenu()
        {
            string menuPath = "Prefabs/GameMenu";
            _menu = Instantiate(Resources.Load(menuPath), Camera.main.transform) as GameObject;
            Canvas cnv = _menu.GetComponent<Canvas>();
            cnv.worldCamera = Camera.main;
            cnv.planeDistance = 0.5f;
            cnv.pixelPerfect = true;
        }

        private void DestroyMenu()
        {
            Destroy(_menu);
            _menu = null;
        }
    }

}