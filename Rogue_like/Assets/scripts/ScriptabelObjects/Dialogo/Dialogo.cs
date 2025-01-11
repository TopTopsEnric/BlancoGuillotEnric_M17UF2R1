using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class OpcionDeDialogo
{
    [TextArea(3, 10)]
    public string textoOpcion; // Texto de la opci�n que ver� el jugador
    public Dialogo siguienteDialogo; // El di�logo que se activar� si se elige esta opci�n
}

[CreateAssetMenu(fileName = "DialogoConRamas", menuName = "Sistema de Dialogos/Nuevo Dialogo con Ramas")]
public class Dialogo : ScriptableObject
{
    [TextArea(3, 10)]
    public string[] lineasDeDialogo; // L�neas principales del di�logo
    public OpcionDeDialogo[] opciones; // Opciones disponibles al final del di�logo
}
