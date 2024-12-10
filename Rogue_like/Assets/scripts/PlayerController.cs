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
    }



    public void OnSprintar(InputAction.CallbackContext context)
    {
        moveSpeed = 8f;
        estado.corriendo = true;
    }

    public void OnMirar(InputAction.CallbackContext context)
    {
        mouseInput= context.ReadValue<Vector2>();
    }


    public void OnMove(InputAction.CallbackContext context)
    {
        // Obtiene el valor de la entrada
        moveInput = context.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        // Mueve al jugador en 8 direcciones
        Vector2 movement = moveInput * moveSpeed;
        rb.velocity = movement;
        animator.SetFloat("X", moveInput.x);
        animator.SetFloat("Y", moveInput.y);
    }
}
