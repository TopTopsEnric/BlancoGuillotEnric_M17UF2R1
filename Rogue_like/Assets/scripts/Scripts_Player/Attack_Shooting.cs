using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "AttackShooting", menuName = "StatesSO/Attack/shooting")]

public class Attack_Shooting : AttackState
{
    private float shootCooldown = 0.5f; // Tiempo en segundos entre disparos
    private float nextShootTime = 0f;
    public override void OnStateEnter(Player_StateController ec)
    {
        ec.animator.Play("atack_gun");
    }
    public override void OnStateUpdate(Player_StateController ec)
    {
        
        
            ec.controlador.HandleShooting(); // Ejecuta el disparo
            
        
    }
    public override void OnStateExit(Player_StateController ec)
    {

    }
}
