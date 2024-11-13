using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    // Start is called before the first frame update
    public List<InventorySlot> items = new List<InventorySlot>();

    public void AddItem(ItemData newItem, int quantity)
    {
        InventorySlot slot = FindItemSlot(newItem);

        if (slot != null && newItem.isStackable)
        {
            slot.quantity += quantity;
            if (slot.quantity > newItem.maxStackSize)
            {
                slot.quantity = newItem.maxStackSize;
                // Opcional: manejar el exceso, o agregar en otro slot.
            }
        }
        else
        {
            items.Add(new InventorySlot(newItem, quantity));
        }
    }

    public void RemoveItem(ItemData item, int quantity)
    {
        InventorySlot slot = FindItemSlot(item);

        if (slot != null)
        {
            slot.quantity -= quantity;
            if (slot.quantity <= 0)
            {
                items.Remove(slot);
            }
        }
    }

    private InventorySlot FindItemSlot(ItemData item)
    {
        return items.Find(slot => slot.item == item);
    }
}
