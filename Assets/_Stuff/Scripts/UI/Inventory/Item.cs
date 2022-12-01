using System;
using UnityEngine;

namespace _Stuff.Scripts.UI.Inventory
{
    [Serializable]
    public class Item
    {
        public int id;
        public string name;
        public int price;
    }

    [Serializable]
    public class ItemInventory
    {
        public Item item;
        public int quantity;
    }
}