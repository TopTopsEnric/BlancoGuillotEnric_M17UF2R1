using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemaBehavier : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Comprueba si el objeto que entra tiene el tag "Player"
        if (other.CompareTag("Player"))
        {
            if (true)
            {
                // Cambia el valor del bool nivel3
                //gameManager.nivel3 = true;

                // Llama a la función ChangeScene
                //gameManager.ChangeScene();
            }
        }
    }
}
