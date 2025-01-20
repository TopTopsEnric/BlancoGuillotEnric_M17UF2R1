using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transportador : MonoBehaviour
{
    public int[] sceneIndexes = { 2, 3, 4,5 };
    public bool esrandom { get; set; } = true;
    public int numeroescena { get; set; } = 0;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Comprobamos si el objeto que entra tiene el tag "Player"
        if (other.CompareTag("Player"))
        {
            Debug.Log("Está chocando con la puerta");

            if (esrandom)
            {
                // Lista para almacenar las escenas disponibles
                List<int> availableScenes = new List<int>();

                // Comprobar los bool de GameManager para identificar las escenas no completadas
                if (!GameManager.gameManager.playa)
                    availableScenes.Add(2);
                if (!GameManager.gameManager.bosque)
                    availableScenes.Add(3);
                if (!GameManager.gameManager.cueva)
                    availableScenes.Add(4);

                if (availableScenes.Count > 0)
                {
                    // Seleccionamos una escena aleatoria de las disponibles
                    int randomSceneIndex = availableScenes[Random.Range(0, availableScenes.Count)];

                    // Cambiamos a la nueva escena
                    GameManager.gameManager.ChangeScene(randomSceneIndex);
                }
                else
                {
                    Debug.Log("Todas las escenas han sido completadas.");
                }
            }
            else
            {
                // Cambiamos a la escena especificada directamente
                GameManager.gameManager.ChangeScene(sceneIndexes[numeroescena]);
            }
        }
    }
}
