using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "walk_Gun", menuName = "StatesSO/Walk/Walk_Gun")]
public class Walk_Gun : WalkSo
{
    public override void OnStateEnter(Player_StateController ec)
    {
        ec.animator.Play("walk_gun");
    }
    public override void OnStateUpdate(Player_StateController ec)
    {

    }
    public override void OnStateExit(Player_StateController ec)
    {

    }
}
