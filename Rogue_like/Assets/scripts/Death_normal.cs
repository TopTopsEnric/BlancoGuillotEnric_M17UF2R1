using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "death_normal", menuName = "StatesSO/Death/death_normal")]

public class Death_normal : DeathSO
{
    public override void OnStateEnter(Player_StateController ec)
    {
        ec.animator.Play("death");
    }
    public override void OnStateUpdate(Player_StateController ec)
    {

    }
    public override void OnStateExit(Player_StateController ec)
    {

    }

}
