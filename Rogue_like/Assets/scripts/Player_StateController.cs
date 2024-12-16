using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using System;

public class Player_StateController : MonoBehaviour
{
    public StateSO CurrentState;
    public bool arma {get;set;}=false;
    public bool melee { get; set; } = false;
    public bool caminando { get; set; } = false;
    public bool corriendo { get; set; } = false;
    public bool atacando { get; set; } = false;
    public bool recargando { get; set; } = false;
    public bool muerto { get; set; } = false;
    public Animator animator;
    private static Dictionary<string, Type> stateTypes = new Dictionary<string, Type>
    {
    // Los estados de ataque
    { "Attack_Melee", typeof(Attack_Melee) },
    { "Attack_Gun", typeof(Attack_Shooting) },
    { "Attack_Run_Gun", typeof(Attack_run_shooting) },
    
    // Los estados de correr
    { "Run_Melee", typeof(Run_Melee) },
    { "Run_Gun", typeof(Run_Gun) },
    { "Run_Normal", typeof(Run_normalSO) },

    // Los estados de caminar
    { "Walk_Melee", typeof(Walk_Melee) },
    { "Walk_Gun", typeof(Walk_Gun) },
    { "Walk_Normal", typeof(Walk_normal) },

    // Los estados de idle
    { "Idle_Melee", typeof(Idle_Melee) },
    { "Idle_Gun", typeof(Idle_Gun) },
    { "Idle_Normal", typeof(Idle_NormalS) },
    // Estado de Recarga
    { "Recargando", typeof(RealodingSO) },

    // Los estados de muerte
    { "Death_Melee", typeof(Death_Melee) },
    { "Death_Gun", typeof(Death_Gun) },
    { "Death_normal", typeof(Death_normal) }
};
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void seleccionar_estado()
    {
        string stateKey = "";
        if (muerto)
        {
            stateKey = $"Death_{(arma ? "Gun" : (melee ? "Melee" : "Normal"))}";
        }
        if (recargando)
        {
            stateKey = "Recargando";
        }
        // Si el jugador est� atacando, selecciona el estado de ataque correspondiente
        if (atacando)
        {
            // Verificamos si est� corriendo y atacando
            if (corriendo)
            {
                // Si est� corriendo y atacando, usamos la clave espec�fica para "Attack_Run_Gun"
                stateKey = "Attack_Run_Gun";
            }
            else
            {
                // Si no est� corriendo, usamos la l�gica para "Attack_Gun" o "Attack_Melee"
                stateKey = $"Attack_{(arma ? "Gun" : "Melee")}";
            }
        }
        // Si el jugador est� corriendo, selecciona el estado de correr correspondiente
        else if (corriendo)
        {
            // Se tiene en cuenta si lleva un arma o no para determinar el tipo de correr
            stateKey = $"Run_{(arma ? "Gun" : (melee ? "Melee" : "Normal"))}";
        }
        // Si el jugador est� caminando, selecciona el estado de caminar correspondiente
        else if (caminando)
        {
            // Similar a correr, se tiene en cuenta si est� usando melee, arma o sin arma
            stateKey = $"Walk_{(arma ? "Gun" : (melee ? "Melee" : "Normal"))}";
        }
        // Si el jugador no est� haciendo ninguna de estas cosas, selecciona el estado inactivo correspondiente
        else
        {
            // El estado inactivo tambi�n debe considerar si est� usando un arma de fuego o un arma melee
            stateKey = $"Idle_{(arma ? "Gun" : (melee ? "Melee" : "Normal"))}";
        }

        // Verificar si el estado existe en el diccionario
        if (stateTypes.TryGetValue(stateKey, out Type stateType))
        {
            // Llamar a GoToState con el tipo encontrado
            MethodInfo method = typeof(Player_StateController).GetMethod("GoToState");
            MethodInfo genericMethod = method.MakeGenericMethod(stateType);
            genericMethod.Invoke(this, null);
        }
        else
        {
            Debug.LogError($"Estado no encontrado: {stateKey}");
        }

    }
    
    void Update()
    {
        
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
