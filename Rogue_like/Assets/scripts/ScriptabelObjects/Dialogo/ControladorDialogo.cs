using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ControladorDialogo : MonoBehaviour
{

    public TextMeshProUGUI textoDialogo; // Texto principal
    public GameObject panelDialogo; // Panel que contiene el diálogo
    public GameObject panelOpciones; // Panel que contiene las opciones
    public Button botonOpcionPrefab; // Prefab de botón para las opciones
    public Dialogo dialogoActual; // Diálogo activo

    private int indiceLinea;

    private void Start()
    {
        panelDialogo.SetActive(false);
        panelOpciones.SetActive(false);
    }

    public void IniciarDialogo(Dialogo nuevoDialogo)
    {
        Debug.Log("esta entrando el la funcion de Iniciar Dialogo");
        dialogoActual = nuevoDialogo;
        indiceLinea = 0;
        panelDialogo.SetActive(true);
        panelOpciones.SetActive(false);
        MostrarSiguienteLinea();
    }

    public void MostrarSiguienteLinea()
    {
      
            if (indiceLinea < dialogoActual.lineasDeDialogo.Length)
            {
                textoDialogo.text = dialogoActual.lineasDeDialogo[indiceLinea];
                indiceLinea++;
            }
            else
            {
                MostrarOpciones();
            }
        
       
    }

    private void MostrarOpciones()
    {
        if (dialogoActual.opciones != null && dialogoActual.opciones.Length > 0)
        {
            panelDialogo.SetActive(false);
            panelOpciones.SetActive(true);

            // Limpiar opciones anteriores
            foreach (Transform child in panelOpciones.transform)
            {
                Destroy(child.gameObject);
            }

            // Crear botones para cada opción
            foreach (var opcion in dialogoActual.opciones)
            {
                Button boton = Instantiate(botonOpcionPrefab, panelOpciones.transform);
                TextMeshProUGUI textoBoton = boton.GetComponentInChildren<TextMeshProUGUI>();
                textoBoton.text = opcion.textoOpcion;

                // Añadir funcionalidad al botón
                boton.onClick.AddListener(() =>
                {
                    IniciarDialogo(opcion.siguienteDialogo);
                });
            }
        }
        else
        {
            TerminarDialogo();
        }
    }

    public void TerminarDialogo()
    {
        panelDialogo.SetActive(false);
        panelOpciones.SetActive(false);
        textoDialogo.text = "";
    }
}
