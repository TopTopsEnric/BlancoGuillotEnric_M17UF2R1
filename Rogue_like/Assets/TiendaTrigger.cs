using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiendaTrigger : MonoBehaviour
{
    
    public RellenarInventario inventario;
    public GameObject jugador;
    
    private bool isPlayerInRange = false; // Para saber si el jugador está en rango

    private void start()
    {
        
    }
    // Detectar entrada al trigger
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // Verifica si el objeto tiene el tag "Player"
        {
            isPlayerInRange = true;
            jugador = collision.gameObject;
            Debug.Log(jugador.name);
        }
    }

    // Detectar salida del trigger
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInRange = false;
            Debug.Log("Jugador salió del rango");
        }
    }

    // Escuchar la tecla dentro del rango
    private void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.Q))
        {
            inventario.portador = jugador;
            inventario.IniciarTienda();
            
        }
    }
}
