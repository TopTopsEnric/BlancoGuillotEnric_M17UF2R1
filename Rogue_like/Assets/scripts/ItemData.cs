using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]

public class ItemData: ScriptableObject
{
   
    
        public string itemName;
        public Sprite icon;
        public string description;
        public bool isStackable;
        public int maxStackSize;
        public int damage;
        public int range;
        public float price;
        
}
