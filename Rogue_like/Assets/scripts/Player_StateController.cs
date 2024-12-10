using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_StateController : MonoBehaviour
{
    public StateSO CurrentState;
    public bool arma {get;set;}
    public bool melee { get; set; }
    public bool caminando { get; set; }
    public bool corriendo { get; set; }
    public bool atacando { get; set; }
    public bool dash { get; set; }
    public bool muerto { get; set; }
    public Animator animator;
    void Start()
    {
        
    }
    public void seleccionar_estado()
    {
        if(muerto== false)
        {
            if (melee == true)
            {
                if (caminando == true)
                {
                    if (atacando == true)
                    {
                        GoToState<Attack_Melee>();
                    }
                    else
                    {
                        GoToState<Walk_Melee>();
                    }
                }
                else if (corriendo == true)
                {
                    GoToState<Run_Melee>();
               }
                else
                {
                    GoToState<Idle_Melee>();
                }
            }
            else if (arma == true)
            {
                if (caminando == true)
                {
                    if (atacando == true)
                    {
                        GoToState<Attack_Shooting>();
                    }
                    else
                    {
                        GoToState<Walk_Gun>();
                    }
                }
                else if (corriendo == true)
                {
                    if (atacando == true)
                    {
                        GoToState<Attack_run_shooting>();
                    }
                    else
                    {
                        GoToState<Run_Gun>();
                    }
                }
                else
                {
                    GoToState<Idle_Gun>();
                }
            }
            else
            {
                if (caminando == true)
                {
                    if (atacando == true)
                    {
                       // emitir sonido de error
                    }
                    else
                    {
                        GoToState<Walk_normal>();
                    }
                }
                else if (corriendo == true)
                {
                    if (atacando == true)
                    {
                        // no puede atacar, sonido de error
                    }
                    else
                    {
                        GoToState<Run_normalSO>();
                    }
                }
                else
                {
                    GoToState<Idle_Gun>();
                }
            }
        }
        else
        {
            if(melee== true)
            {
                GoToState<Death_Melee>();
            }
            else if (arma == true)
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
