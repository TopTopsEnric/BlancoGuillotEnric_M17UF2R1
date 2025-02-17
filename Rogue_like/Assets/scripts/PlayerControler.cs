//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/scripts/PlayerControler.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @PlayerControler: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControler()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControler"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""6d8476af-7eab-4419-8358-12e3539780ce"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""b8210bca-7076-4471-a417-193eebbc4139"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Sprintar"",
                    ""type"": ""Button"",
                    ""id"": ""daf2c3d4-ccf9-4e47-a4e7-bc4260caaa0d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Mirar"",
                    ""type"": ""Value"",
                    ""id"": ""d39eeab0-41c0-4eef-99df-342295f3869a"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Atacar"",
                    ""type"": ""Button"",
                    ""id"": ""12611d71-6770-47e1-9f47-072813f210ce"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Recargar"",
                    ""type"": ""Button"",
                    ""id"": ""563ecf07-89bd-4f0a-8e72-0f7715fc414b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Cambiar a Melee"",
                    ""type"": ""Button"",
                    ""id"": ""197c3f28-bbf4-40a4-ba52-69646d73043b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Cambiar a desarmado"",
                    ""type"": ""Button"",
                    ""id"": ""e8597403-1374-488f-ac80-2300ae7a84b3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Cambiar a Distancia"",
                    ""type"": ""Button"",
                    ""id"": ""6271f665-bf5d-46b4-90fb-1591f123ff2c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Cambiar arma distancia"",
                    ""type"": ""Button"",
                    ""id"": ""ded211f7-7163-456e-8488-97d4bb858510"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""91d2a551-9624-466e-90bc-53a490b704b9"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""fe55d688-eaf2-451b-a62b-40a76c3632a5"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""4b489586-885c-4b9b-9ef5-c50a22479580"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""3e814568-ddfc-476c-8f5b-a89839eb60cc"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""e7cb4818-fcdd-4db9-b6c4-4977b271f41d"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""3bc08793-b19b-4f64-933f-d05996e5c054"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Sprintar"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ed347e81-6bc1-4acc-8dd8-3449a602dc5a"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Mirar"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d33a13ac-e199-437e-bcc8-b40e479e7715"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Atacar"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8129e704-77e2-4167-82be-a735e1221930"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Recargar"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""10a12029-412b-49f3-8ee7-6f0e436901e3"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Cambiar a Melee"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d294e909-b49c-46cc-8292-e033963a1a7b"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Cambiar a desarmado"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""04d522f3-28ae-48ee-b38d-22ee51bce26a"",
                    ""path"": ""<Keyboard>/3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Cambiar a Distancia"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5d448b71-5b44-4fcd-b1c3-16d7699482a9"",
                    ""path"": ""<Keyboard>/4"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Cambiar arma distancia"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Move = m_Player.FindAction("Move", throwIfNotFound: true);
        m_Player_Sprintar = m_Player.FindAction("Sprintar", throwIfNotFound: true);
        m_Player_Mirar = m_Player.FindAction("Mirar", throwIfNotFound: true);
        m_Player_Atacar = m_Player.FindAction("Atacar", throwIfNotFound: true);
        m_Player_Recargar = m_Player.FindAction("Recargar", throwIfNotFound: true);
        m_Player_CambiaraMelee = m_Player.FindAction("Cambiar a Melee", throwIfNotFound: true);
        m_Player_Cambiaradesarmado = m_Player.FindAction("Cambiar a desarmado", throwIfNotFound: true);
        m_Player_CambiaraDistancia = m_Player.FindAction("Cambiar a Distancia", throwIfNotFound: true);
        m_Player_Cambiararmadistancia = m_Player.FindAction("Cambiar arma distancia", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Player
    private readonly InputActionMap m_Player;
    private List<IPlayerActions> m_PlayerActionsCallbackInterfaces = new List<IPlayerActions>();
    private readonly InputAction m_Player_Move;
    private readonly InputAction m_Player_Sprintar;
    private readonly InputAction m_Player_Mirar;
    private readonly InputAction m_Player_Atacar;
    private readonly InputAction m_Player_Recargar;
    private readonly InputAction m_Player_CambiaraMelee;
    private readonly InputAction m_Player_Cambiaradesarmado;
    private readonly InputAction m_Player_CambiaraDistancia;
    private readonly InputAction m_Player_Cambiararmadistancia;
    public struct PlayerActions
    {
        private @PlayerControler m_Wrapper;
        public PlayerActions(@PlayerControler wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Player_Move;
        public InputAction @Sprintar => m_Wrapper.m_Player_Sprintar;
        public InputAction @Mirar => m_Wrapper.m_Player_Mirar;
        public InputAction @Atacar => m_Wrapper.m_Player_Atacar;
        public InputAction @Recargar => m_Wrapper.m_Player_Recargar;
        public InputAction @CambiaraMelee => m_Wrapper.m_Player_CambiaraMelee;
        public InputAction @Cambiaradesarmado => m_Wrapper.m_Player_Cambiaradesarmado;
        public InputAction @CambiaraDistancia => m_Wrapper.m_Player_CambiaraDistancia;
        public InputAction @Cambiararmadistancia => m_Wrapper.m_Player_Cambiararmadistancia;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void AddCallbacks(IPlayerActions instance)
        {
            if (instance == null || m_Wrapper.m_PlayerActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_PlayerActionsCallbackInterfaces.Add(instance);
            @Move.started += instance.OnMove;
            @Move.performed += instance.OnMove;
            @Move.canceled += instance.OnMove;
            @Sprintar.started += instance.OnSprintar;
            @Sprintar.performed += instance.OnSprintar;
            @Sprintar.canceled += instance.OnSprintar;
            @Mirar.started += instance.OnMirar;
            @Mirar.performed += instance.OnMirar;
            @Mirar.canceled += instance.OnMirar;
            @Atacar.started += instance.OnAtacar;
            @Atacar.performed += instance.OnAtacar;
            @Atacar.canceled += instance.OnAtacar;
            @Recargar.started += instance.OnRecargar;
            @Recargar.performed += instance.OnRecargar;
            @Recargar.canceled += instance.OnRecargar;
            @CambiaraMelee.started += instance.OnCambiaraMelee;
            @CambiaraMelee.performed += instance.OnCambiaraMelee;
            @CambiaraMelee.canceled += instance.OnCambiaraMelee;
            @Cambiaradesarmado.started += instance.OnCambiaradesarmado;
            @Cambiaradesarmado.performed += instance.OnCambiaradesarmado;
            @Cambiaradesarmado.canceled += instance.OnCambiaradesarmado;
            @CambiaraDistancia.started += instance.OnCambiaraDistancia;
            @CambiaraDistancia.performed += instance.OnCambiaraDistancia;
            @CambiaraDistancia.canceled += instance.OnCambiaraDistancia;
            @Cambiararmadistancia.started += instance.OnCambiararmadistancia;
            @Cambiararmadistancia.performed += instance.OnCambiararmadistancia;
            @Cambiararmadistancia.canceled += instance.OnCambiararmadistancia;
        }

        private void UnregisterCallbacks(IPlayerActions instance)
        {
            @Move.started -= instance.OnMove;
            @Move.performed -= instance.OnMove;
            @Move.canceled -= instance.OnMove;
            @Sprintar.started -= instance.OnSprintar;
            @Sprintar.performed -= instance.OnSprintar;
            @Sprintar.canceled -= instance.OnSprintar;
            @Mirar.started -= instance.OnMirar;
            @Mirar.performed -= instance.OnMirar;
            @Mirar.canceled -= instance.OnMirar;
            @Atacar.started -= instance.OnAtacar;
            @Atacar.performed -= instance.OnAtacar;
            @Atacar.canceled -= instance.OnAtacar;
            @Recargar.started -= instance.OnRecargar;
            @Recargar.performed -= instance.OnRecargar;
            @Recargar.canceled -= instance.OnRecargar;
            @CambiaraMelee.started -= instance.OnCambiaraMelee;
            @CambiaraMelee.performed -= instance.OnCambiaraMelee;
            @CambiaraMelee.canceled -= instance.OnCambiaraMelee;
            @Cambiaradesarmado.started -= instance.OnCambiaradesarmado;
            @Cambiaradesarmado.performed -= instance.OnCambiaradesarmado;
            @Cambiaradesarmado.canceled -= instance.OnCambiaradesarmado;
            @CambiaraDistancia.started -= instance.OnCambiaraDistancia;
            @CambiaraDistancia.performed -= instance.OnCambiaraDistancia;
            @CambiaraDistancia.canceled -= instance.OnCambiaraDistancia;
            @Cambiararmadistancia.started -= instance.OnCambiararmadistancia;
            @Cambiararmadistancia.performed -= instance.OnCambiararmadistancia;
            @Cambiararmadistancia.canceled -= instance.OnCambiararmadistancia;
        }

        public void RemoveCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IPlayerActions instance)
        {
            foreach (var item in m_Wrapper.m_PlayerActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_PlayerActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    public interface IPlayerActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnSprintar(InputAction.CallbackContext context);
        void OnMirar(InputAction.CallbackContext context);
        void OnAtacar(InputAction.CallbackContext context);
        void OnRecargar(InputAction.CallbackContext context);
        void OnCambiaraMelee(InputAction.CallbackContext context);
        void OnCambiaradesarmado(InputAction.CallbackContext context);
        void OnCambiaraDistancia(InputAction.CallbackContext context);
        void OnCambiararmadistancia(InputAction.CallbackContext context);
    }
}
