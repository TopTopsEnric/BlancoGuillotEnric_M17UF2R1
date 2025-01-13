using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderLlave : MonoBehaviour
{


    public List<ItemData> llaves = new List<ItemData>(4); // Lista de 4 elementos de tipo ItemData

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Inventory inventory = collision.GetComponent<Inventory>(); // Obtiene el componente Inventory del jugador
        if (inventory != null && llaves.Count > 0) // Verifica que el componente Inventory y la lista no estén vacíos
        {
            inventory.AddItem(llaves[0], 1); // Llama a la función AddItem con el primer elemento de la lista
            Destroy(gameObject); // Destruye el objeto de la escena
        }
    }

    // Update se deja vacío si no hay lógica adicional
    void Update()
    {
    }
}
