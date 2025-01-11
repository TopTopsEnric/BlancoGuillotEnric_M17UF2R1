using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesColisions : MonoBehaviour
{
    public float damageAmount = 0.5F; // Da�o que aplica cada part�cula

    void OnParticleCollision(GameObject other)
    {
        // Verifica si el objeto colisionado tiene el tag "Enemy"
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("Chocando contra enemigo");
            // Env�a un mensaje al objeto colisionado para que llame al m�todo "ApplyDamage"
            other.SendMessage("ApplyDamage", damageAmount, SendMessageOptions.DontRequireReceiver);
        }
    }
}
