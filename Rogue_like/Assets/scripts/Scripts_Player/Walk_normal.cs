using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "walk", menuName = "StatesSO/Walk/Walk_Normal")]
public class Walk_normal : WalkSo
{
    public override void OnStateEnter(Player_StateController ec)
    {
        ec.animator.Play("walk");
    }
    public override void OnStateUpdate(Player_StateController ec)
    {

    }
    public override void OnStateExit(Player_StateController ec)
    {

    }

}
