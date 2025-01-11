using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealizarDaño : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        string tag = collision.gameObject.tag;

        if (tag == "Player")
        {
            // No hacer nada si colisiona con el jugador
            Debug.Log("La bala ha colisionado con el jugador, pero no se destruye.");
            return; // Salir del método
        }
        else if (tag == "Enemy")
        {
            // Aplicar daño a los enemigos
            collision.gameObject.SendMessage("ApplyDamage", 10, SendMessageOptions.RequireReceiver);
        }
        else
        {
            // Aplicar daño a otros objetos
            Debug.Log("Colisión con: " + tag);
            collision.gameObject.SendMessage("ApplyDamage", 4, SendMessageOptions.DontRequireReceiver);
        }

        // Destruir la bala tras la colisión (excepto con el jugador)
        Destroy(gameObject);
    }
}
