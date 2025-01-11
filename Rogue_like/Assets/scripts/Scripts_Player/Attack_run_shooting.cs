using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AttackRunShotting", menuName = "StatesSO/Attack/Run_shooting")]
public class Attack_run_shooting : AttackState
{
    private float shootCooldown = 0.5f; // Tiempo en segundos entre disparos
    private float nextShootTime = 0f;
    public override void OnStateEnter(Player_StateController ec)
    {
        ec.animator.Play("run_shooting");
    }
    public override void OnStateUpdate(Player_StateController ec)
    {
        if (Time.time >= nextShootTime)
        {
            ec.controlador.Shoot(); // Ejecuta el disparo
            nextShootTime = Time.time + shootCooldown; // Actualiza el tiempo del siguiente disparo
        }
    }
    public override void OnStateExit(Player_StateController ec)
    {

    }
}
