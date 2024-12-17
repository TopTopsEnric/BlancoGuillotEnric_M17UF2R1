using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "AttackShooting", menuName = "StatesSO/Attack/shooting")]

public class Attack_Shooting : AttackState
{
    public override void OnStateEnter(Player_StateController ec)
    {
        ec.animator.Play("atack_gun");
    }
    public override void OnStateUpdate(Player_StateController ec)
    {

    }
    public override void OnStateExit(Player_StateController ec)
    {

    }
}
