using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.VersionControl.Asset;

public abstract class StateSO : ScriptableObject
{
    public List<StateSO> StatesToGo;
    
    public abstract void OnStateEnter(Player_StateController ec);
    public abstract void OnStateUpdate(Player_StateController ec);
    public abstract void OnStateExit(Player_StateController ec);
}
