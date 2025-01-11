using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disparador : MonoBehaviour
{
    public float speed = 30f; // Velocidad del proyectil




    public void ReturnProjectile(GameObject go)
    {
        go.SetActive(false);
        GameManager.gameManager.Push(go);
    }

    public  IEnumerator SpawnProjectiles(Vector3 posicion)
    {
        Debug.Log("Esta entrando en la funcion de spawn");
        GameObject proyectil = GameManager.gameManager.Pop(); // Saca un proyectil del GameManager
        if (proyectil != null)
        {
            Debug.Log("Projectil cargado");
            // Configura la posición inicial del proyectil
            proyectil.transform.position = transform.position;


            // Comienza a mover el proyectil
            StartCoroutine(MoveProjectile(proyectil, posicion));
        }
        yield break;
    }

    private IEnumerator MoveProjectile(GameObject proyectil, Vector3 posicion)
    {
        // Mueve el proyectil hacia la posición objetivo
        Debug.Log("Estamos en la funcion MoveProjectile");
        while (Vector3.Distance(proyectil.transform.position, posicion) > 0.1f) // Compara la distancia entre el proyectil y la posición
        {
            Debug.Log("en teoria se mueve");
            // Calcula la dirección del movimiento (de la posición actual a la posición objetivo)
            Vector3 direction = (posicion - proyectil.transform.position).normalized;

            // Mueve el proyectil en la dirección calculada
            proyectil.transform.position += direction * speed * Time.deltaTime; // Avanza hacia la posición

            yield return null; // Espera hasta el siguiente frame
        }

        // Cuando el proyectil llega a la posición objetivo, devuelve el proyectil al GameManager
        ReturnProjectile(proyectil);
    }
}
