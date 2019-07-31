// GENERATED AUTOMATICALLY FROM 'Assets/Player Controlls.inputactions'

using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class PlayerActions : IInputActionCollection
{
    private InputActionAsset asset;
    public PlayerActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Player Controlls"",
    ""maps"": [
        {
            ""name"": ""Inputs Map"",
            ""id"": ""46b7513f-3fdb-4882-829d-31ce4280628a"",
            ""actions"": [
                {
                    ""name"": ""Walk"",
                    ""type"": ""Button"",
                    ""id"": ""bec6a991-3d71-49c5-a484-7dbe23fab0dc"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Action0"",
                    ""type"": ""Button"",
                    ""id"": ""079279d2-a840-4a17-95c8-a3f8d3c1d5d0"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Action1"",
                    ""type"": ""Button"",
                    ""id"": ""41c72032-5478-43cf-b4df-712c22054d7c"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""db2330f1-c20a-4f6e-b0b3-6565621a8e0d"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4b6e3413-61d5-4ccc-8afb-7b1f2a884eee"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Action0"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""aed51c11-76b3-4bec-9cac-7a8a338df16c"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Action1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Inputs Map
        m_InputsMap = asset.GetActionMap("Inputs Map");
        m_InputsMap_Walk = m_InputsMap.GetAction("Walk");
        m_InputsMap_Action0 = m_InputsMap.GetAction("Action0");
        m_InputsMap_Action1 = m_InputsMap.GetAction("Action1");
    }

    ~PlayerActions()
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

    // Inputs Map
    private readonly InputActionMap m_InputsMap;
    private IInputsMapActions m_InputsMapActionsCallbackInterface;
    private readonly InputAction m_InputsMap_Walk;
    private readonly InputAction m_InputsMap_Action0;
    private readonly InputAction m_InputsMap_Action1;
    public struct InputsMapActions
    {
        private PlayerActions m_Wrapper;
        public InputsMapActions(PlayerActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Walk => m_Wrapper.m_InputsMap_Walk;
        public InputAction @Action0 => m_Wrapper.m_InputsMap_Action0;
        public InputAction @Action1 => m_Wrapper.m_InputsMap_Action1;
        public InputActionMap Get() { return m_Wrapper.m_InputsMap; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(InputsMapActions set) { return set.Get(); }
        public void SetCallbacks(IInputsMapActions instance)
        {
            if (m_Wrapper.m_InputsMapActionsCallbackInterface != null)
            {
                Walk.started -= m_Wrapper.m_InputsMapActionsCallbackInterface.OnWalk;
                Walk.performed -= m_Wrapper.m_InputsMapActionsCallbackInterface.OnWalk;
                Walk.canceled -= m_Wrapper.m_InputsMapActionsCallbackInterface.OnWalk;
                Action0.started -= m_Wrapper.m_InputsMapActionsCallbackInterface.OnAction0;
                Action0.performed -= m_Wrapper.m_InputsMapActionsCallbackInterface.OnAction0;
                Action0.canceled -= m_Wrapper.m_InputsMapActionsCallbackInterface.OnAction0;
                Action1.started -= m_Wrapper.m_InputsMapActionsCallbackInterface.OnAction1;
                Action1.performed -= m_Wrapper.m_InputsMapActionsCallbackInterface.OnAction1;
                Action1.canceled -= m_Wrapper.m_InputsMapActionsCallbackInterface.OnAction1;
            }
            m_Wrapper.m_InputsMapActionsCallbackInterface = instance;
            if (instance != null)
            {
                Walk.started += instance.OnWalk;
                Walk.performed += instance.OnWalk;
                Walk.canceled += instance.OnWalk;
                Action0.started += instance.OnAction0;
                Action0.performed += instance.OnAction0;
                Action0.canceled += instance.OnAction0;
                Action1.started += instance.OnAction1;
                Action1.performed += instance.OnAction1;
                Action1.canceled += instance.OnAction1;
            }
        }
    }
    public InputsMapActions @InputsMap => new InputsMapActions(this);
    public interface IInputsMapActions
    {
        void OnWalk(InputAction.CallbackContext context);
        void OnAction0(InputAction.CallbackContext context);
        void OnAction1(InputAction.CallbackContext context);
    }
}
