using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using VagrantStory.Database;

namespace VagrantStory.Component
{
    public class GameMenuScript : MonoBehaviour
    {
        public GameObject container;
        public string[] itemNames = new string[] { "Magic", "Combat Technics", "Items", "Status", "Map", "Datas", "Options", "Score", "Tutorial", "Quit" };
        public UnityAction[] menuFunction = new UnityAction[] { ToggleMagicMenu, ToggleTechMenu, ToggleItemsMenu, ToggleStatusMenu, ToggleMapMenu, ToggleDatasMenu, ToggleOptionsMenu, ToggleScoreMenu, ToggleTutorialMenu, Exit };


        public static bool openned = false;

        private static GameObject _menu;

        public static void ToggleMagicMenu()
        {
            Debug.Log("ToggleMagicMenu");
        }

        public static void ToggleTechMenu()
        {
            Debug.Log("ToggleTechMenu");
        }

        public static void ToggleItemsMenu()
        {
            if (_menu != null)
            {
                DestroyMenu();
            }
            string menuPath = "Prefabs/EquipementUI";
            _menu = Instantiate(Resources.Load(menuPath), Camera.main.transform) as GameObject;
            Canvas cnv = _menu.GetComponent<Canvas>();
            cnv.worldCamera = Camera.main;
            cnv.planeDistance = 0.5f;
            cnv.pixelPerfect = true;
            openned = true;

            PlayerInfos ps = _menu.GetComponentInChildren<PlayerInfos>();
            ps.MainHand = WeaponDB.Fandango;
            ps.Start();
            ps.BattleModeOn();
        }

        public static void DestroyMenu()
        {
            openned = false;
            Destroy(_menu);
        }

        public static void ToggleStatusMenu()
        {
            Debug.Log("ToggleStatusMenu");
        }

        public static void ToggleMapMenu()
        {
            Debug.Log("ToggleMapMenu");
        }

        public static void ToggleDatasMenu()
        {
            Debug.Log("ToggleDatasMenu");
        }

        public static void ToggleOptionsMenu()
        {
            Debug.Log("ToggleOptionsMenu");
        }

        public static void ToggleScoreMenu()
        {
            Debug.Log("ToggleScoreMenu");
        }

        public static void ToggleTutorialMenu()
        {
            Debug.Log("ToggleTutorialMenu");
        }

        public static void Exit()
        {
            Application.Quit();
        }

        // Start is called before the first frame update
        void Start()
        {
            Refresh();
        }

        // Update is called once per frame
        void Update()
        {

            if (Input.GetButtonDown("Cancel"))
            {
                DestroyMenu();
            }
        }

        public void Refresh()
        {
            if (container != null)
            {
                for (int i = 0; i < container.transform.childCount; i++)
                {
                    DestroyImmediate(container.transform.GetChild(0).gameObject);
                }
                foreach (Transform child in container.transform)
                {
                    GameObject.DestroyImmediate(child.gameObject);
                }

                //Debug.Log(" items.Count : " + items.Count);
                for (int i = 0; i < itemNames.Length; i++)
                {
                    string name = itemNames[i];
                    string slotPath = "Prefabs/MenuItem";
                    GameObject slot = Instantiate(Resources.Load(slotPath), container.transform) as GameObject;
                    slot.transform.localPosition = new Vector3(0, -34 * i);
                    Button btn = slot.GetComponent<Button>();
                    btn.GetComponentInChildren<Text>().text = name;

                    if (menuFunction.Length > 0 && menuFunction[i] != null)
                    {
                        btn.onClick.AddListener(menuFunction[i]);
                    }
                }
            }
        }

    }



#if UNITY_EDITOR
    [CustomEditor(typeof(GameMenuScript))]
    public class GameMenuScriptEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            GameMenuScript sc = (GameMenuScript)target;

            if (GUILayout.Button("Update UI"))
            {
                sc.Refresh();
            }
        }
    }
#endif
}