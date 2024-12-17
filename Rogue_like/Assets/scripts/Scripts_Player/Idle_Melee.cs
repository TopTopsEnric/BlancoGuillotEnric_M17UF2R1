using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Idle_Melee", menuName = "StatesSO/Idle/Idle_Melee")]

public class Idle_Melee : IdleSo
{
    public override void OnStateEnter(Player_StateController ec)
    {
        ec.animator.Play("idle_melee");
    }
    public override void OnStateUpdate(Player_StateController ec)
    {

    }
    public override void OnStateExit(Player_StateController ec)
    {

    }
}
