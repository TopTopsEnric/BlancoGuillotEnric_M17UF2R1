using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorretBehavier : MonoBehaviour
{
   // Velocidad de movimiento hacia el jugador
    private Vector3 targetPosition;
    private Vector3 EnemyPosition; // Coordenadas previas
    public float Vida = 100f;
    public Animator animator;
    public GameObject childObject;
    public float shootCooldown = 5.0f; // Tiempo de espera entre disparos
    private float lastShootTime = 0.0f;
    private bool isNotExploading = true;
    public SpawnerObjetos spawnobjetos;


    public void OnTriggerStay2D(Collider2D other)
    {
        PlayerController player = other.GetComponent<PlayerController>();
        if (player != null)
        {
            // Obt�n las coordenadas del jugador y activa el seguimiento

            targetPosition = player.transform.position;

            apuntar();
            if (Time.time - lastShootTime >= shootCooldown)
            {
                Disparar();
                lastShootTime = Time.time;
            }
        }



    }
    public void apuntar()
    {
        Debug.Log("Preparando el Disparo");
        Vector3 direction = targetPosition - transform.position;

        // Calcula el �ngulo en el eje Z usando Mathf.Atan2 (usando la direcci�n X y Y)
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle));

        // Rotar gradualmente hacia el jugador
        float rotationSpeed = 2000f; // Grados por segundo
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    public void Disparar()
    {
        if (isNotExploading)
        {
            Debug.Log("childObject: " + childObject);
            disparador disparar = childObject.GetComponent<disparador>();
            if (disparar != null)
            {
                Debug.Log("Disparando");
                StartCoroutine(disparar.SpawnProjectiles(targetPosition));
                lastShootTime = Time.time; // Actualiza el tiempo del �ltimo disparo
            }
            else
            {
                Debug.LogError("El componente Disparador no se encuentra en childObject.");
            }
        }
        else
        {
            Debug.Log("Torrenta destruyendose");
        }

       
    }

    public void Bomba()
    {
        isNotExploading = false;
        animator.SetBool("Muerto", true);
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }
        StartCoroutine(EsperarFinAnimacion());
    }

    private IEnumerator EsperarFinAnimacion()
    {
        // Obt�n la duraci�n de la animaci�n "Muerte" en el Animator
        float duracionAnimacion = animator.GetCurrentAnimatorStateInfo(0).length;

        // Espera hasta que la animaci�n termine
        yield return new WaitForSeconds(duracionAnimacion);

        // Despu�s de que la animaci�n termine, destruye el script
        spawnobjetos.SpawnObjeto();
        Destroy(gameObject);
    }

    public void ApplyDamage(float amount)
    {
        Vida -= amount;
        Debug.Log("Vida restante del la torre: " + Vida);
    }

    public void Update()
    {
        if (Vida <= 0)
        {
            Bomba();
        }
    }

}
