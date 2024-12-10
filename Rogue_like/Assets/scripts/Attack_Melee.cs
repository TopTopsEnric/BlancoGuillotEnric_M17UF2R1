using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "AttackMelee", menuName = "StatesSO/Attack/Melee")]
public class Attack_Melee : AttackState
{
    public override void OnStateEnter(Player_StateController ec)
    {
        ec.animator.Play("atack_melee");
    }
    public override void OnStateUpdate(Player_StateController ec)
    {

    }
    public override void OnStateExit(Player_StateController ec)
    {

    }
}
