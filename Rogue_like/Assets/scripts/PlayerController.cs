using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; // Velocidad de movimiento
    private Vector2 moveInput;  // Entrada de movimiento
    private Rigidbody2D rb;     // Referencia al Rigidbody2D

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
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
    }
}
