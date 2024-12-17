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
    public int cargador=100;

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
            estado.recargando = true;
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
        
        mouseInput = context.ReadValue<Vector2>();
        // Convertir la posición del mouse a coordenadas del mundo
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(new Vector3(mouseInput.x, mouseInput.y, Camera.main.nearClipPlane));

        // Forzar z = -10 para trabajar en el plano correcto
        mouseWorldPosition.z = -10;
        
        // Asignar los valores X e Y al Animator
        animator.SetFloat("X", mouseWorldPosition.x);
        animator.SetFloat("Y", mouseWorldPosition.y);
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
        Debug.Log("Recarga completa");
        estado.recargando = false;
        moveSpeed = 5f; // Restablece la velocidad de movimiento normal
        estado.seleccionar_estado(); // Cambia al estado correspondiente
    }

    private void FixedUpdate()
    {
        // Mueve al jugador en 8 direcciones

        Vector2 movement = moveInput * moveSpeed;
        rb.velocity = movement;
    }
}
