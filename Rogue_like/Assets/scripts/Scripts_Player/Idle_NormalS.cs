using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Idle_normal", menuName = "StatesSO/Idle/Idle_normal")]

public class Idle_NormalS : IdleSo
{
    public override void OnStateEnter(Player_StateController ec)
    {
        Debug.Log(this.GetType().Name);
        ec.animator.Play("idle");
        Debug.Log("idleNormal");
    }
    public override void OnStateUpdate(Player_StateController ec)
    {

    }
    public override void OnStateExit(Player_StateController ec)
    {

    }

}
