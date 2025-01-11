using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colisiones : MonoBehaviour
{
    public ControladorDialogo dialogo;
    public ListaDialogos listaDeDialogos;
    public int num_dialogo = 0;
    private bool isPlayerInRange = false; // Para saber si el jugador está en rango


    // Detectar entrada al trigger
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // Verifica si el objeto tiene el tag "Player"
        {
            isPlayerInRange = true;
            Debug.Log("Jugador en rango");
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
            Debug.Log("Esta detectando el input");
            // Accede a la lista "dialogos" dentro de listaDeDialogos
            if (num_dialogo >= 0 && num_dialogo < listaDeDialogos.dialogos.Count)
            {
                dialogo.IniciarDialogo(listaDeDialogos.dialogos[num_dialogo]);
            }
            else
            {
                Debug.LogError("Número de diálogo fuera de rango.");
            }
        }
    }
}
