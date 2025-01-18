using System.Collections.Generic;
using UnityEngine;

public class BehavierDoor : MonoBehaviour
{
    public ItemData requiredItem; // El objeto que debe estar en el inventario para activar la acción

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica si el objeto que entró tiene el tag "Player"
        if (other.CompareTag("Player"))
        {
            Inventory playerInventory = other.GetComponent<Inventory>();

            if (playerInventory != null && HasRequiredItem(playerInventory))
            {
                // Elimina el objeto requerido del inventario
                RemoveKeyFromInventory(playerInventory);

                // Elimina este GameObject (la puerta)
                Destroy(gameObject);
            }
        }
    }

    private bool HasRequiredItem(Inventory inventory)
    {
        // Busca el item en el inventario
        var slot = inventory.items.Find(s => ReferenceEquals(s.item, requiredItem));
        return slot != null && slot.quantity > 0;
    }

    private void RemoveKeyFromInventory(Inventory inventory)
    {
        // Elimina una unidad del objeto requerido
        inventory.RemoveItem(requiredItem, 1);
    }
}