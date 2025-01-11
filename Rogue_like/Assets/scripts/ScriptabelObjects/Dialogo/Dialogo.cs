using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class OpcionDeDialogo
{
    [TextArea(3, 10)]
    public string textoOpcion; // Texto de la opción que verá el jugador
    public Dialogo siguienteDialogo; // El diálogo que se activará si se elige esta opción
}

[CreateAssetMenu(fileName = "DialogoConRamas", menuName = "Sistema de Dialogos/Nuevo Dialogo con Ramas")]
public class Dialogo : ScriptableObject
{
    [TextArea(3, 10)]
    public string[] lineasDeDialogo; // Líneas principales del diálogo
    public OpcionDeDialogo[] opciones; // Opciones disponibles al final del diálogo
}
