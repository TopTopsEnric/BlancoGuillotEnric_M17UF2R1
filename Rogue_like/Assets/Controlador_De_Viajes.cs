using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class Controlador_De_Viajes : MonoBehaviour
{
    public GameObject objectToActivate; // El GameObject a activar
    private bool playerInRange = false;
    public Transportador transportar;

    private GameObject buttonPlaya;
    private GameObject buttonBosque;
    private GameObject buttonCueva;

    private void Start()
    {
        // Obt�n los botones hijos en orden
        buttonPlaya = objectToActivate.transform.GetChild(0).gameObject;
        buttonBosque = objectToActivate.transform.GetChild(1).gameObject;
        buttonCueva = objectToActivate.transform.GetChild(2).gameObject;
    }

    // Detecta la colisi�n con el trigger
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    // Detecta cuando el jugador sale del trigger
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }

    // Actualiza si se presiona la tecla Q
    private void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("Est� detectando el input");

            if (GameManager.gameManager.playa)
            {
                buttonPlaya.SetActive(true); // Activa el bot�n Playa
            }

            if (GameManager.gameManager.bosque)
            {
                buttonBosque.SetActive(true); // Activa el bot�n Bosque
            }

            if (GameManager.gameManager.cueva)
            {
                buttonCueva.SetActive(true); // Activa el bot�n Cueva
            }

            objectToActivate.SetActive(true); // Activa el GameObject que contiene los botones
        }
    }

    public void setearMundo(int mundo)
    {
        transportar.esrandom = false;
        transportar.numeroescena = mundo;
    }


}
