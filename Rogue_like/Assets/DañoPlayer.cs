using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DañoPlayer : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        string tag = collision.gameObject.tag;

        if (tag == "Player")
        {
            collision.gameObject.SendMessage("ApplyDamage", 20, SendMessageOptions.RequireReceiver);
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
    }
}

