using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerObjetos : MonoBehaviour
{
    public GameObject[] prefabs; // Array de prefabs para instanciar

    // Método para instanciar un objeto aleatorio del array en la posición actual
    public void SpawnObjeto()
    {
        if (prefabs.Length == 0)
        {
            Debug.LogWarning("El array de prefabs está vacío. Agrega prefabs en el inspector.");
            return;
        }

        // Selecciona un prefab aleatorio del array
        int randomIndex = Random.Range(0, prefabs.Length);
        GameObject prefabSeleccionado = prefabs[randomIndex];

        

        // Instancia el prefab en la posición y rotación del GameObject
        Instantiate(prefabSeleccionado, transform.position, transform.rotation);
    }
}
