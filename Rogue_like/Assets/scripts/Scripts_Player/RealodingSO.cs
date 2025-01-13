using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Realoding", menuName = "StatesSO/Realoding")]
public class RealodingSO : StateSO
{
    public override void OnStateEnter(Player_StateController ec)
    {
        Debug.Log("Entrando al estado de recarga...");
        ec.animator.Play("realoding");
    }
    public override void OnStateUpdate(Player_StateController ec)
    {

    }
    public override void OnStateExit(Player_StateController ec)
    {

    }
}
