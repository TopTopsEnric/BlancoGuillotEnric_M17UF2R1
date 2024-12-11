using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_StateController : MonoBehaviour
{
    public StateSO CurrentState;
    public bool arma {get;set;}=false;
    public bool melee { get; set; } = false;
    public bool caminando { get; set; } = false;
    public bool corriendo { get; set; } = false;
    public bool atacando { get; set; } = false;
    public bool dash { get; set; } = false;
    public bool muerto { get; set; } = false;
    public Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void seleccionar_estado()
    {
        if (muerto == false)
        {
            if (melee)
            {
                TransitionToMovementState("Melee");
            }
            else if (arma)
            {
                TransitionToMovementState("Gun");
            }
            else
            {
                TransitionToMovementState("Normal");
            }
        }
        else
        {
            // Estado de muerte
            if (melee)
            {
                GoToState<Death_Melee>();
            }
            else if (arma)
            {
                GoToState<Death_Gun>();
            }
            else
            {
                GoToState<Death_normal>();
            }
        }

    }
    
    void Update()
    {
        seleccionar_estado();
        CurrentState.OnStateUpdate(this);
    }

    private void TransitionToMovementState(string baseState)
{
    if (atacando)
    {
        // Si está atacando, selecciona el estado de ataque correspondiente
        GoToState($"Attack_{baseState}");
    }
    else if (corriendo)
    {
        // Si está corriendo, selecciona el estado de correr correspondiente
        GoToState($"Run_{baseState}");
    }
    else if (caminando)
    {
        // Si está caminando, selecciona el estado de caminar correspondiente
        GoToState($"Walk_{baseState}");
    }
    else
    {
        // Si no está en movimiento, selecciona el estado inactivo correspondiente
        GoToState($"Idle_{baseState}");
    }
}
    public void GoToState<T>() where T : StateSO
    {
        if (CurrentState.StatesToGo.Find(state => state is T))
        {
            CurrentState.OnStateExit(this);
            CurrentState = CurrentState.StatesToGo.Find(obj => obj is T);
            CurrentState.OnStateEnter(this);
        }
    }
}
