using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "death_Melee", menuName = "StatesSO/Death/death_Melee")]
public class Death_Melee : DeathSO
{
    public override void OnStateEnter(Player_StateController ec)
    {
        ec.animator.Play("death_melee");
    }
    public override void OnStateUpdate(Player_StateController ec)
    {

    }
    public override void OnStateExit(Player_StateController ec)
    {

    }

}
