using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
       
    public float moveSpeed = 0f; // Velocidad de movimiento
    private Vector2 moveInput;// Entrada de movimiento
    private Vector2 mouseInput;
    private Rigidbody2D rb;     // Referencia al Rigidbody2D
    private Animator animator;
    private Player_StateController estado;
    public int bulletSpeed = 2;
    public GameObject bulletPrefab;
    public float Vida = 100f;
    public float cargador = 100f;
    private float nextShootTime = 0f;
    [SerializeField] private float shootCooldown = 0.5f;
    private Vector2 lastMouseInput;
    private bool useFlamethrower = false;
    [SerializeField] private ParticleSystem flamethrowerParticles;
    private bool isFlamethrowerActive = false;
    public GameObject meleeAttackPosition;
    private bool isDying = false;
    public AudioSource sonido;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        estado = GetComponent<Player_StateController>();

    }

    public void OnMelee(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            // Cuando se empieza a presionar el botón
            Debug.Log("Has cambiado a Melee");
            estado.arma = false;
            estado.melee = true;
            estado.seleccionar_estado();
        }
        
    }

    public void OnSinArmas(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            // Cuando se empieza a presionar el botón
            Debug.Log("Has cambiado a sin arma");
            estado.arma = false;
            estado.melee = false;
            estado.seleccionar_estado();
        }

    }

    public void OnArmas(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            // Cuando se empieza a presionar el botón
            Debug.Log("Has cambiado a con arma");
            estado.arma = true;
            estado.melee = false;
            estado.seleccionar_estado();
        }

    }

    public void OnAtacar(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            // Cuando se empieza a presionar el botón
            Debug.Log("Atacando");
            
            estado.atacando = true;
            estado.seleccionar_estado();
        }
        else if (context.canceled)
        {
            // Cuando se suelta el botón
            Debug.Log("dejar de Atacar");
            meleeAttackPosition.GetComponent<Collider2D>().enabled = false;
            flamethrowerParticles.Stop();
            isFlamethrowerActive = false;
            estado.atacando = false;
            estado.seleccionar_estado();
        }
    }

    public void OnRecargar(InputAction.CallbackContext context)
    {
        if (cargador < 100)
        {
            Debug.Log("Iniciando recarga...");
            moveSpeed = 0f; // Bloquea el movimiento
            estado.corriendo = false;
            estado.caminando = false;
            estado.atacando = false;
            estado.recargando = true;
            estado.arma = true;
            estado.melee = false;
            Debug.Log("Recargando: " + estado.recargando);
            sonido.Play();
            StartCoroutine(HandleReloadAnimation());
        }
        else
        {
            //sonido no puedes recargar
        }
       

    }

    public void OnSprintar(InputAction.CallbackContext context)
    {
        
        
            if (context.performed)
            {
                // Cuando se empieza a presionar el botón
                Debug.Log("Iniciando sprint");
                moveSpeed = 8f;
                estado.corriendo = true;
                estado.seleccionar_estado();
            }
            else if (context.canceled)
            {
                // Cuando se suelta el botón
                Debug.Log("Deteniendo sprint");
                moveSpeed = 5f; // Velocidad normal
                estado.corriendo = false;
                estado.seleccionar_estado();
            }
        
       
        
    }

    public void OnMirar(InputAction.CallbackContext context)
    {

        if (context.performed)
        {
            lastMouseInput = context.ReadValue<Vector2>();
             

        }
    }


    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.performed||context.started)
        {
            Debug.Log("andando");
            moveInput = context.ReadValue<Vector2>();
            float newSpeed = 5f;
            moveSpeed = Mathf.Max(moveSpeed, newSpeed);
            estado.caminando = true;
            estado.seleccionar_estado();
           

        }
        else if (context.canceled)
        {
            moveInput = Vector2.zero;
            rb.velocity = Vector2.zero; // Detiene el Rigidbody

            moveSpeed = 0f;
            estado.caminando = false;
            estado.seleccionar_estado();

        }
    }

    public void OnChangeWeapon(InputAction.CallbackContext context)
    {
        if (context.performed) // Verifica que la acción fue ejecutada, no iniciada o cancelada
        {
            useFlamethrower = !useFlamethrower; // Invierte el valor actual de la variable
        }
    }

    private IEnumerator HandleReloadAnimation()
    {
        // Ejecuta la animación de recarga
        // estado.animator.SetTrigger("Reload"); // Asegúrate de que "Reload" sea un trigger válido en el Animator
        estado.seleccionar_estado();

        // Opcional: sincroniza con la duración de la animación
        AnimatorStateInfo stateInfo = estado.animator.GetCurrentAnimatorStateInfo(0);
        float animationDuration = stateInfo.length;

        yield return new WaitForSeconds(animationDuration);

        // Al terminar la animación, selecciona el siguiente estado
        estado.recargando = false;
        cargador = 100;
        estado.seleccionar_estado();
        Debug.Log("Recarga completa");


    }

    private IEnumerator HandleDeathAnimation()
    {
        isDying = true;
        // Ejecuta la animación de recarga
        // estado.animator.SetTrigger("Reload"); // Asegúrate de que "Reload" sea un trigger válido en el Animator
        estado.seleccionar_estado();

        // Opcional: sincroniza con la duración de la animación
        AnimatorStateInfo stateInfo = estado.animator.GetCurrentAnimatorStateInfo(0);
        float animationDuration = stateInfo.length;

        yield return new WaitForSeconds(animationDuration);

        // Al terminar la animación, selecciona el siguiente estado
        estado.muerto = false;
        estado.seleccionar_estado();
        Debug.Log("Muerte completada");
        GameManager.gameManager.ChangeScene(1);
        


    }


    public void Shoot()
    {
        cargador -= 10f;
        // Recalcular la posición del ratón en el mundo
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(new Vector3(lastMouseInput.x, lastMouseInput.y, Mathf.Abs(transform.position.z)));

        // Asegúrate de que la coordenada Z se mantenga en 0 (en el plano 2D)
        mouseWorldPosition.z = 0;

        // Calcular la dirección de la bala
        Vector2 direction = ((Vector2)mouseWorldPosition - (Vector2)transform.position).normalized;

        // Asegúrate de que la dirección no sea 0, 0 (puedes añadir un chequeo aquí)
        if (direction == Vector2.zero)
        {
            Debug.LogError("La dirección es (0, 0), lo que significa que el ratón y el jugador están en la misma posición.");
            return;
        }

        // Instanciar la bala
        Vector2 spawnPosition = (Vector2)transform.position + direction * 0.5f; // Ajusta el offset
        GameObject bullet = Instantiate(bulletPrefab, spawnPosition, Quaternion.identity);

        // Configurar velocidad
        Rigidbody2D rbBullet = bullet.GetComponent<Rigidbody2D>();
        if (rbBullet != null)
        {
            rbBullet.velocity = direction * bulletSpeed;
        }

        // Debugging
        Debug.Log($"Mouse World Position: {mouseWorldPosition}, Direction: {direction}, Spawn Position: {spawnPosition}");
    }

    public void HandleFlamethrower()
    {
        Debug.Log("Flamethrower activado.");
        cargador -= 0.3f;

        // Obtén la posición del ratón en el mundo
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(new Vector3(lastMouseInput.x, lastMouseInput.y, Mathf.Abs(transform.position.z)));
        mouseWorldPosition.z = -0.2f; // Ajusta la posición en Z para darle prioridad visual

        // Calcula la dirección relativa al jugador
        Vector2 direction = (mouseWorldPosition - transform.position).normalized;

        // Establece la distancia fija desde el jugador (ajusta este valor según lo necesites)
        float distanceFromPlayer = 1.0f;

        // Calcula la nueva posición del lanzador de partículas, manteniendo la distancia
        Vector2 flamethrowerPosition2D = (Vector2)transform.position + direction * distanceFromPlayer;

        // Convierte la posición 2D a 3D y ajusta el valor de Z
        Vector3 flamethrowerPosition = new Vector3(flamethrowerPosition2D.x, flamethrowerPosition2D.y, -0.1f);

        // Mueve el lanzador de partículas a esa posición
        flamethrowerParticles.transform.position = flamethrowerPosition;

        // Calcula el ángulo de rotación que debe tener el GameObject (en grados) para mirar hacia el ratón
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Rota el GameObject (sin rotar las partículas) para que apunte en la dirección del ratón
        flamethrowerParticles.transform.rotation = Quaternion.Euler(0, 0, angle);

        // Activa las partículas si no están activadas
        if (!flamethrowerParticles.isPlaying)
        {
            flamethrowerParticles.Play();
            Debug.Log("Partículas activadas.");
        }

        // Verificación adicional para asegurarnos de que se emite correctamente
        //Debug.Log($"Posición: {flamethrowerParticles.transform.position}, Dirección: {direction}, Ángulo: {angle}");
    }



    public void HandleShooting()
    {
        if (cargador <= 0)
        {
            //sonido sin municion
        }
        else
        {


            if (useFlamethrower)
            {
                Debug.Log("esta entrando en fuego");
                HandleFlamethrower();
            }
            else
            {
                if (Time.time >= nextShootTime)
                {
                    Shoot();
                    nextShootTime = Time.time + shootCooldown;
                }
            }
        }
    }

    public void UpdateMeleeAttackPosition()
    {
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(new Vector3(lastMouseInput.x, lastMouseInput.y, Mathf.Abs(transform.position.z)));
        // Calcular la dirección hacia el ratón desde el jugador
        Vector2 direction = (mouseWorldPosition - transform.position).normalized;

        // Calcular la posición del GameObject vacío a una distancia constante
        Vector2 offset = direction * 2f;
        meleeAttackPosition.transform.position = (Vector2)transform.position + offset;

        // Calcular el ángulo de rotación necesario para que el GameObject mire hacia el ratón
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        meleeAttackPosition.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));


        meleeAttackPosition.GetComponent<Collider2D>().enabled = true;
    }

    public void ApplyDamage(float amount)
    {
        Vida -= amount;
        Debug.Log("Vida restante del jugador: " + Vida);
    }


    public void FixedUpdate()
    {
        // Mueve al jugador en 8 direcciones

        Vector2 movement = moveInput * moveSpeed;
        rb.velocity = movement;

        // Convertir las coordenadas del mouse a posición del mundo
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(new Vector3(lastMouseInput.x, lastMouseInput.y, Mathf.Abs(transform.position.z)));

        // Forzar z = -10 para trabajar en el plano correcto
        mouseWorldPosition.z = transform.position.z;

        // Calcular las direcciones relativas al jugador
        Vector2 lookDirection = new Vector2(mouseWorldPosition.x - transform.position.x, mouseWorldPosition.y - transform.position.y);

        // Asignar los valores X e Y al Animator para que apunte en esa dirección
        animator.SetFloat("X", lookDirection.x);
        animator.SetFloat("Y", lookDirection.y);

        // Debug.Log($"Mirando hacia: {lookDirection}");

        if (Vida <= 0 && !isDying)
        {
            moveSpeed = 0;
            estado.muerto = true;
            StartCoroutine(HandleDeathAnimation());
        }
    }
}
