using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<InventorySlot> items = new List<InventorySlot>();

    public float money { get; set; } = 0;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Comprobamos si el nombre del objeto con el que colisionamos es "Transportador"
        if (collision.gameObject.name == "Transportador")
        {
            // Crear una lista de tuplas con los ítems y sus cantidades
            List<(ItemData, int)> itemsToAdd = new List<(ItemData, int)>();

            foreach (var slot in items)
            {
                itemsToAdd.Add((slot.item, slot.quantity)); // Agregar los items del inventario
            }

            // Llamar al método AddItems pasando la lista de items y el dinero
            GameManager.gameManager.inventory.AddItems(itemsToAdd, money);
        }
    }

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

    public void AddItems(List<(ItemData, int)> itemsToAdd, float dinero)
    {
        money = dinero;
        foreach (var item in itemsToAdd)
        {
            AddItem(item.Item1, item.Item2);  // Usa la función existente para agregar el item
        }
    }

    public List<(ItemData, int)> prepararLista()
    {
        // Crear una lista de tuplas con los ítems y sus cantidades
        List<(ItemData, int)> itemsToAdd = new List<(ItemData, int)>();

        // Suponiendo que `items` es una lista de InventorySlot o algo similar que contiene item y quantity
        foreach (var slot in items)
        {
            // Agregar los items del inventario
            itemsToAdd.Add((slot.item, slot.quantity));
        }

        // Retornar la lista de tuplas
        return itemsToAdd;
    }
}
