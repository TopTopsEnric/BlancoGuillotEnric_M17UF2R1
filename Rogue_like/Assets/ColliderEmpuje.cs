using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderEmpuje : MonoBehaviour
{
    public float pushForce = 3f;  // Fuerza de empuje que se aplicará a los enemigos

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("Estoy trigereando");

            Rigidbody2D enemyRb = other.GetComponent<Rigidbody2D>();

            if (enemyRb != null)
            {
                // Verifica si el enemigo está dentro de un rango razonable antes de empujar
                float distance = Vector2.Distance(transform.position, other.transform.position);


                Debug.Log(distance);
                if (distance <= 1f) // attackRange es la distancia máxima de ataque
                {
                    Debug.Log("Le estoy aplicando fuerza");
                    Vector2 pushDirection = other.transform.position - transform.position;
                    pushDirection.Normalize();

                    enemyRb.AddForce(pushDirection * pushForce, ForceMode2D.Impulse);
                }
            }
        }
    }
}
