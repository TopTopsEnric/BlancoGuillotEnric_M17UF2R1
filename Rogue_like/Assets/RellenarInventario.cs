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
    public ItemData ItemActual;
    public Inventory inventario;
    
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

            int totalItems = panelTienda.transform.childCount;
            int totalDatos = listitems.items.Count;

            // Iterar sobre los hijos y rellenar los datos
            for (int i = 0; i < totalItems; i++)
            {
                Transform hijo = panelTienda.transform.GetChild(i);

                if (i < totalDatos)
                {
                    var opcion = listitems.items[i];
                    hijo.gameObject.SetActive(true); // Asegurarse de que el hijo esté activo

                    // Rellenar los textos
                    TextMeshProUGUI[] textosHijo = hijo.GetComponentsInChildren<TextMeshProUGUI>(true);
                    if (textosHijo != null && textosHijo.Length > 0)
                    {
                        textosHijo[0].text = opcion.itemName;
                        textosHijo[1].text = "precio=" + opcion.price.ToString();
                        
                    }

                    // Rellenar la imagen
                    Image imagen = hijo.GetComponentInChildren<Image>();
                    if (imagen != null)
                    {
                        imagen.sprite = opcion.icon;
                    }

                    // Añadir funcionalidad al botón
                    Button boton = hijo.GetComponent<Button>();
                    if (boton != null)
                    {
                        boton.onClick.RemoveAllListeners(); // Eliminar listeners anteriores
                        boton.onClick.AddListener(() =>
                        {
                            // Lógica al hacer clic
                        });
                    }
                }
                else
                {
                    // Desactivar hijos que no se usan
                    hijo.gameObject.SetActive(false);
                }
            }
        }
    }

    public void SeleccionarObjeto(ItemData itemSeleccionado)
    {
        // Asigna el objeto seleccionado a la variable ItemActual
        ItemActual = itemSeleccionado;
        Debug.Log($"Has seleccionado: {ItemActual.itemName}, Precio: {ItemActual.price}");
    }

    public void buy_item()
    {
        if (inventario.money >= ItemActual.price)
        {
            inventario.money -= ItemActual.price;
            inventario.AddItem(ItemActual, 1);
        }
        else
        {
            // sonido error de compra
        }
        
    }

        // Update is called once per frame
        void Update()
        {
        
         }
}
