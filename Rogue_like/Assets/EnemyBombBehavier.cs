using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBombBehavier : MonoBehaviour
{
    public float speed = 2.0f; // Velocidad de movimiento hacia el jugador
    private Vector3 targetPosition;
    private Vector3 EnemyPosition; // Coordenadas previas
    private bool isChasing = false; // Control para comenzar a seguir al jugador
    public float Vida = 100f;
    float tolerance = 0.01f;
    public SpawnerObjetos spawnobjetos;



    public Animator animator;  // Referencia al Animator

    private void Start()
    {
        EnemyPosition = transform.position;
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Colisi�n con: " + collision.gameObject.name + ", Tag: " + collision.gameObject.tag);

        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log(collision.gameObject.name);
            // Verifica si el objeto con el que colision� no es parte de la lanza
            if (collision.gameObject.name != "mele collider") // Cambia el nombre seg�n tu objeto
            {
                // Verifica si el objeto con el que colision� tiene el componente PlayerController
                PlayerController player = collision.gameObject.GetComponent<PlayerController>();
                if (player != null)
                {
                    // Reduce la vida del jugador
                    player.Vida -= 40;
                    Debug.Log("Vida restante del jugador: " + player.Vida);
                    Bomba();
                }
            }
        }
        else
        {
            Debug.Log("Has chocado con algo que no es el jugador.");
        }
    }

    public void OnTriggerStay2D(Collider2D other)
    {
        PlayerController player = other.GetComponent<PlayerController>();
        if (player != null)
        {
            // Obt�n las coordenadas del jugador y activa el seguimiento
            isChasing = true;

            targetPosition = player.transform.position;
            //Debug.Log("Comenzando a perseguir al jugador en " + targetPosition);
        }
    }

    public void buscando()
    {
        if (isChasing)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

            // Det�n el seguimiento si alcanza la posici�n del jugador
            if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
            {
                isChasing = false;
                Debug.Log("Alcanz� la posici�n del jugador.");
            }
        }
    }
    public void animationControler()
    {
        // Si est� persiguiendo al jugador, establece los par�metros del Animator
        if (isChasing)
        {
            // Marca el par�metro "moviendose" como true
            animator.SetBool("moviendo", true);

            // Calcula la direcci�n hacia el jugador
            Vector3 direction = targetPosition - transform.position;

            // Normaliza la direcci�n
            Vector2 normalizedDirection = new Vector2(direction.x, direction.y).normalized;

            if (Mathf.Abs(normalizedDirection.x - 1) < tolerance && Mathf.Abs(normalizedDirection.y) < tolerance)
            {
                animator.SetBool("reves", true);
            }
            else
            {
                animator.SetBool("reves", false);
            }

            // Establece los par�metros X e Y en el Animator
            animator.SetFloat("X", normalizedDirection.x);
            animator.SetFloat("Y", normalizedDirection.y);

            // Si el valor de X es 1 y Y es 0, activa el par�metro "reves"
           
        }
        else
        {
            // Si no est� persiguiendo, desactiva "moviendose"
            animator.SetBool("moviendose", false);
        }
    }

    public void Bomba()
    {
        animator.SetBool("Muerte", true);
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
        Debug.Log("Vida restante del Suicida: " + Vida);
    }


    private void Update()
    {
        if (Vida <= 0)
        {
            Bomba();
        }
        buscando();
        animationControler();
        

    }

}
