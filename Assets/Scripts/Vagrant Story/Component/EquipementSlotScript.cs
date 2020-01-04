using MyBox;
using UnityEngine;
using UnityEngine.UI;
using VagrantStory.Core;

namespace VagrantStory.Component
{

    public class EquipementSlotScript : MonoBehaviour
    {
        [Separator("Fixed Values")]
        public Text slotNameUI;
        public Text itemNameUI;
        public Text materialLetterUI;
        public Image iconUI;
        public Sprite[] icons;


        [Separator("Variables")]
        public string slotName = "Slot Name";
        public Enums.eItemCategory icon;
        public enum eMaterialLetter { NONE, W, L, B, I, H, S, D }
        public eMaterialLetter letter = eMaterialLetter.W;
        public string itemName = "Item Name";


        private Color32[] _materialColors;


        void Start()
        {
            OnValidate();
        }

        private void OnValidate()
        {
            if (_materialColors == null || _materialColors.Length == 0)
            {
                _materialColors = new Color32[] {
                    Color.clear, // none
                    new Color32(0xA0, 0x52, 0x2D, 0xFF), // WOOD
                    new Color32(0xB8, 0x86, 0x0B, 0xFF), // LEATHER
                    new Color32(0x77, 0x88, 0x99, 0xFF), // BRONZE
                    new Color32(0xD3, 0xD3, 0xD3, 0xFF), // IRON
                    new Color32(0xB0, 0xE0, 0xE6, 0xFF), // HAGANE
                    new Color32(0xF0, 0xFF, 0xFF, 0xFF), // SILVER
                    new Color32(0xEE, 0xE8, 0xAA, 0xFF) // DAMASCUS
                };
            }
            slotNameUI.text = slotName.ToUpper();
            itemNameUI.text = itemName;
            if (letter == eMaterialLetter.NONE)
            {
                materialLetterUI.text = "";
            }
            else
            {
                materialLetterUI.text = letter.ToString();
            }
            materialLetterUI.color = _materialColors[(int)letter];
            //string iconName = Enum.GetName(typeof(eIcon), icon).ToLower();
            string iconName = icon.ToString().ToLower();
            iconUI.sprite = icons[IndexOfIcon(iconName)];
        }


        private int IndexOfIcon(string iconName)
        {
            int index = -1;
            for (int i = 0; i < icons.Length; i++)
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