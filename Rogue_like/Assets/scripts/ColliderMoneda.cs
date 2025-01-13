using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderMoneda : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Inventory inventory = collision.GetComponent<Inventory>(); // Obtiene el componente Inventory del jugador
        if (inventory != null) // Verifica que el componente Inventory haya sido encontrado
        {
            inventory.money+=5; // Llama a la función AddItem del inventario

            Debug.Log("se ha suamdo dinero");

            Destroy(gameObject);
        }
    }

}
