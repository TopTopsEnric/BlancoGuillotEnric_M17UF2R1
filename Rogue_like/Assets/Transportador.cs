using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transportador : MonoBehaviour
{
    public int[] sceneIndexes = { 2, 3, 4 };
    public bool esrandom { get; set; } = true;
    public int numeroescena { get; set; } = 0;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Comprobamos si el objeto que entra tiene el tag "Player"
        if (other.CompareTag("Player"))
        {
            if (esrandom)
            {
                // Seleccionamos un índice de escena aleatorio del array
                int randomSceneIndex = sceneIndexes[Random.Range(0, sceneIndexes.Length)];

                // Llamamos al GameManager para cambiar de escena
                GameManager.gameManager.ChangeScene(randomSceneIndex);
            }
            else
            {
                GameManager.gameManager.ChangeScene(sceneIndexes[numeroescena]);
            }
            
        }
    }
}
