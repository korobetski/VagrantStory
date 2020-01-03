using MyBox;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VagrantStory.Core;

namespace VagrantStory.Component
{

    public class InventorySlotScript : MonoBehaviour
    {
        [Separator("Fixed Values")]
        public Text itemNameUI;
        public Text stackUI;
        public Image iconUI;
        public Sprite[] icons;


        [Separator("Variables")]
        public Enums.eItemCategory icon;
        public string itemName = "Item Name";
        public string itemStack = "99";




        void Start()
        {
            OnValidate();
        }

        private void OnValidate()
        {
            itemNameUI.text = itemName;
            stackUI.text = itemStack;
            //string iconName = Enum.GetName(typeof(eIcon), icon).ToLower();
            string iconName = icon.ToString().ToLower();
            if (icon != Enums.eItemCategory.NONE)
            {
                iconUI.sprite = icons[IndexOfIcon(iconName)];
                iconUI.color = Color.cyan;
            } else
            {
                iconUI.sprite = null;
                iconUI.color = Color.clear;
            }
        }

        public void Refresh()
        {
            OnValidate();
        }


        private int IndexOfIcon(string iconName)
        {
            int index = -1;
            for(int i = 0; i< icons.Length; i++)
            {
                Sprite ic = icons[i];
                if (ic.name.ToLower() == iconName)
                {
                    index = i;
                    break;
                }
            }


            return index;
        }
    }
}