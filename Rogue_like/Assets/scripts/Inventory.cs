using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<InventorySlot> items = new List<InventorySlot>();

    public int money { get; set; } = 0;

    public void AddItem(ItemData newItem, int quantity)
    {
        InventorySlot slot = FindItemSlot(newItem);

        if (slot != null && newItem.isStackable)
        {
            // Si el item ya existe y es apilable, añade la cantidad
            slot.AddQuantity(quantity);
            if (slot.quantity > newItem.maxStackSize)
            {
                slot.quantity = newItem.maxStackSize; // Limita al máximo stack permitido
            }
        }
        else if (slot != null)
        {
            Debug.Log("Maximo de inventario alcanzado");
        }
        else
        {
            // Si no existe, crea un nuevo slot
            items.Add(new InventorySlot(newItem, quantity));
        }
    }

    public void RemoveItem(ItemData item, int quantity)
    {
        InventorySlot slot = FindItemSlot(item);

        if (slot != null)
        {
            slot.RemoveQuantity(quantity);

            if (slot.quantity <= 0)
            {
                // Elimina el slot del inventario si la cantidad es 0
                items.Remove(slot);
            }
        }
    }

    private InventorySlot FindItemSlot(ItemData item)
    {
        // Busca en la lista el slot que contiene el item especificado
        return items.Find(slot => ReferenceEquals(slot.item, item));
    }

    void Update()
    {
        Debug.Log("Money: " + money);
    }
}
