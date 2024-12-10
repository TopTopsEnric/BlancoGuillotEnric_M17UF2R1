using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Idle_Gun", menuName = "StatesSO/Idle/Idle_Gun")]
public class Idle_Gun : IdleSo
{
    public override void OnStateEnter(Player_StateController ec)
    {
        ec.animator.Play("idle_gun");
    }
    public override void OnStateUpdate(Player_StateController ec)
    {

    }
    public override void OnStateExit(Player_StateController ec)
    {

    }
}
