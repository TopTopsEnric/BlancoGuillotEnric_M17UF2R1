using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class RellenarInventario : MonoBehaviour
{
    public ListItem listitems;
    public GameObject panelTienda;
    public Button botonOpcionPrefab; // Prefab de bot�n para las opciones
    public ItemData ItemActual;

    private int indiceLinea;
    // Start is called before the first frame update
    void Start()
    {
        panelTienda.SetActive(false);

    }

    public void IniciarTienda()
    {
        Debug.Log("esta entrando el la funcion de Iniciar tienda");
        indiceLinea = 0;
        GenerarItems();
    }

    public void GenerarItems()
    {
        /* if (listitems.Items.Length > 0)
         {

             panelTienda.SetActive(true);

             // Limpiar opciones anteriores
             foreach (Transform child in panelTienda.transform)
             {
                 Destroy(child.gameObject);
             }

             // Crear botones para cada opci�n
             foreach (var opcion in panelTienda.Items)
             {
                 Button boton = Instantiate(botonOpcionPrefab, panelTienda.transform);

                 TextMeshProUGUI textoBoton = boton.GetComponentInChildren<TextMeshProUGUI>();
                 textoBoton.text = opcion.textoOpcion;

                 // A�adir funcionalidad al bot�n
                 boton.onClick.AddListener(() =>
                 {
                     IniciarDialogo(opcion.siguienteDialogo);
                 });
             }
         }*/
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
