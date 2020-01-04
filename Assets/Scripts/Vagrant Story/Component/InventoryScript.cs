using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using VagrantStory.Items;


namespace VagrantStory.Component
{

    public class InventoryScript : MonoBehaviour
    {
        public GameObject container;

        public List<Item> items;



        // Start is called before the first frame update
        void Start()
        {
            items = new List<Item>();
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnValidate()
        {
            /*
            UnityEditor.EditorApplication.delayCall += () =>
            {
                Refresh();
            };
            */
        }

        private void OnGUI()
        {
            if (GUILayout.Button("Update"))
            {
                Refresh();
            }
        }

        public void Refresh()
        {
            //Debug.Log(" container.transform.childCount : " + container.transform.childCount);
            for (int i = 0; i < container.transform.childCount; i++)
            {
                DestroyImmediate(container.transform.GetChild(0).gameObject);
            }
            foreach (Transform child in container.transform)
            {
                GameObject.DestroyImmediate(child.gameObject);
            }
            //Debug.Log(" items.Count : " + items.Count);
            for (int i = 0; i < items.Count; i++)
            {
                Item item = items[i];
                string slotPath = "Prefabs/InventorySlot";
                GameObject slot = Instantiate(Resources.Load(slotPath), container.transform) as GameObject;
                slot.transform.localPosition = new Vector3(34, -34 * i);
                InventorySlotScript slotScript = slot.GetComponent<InventorySlotScript>();
                slotScript.itemName = item.name;
                slotScript.icon = item.type;
                if (item.stackable)
                {
                    slotScript.itemStack = string.Concat(item.quantity);
                }
                else
                {
                    slotScript.itemStack = "";
                }
                slotScript.Refresh();
            }
        }
    }


#if UNITY_EDITOR
    [CustomEditor(typeof(InventoryScript))]
    public class InventoryScriptEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            InventoryScript sc = (InventoryScript)target;

            if (GUILayout.Button("Update UI"))
            {
                sc.Refresh();
            }
        }
    }
#endif
}