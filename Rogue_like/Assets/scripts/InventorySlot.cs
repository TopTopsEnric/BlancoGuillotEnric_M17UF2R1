using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ItemData;

public class InventorySlot : MonoBehaviour
{
    public ItemData item;
    public int quantity;

    public InventorySlot(ItemData item, int quantity)
    {
        this.item = item;
        this.quantity = quantity;
    }
}
