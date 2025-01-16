using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorrarMenu : MonoBehaviour
{
   
    public void cerrar(GameObject objetivo)
    {
        objetivo.SetActive(false);

    }
}
