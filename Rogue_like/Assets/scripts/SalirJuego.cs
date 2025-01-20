using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SalirJuego : MonoBehaviour
{
    public void Finish()
    {
        // Mensaje de depuraci�n en la consola
        Debug.Log("Cerrando el juego...");

        // Si est� en el Editor, se detiene la ejecuci�n
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit(); // Cerrar la aplicaci�n
#endif
    }
}
