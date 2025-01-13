using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class RellenarInventario : MonoBehaviour
{
    public ListItem listitems;
    public GameObject Tienda;
    public GameObject panelTienda;
    public Button botonOpcionPrefab; // Prefab de botón para las opciones
    public ItemData ItemActual;

    
    // Start is called before the first frame update
    void Start()
    {
        Tienda.SetActive(false);

    }

    public void IniciarTienda()
    {
        Debug.Log("esta entrando el la funcion de Iniciar tienda");
        
        GenerarItems();
    }

    public void GenerarItems()
    {
         if (listitems.items.Count > 0)
         {

             Tienda.SetActive(true);

             // Limpiar opciones anteriores
             foreach (Transform child in panelTienda.transform)
             {
                 Destroy(child.gameObject);
             }

             // Crear botones para cada opción
             foreach (var opcion in listitems.items)
            {
                Button boton = Instantiate(botonOpcionPrefab, panelTienda.transform);
                RectTransform botonRect = boton.GetComponent<RectTransform>();

                // Ajustar tamaño y posición del botón
               
                string precioComoTexto = opcion.price.ToString();

                TextMeshProUGUI[] textosBoton = boton.GetComponentsInChildren<TextMeshProUGUI>(true);
                if (textosBoton != null && textosBoton.Length > 0)
                {
                    textosBoton[0].text = opcion.itemName;
                    textosBoton[1].text = precioComoTexto;
                    textosBoton[2].text = opcion.description;
                }
                Image imagen = boton.GetComponentInChildren<Image>();
                imagen.sprite = opcion.icon;


                // Añadir funcionalidad al botón
                boton.onClick.AddListener(() =>
                 {
                     ;
                 });
             }
         }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
