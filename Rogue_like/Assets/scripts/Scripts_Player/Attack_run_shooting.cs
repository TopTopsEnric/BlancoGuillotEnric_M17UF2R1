using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AttackRunShotting", menuName = "StatesSO/Attack/Run_shooting")]
public class Attack_run_shooting : AttackState
{
    public override void OnStateEnter(Player_StateController ec)
    {
        ec.animator.Play("run_shooting");
    }
    public override void OnStateUpdate(Player_StateController ec)
    {

    }
    public override void OnStateExit(Player_StateController ec)
    {

    }
}
