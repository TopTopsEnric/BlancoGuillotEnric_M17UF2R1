using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerObjetos : MonoBehaviour
{
    public GameObject[] prefabs; // Array de prefabs para instanciar

    // M�todo para instanciar un objeto aleatorio del array en la posici�n actual
    public void SpawnObjeto()
    {
        if (prefabs.Length == 0)
        {
            Debug.LogWarning("El array de prefabs est� vac�o. Agrega prefabs en el inspector.");
            return;
        }

        // Selecciona un prefab aleatorio del array
        int randomIndex = Random.Range(0, prefabs.Length);
        GameObject prefabSeleccionado = prefabs[randomIndex];

        

        // Instancia el prefab en la posici�n y rotaci�n del GameObject
        Instantiate(prefabSeleccionado, transform.position, transform.rotation);
    }
}
