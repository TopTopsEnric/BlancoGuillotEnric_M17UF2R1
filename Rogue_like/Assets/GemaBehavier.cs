using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemaBehavier : MonoBehaviour
{
    public int nombreNivel = 0;
    private void OnTriggerEnter2D(Collider2D other)
    {
       
        if (other.CompareTag("Player"))
        {
            
            
                switch (nombreNivel)
                {
                    case 1:
                        GameManager.gameManager.playa = true;
                        break;
                    case 2:
                        GameManager.gameManager.bosque = true;
                        break ;
                    case 3:
                        GameManager.gameManager.cueva = true;
                        break ;

                }

                GameManager.gameManager.ChangeScene(1);
            
        }
    }
}
