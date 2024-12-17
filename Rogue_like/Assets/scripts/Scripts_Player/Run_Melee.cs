using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Run_Melee", menuName = "StatesSO/Run/Run_Melee")]
public class Run_Melee : RunSO
{
    public override void OnStateEnter(Player_StateController ec)
    {
        ec.animator.Play("run_melee");
    }
    public override void OnStateUpdate(Player_StateController ec)
    {

    }
    public override void OnStateExit(Player_StateController ec)
    {

    }
}
