using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SalirJuego : MonoBehaviour
{
    public void Finish()
    {
        // Mensaje de depuración en la consola
        Debug.Log("Cerrando el juego...");

        // Si está en el Editor, se detiene la ejecución
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit(); // Cerrar la aplicación
#endif
    }
}
