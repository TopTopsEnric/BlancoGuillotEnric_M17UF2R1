using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ListaDeDialogos", menuName = "Sistema de Dialogos/Nueva Lista de Dialogos")]

public class ListaDialogos : ScriptableObject
{

    public List<Dialogo> dialogos; // Lista de objetos Dialogo
}
