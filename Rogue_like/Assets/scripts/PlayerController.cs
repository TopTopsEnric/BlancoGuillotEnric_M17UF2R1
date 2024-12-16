using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; // Velocidad de movimiento
    private Vector2 moveInput;// Entrada de movimiento
    private Vector2 mouseInput;
    private Rigidbody2D rb;     // Referencia al Rigidbody2D
    private Animator animator;
    private Player_StateController estado;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        estado = GetComponent<Player_StateController>();
    }


    public void OnAtacar(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            // Cuando se empieza a presionar el bot�n
            Debug.Log("Atacando");
            
            estado.atacando = true;
            estado.seleccionar_estado();
        }
        else if (context.canceled)
        {
            // Cuando se suelta el bot�n
            Debug.Log("dejar de Atacar");
           
            estado.atacando = false;
            estado.seleccionar_estado();
        }
    }

    public void OnRecargar(InputAction.CallbackContext context)
    {
        Debug.Log("Iniciando recarga...");
        moveSpeed = 0f; // Bloquea el movimiento
        estado.corriendo = false;
        estado.caminando = false;
        estado.recargando = true;
       // StartCoroutine(HandleReloadAnimation());

    }

    public void OnSprintar(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            // Cuando se empieza a presionar el bot�n
            Debug.Log("Iniciando sprint");
            moveSpeed = 8f;
            estado.corriendo = true;
            estado.seleccionar_estado();
        }
        else if (context.canceled)
        {
            // Cuando se suelta el bot�n
            Debug.Log("Deteniendo sprint");
            moveSpeed = 5f; // Velocidad normal
            estado.corriendo = false;
            estado.seleccionar_estado();
        }
    }

    public void OnMirar(InputAction.CallbackContext context)
    {
        
        mouseInput = context.ReadValue<Vector2>();
        // Convertir la posici�n del mouse a coordenadas del mundo
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(new Vector3(mouseInput.x, mouseInput.y, Camera.main.nearClipPlane));

        // Forzar z = -10 para trabajar en el plano correcto
        mouseWorldPosition.z = -10;
        
        // Asignar los valores X e Y al Animator
        animator.SetFloat("X", mouseWorldPosition.x);
        animator.SetFloat("Y", mouseWorldPosition.y);
    }


    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Debug.Log("andando");
            moveInput = context.ReadValue<Vector2>();
            estado.caminando = true;
            estado.seleccionar_estado();
        }
        else if (context.canceled)
        {
            // Cuando se suelta el bot�n
            Debug.Log("Dejando de andar");
            estado.caminando = false;
            estado.seleccionar_estado();
        }
    }

    private void FixedUpdate()
    {
        // Mueve al jugador en 8 direcciones
        Vector2 movement = moveInput * moveSpeed;
        rb.velocity = movement;
       
    }
}
