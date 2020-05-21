using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Asha.Data
{
    public class Loot
    {
        public string Res;
        public string LootName;
        public string LootDesc;
    }


    public class LootGrid: MonoBehaviour
    {
        public Image LootIcon;
        public Text Name;
        public Text Desc;

        public Loot LootItem;

        public void Show()
        {
            if(LootItem.Res != "")
            {
                LootIcon.sprite = Resources.Load<Sprite>(LootItem.Res);
            }
            Name.text = LootItem.LootName;
            Desc.text = LootItem.LootDesc;
        }
    }



}

