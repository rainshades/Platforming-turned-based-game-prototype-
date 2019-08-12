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
                },
                {
                    ""name"": ""Walk"",
                    ""type"": ""Button"",
                    ""id"": ""c8408a61-4019-4ca0-a6b6-a3bb700ed6c9"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Action2"",
                    ""type"": ""Button"",
                    ""id"": ""0d78cc39-ada6-4680-a338-cd4c65f1a76a"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
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
                    ""id"": ""f83fc7d1-112f-4f4c-bb99-4976da1b442b"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Action0"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""104a4e97-60da-43b2-9ba8-f87275386d50"",
                    ""path"": ""<Keyboard>/leftShift"",
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
                },
                {
                    ""name"": """",
                    ""id"": ""3babcffc-97be-4274-a6e8-b9186d611e5a"",
                    ""path"": ""<Keyboard>/rightShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Action1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e2d06014-6070-49da-a3d2-9b1b12e9bc69"",
                    ""path"": ""<Keyboard>/leftCtrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Action1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""73fa2bc0-32e8-4431-9860-c2542cba27e9"",
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
                    ""id"": ""898b2312-c9c4-477e-a9bb-c5cd045b4e8f"",
                    ""path"": ""<Gamepad>/dpad"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Arrows"",
                    ""id"": ""6d6754c7-17e4-4a5d-b1b6-066880f36ec8"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""2139ee04-ceb4-410d-8be5-2b30d6e1f8c9"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""91db99f0-e4cb-4a94-aa70-5381bc766df7"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""56707823-6490-40a0-b291-859a4b4fcab9"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""666080c5-60fd-4e01-8eee-55137947a57f"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""8d33bb5a-5657-44e9-9b19-52561cc69d72"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Action2"",
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
        m_InputsMap_Action0 = m_InputsMap.GetAction("Action0");
        m_InputsMap_Action1 = m_InputsMap.GetAction("Action1");
        m_InputsMap_Walk = m_InputsMap.GetAction("Walk");
        m_InputsMap_Action2 = m_InputsMap.GetAction("Action2");
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
    private readonly InputAction m_InputsMap_Action0;
    private readonly InputAction m_InputsMap_Action1;
    private readonly InputAction m_InputsMap_Walk;
    private readonly InputAction m_InputsMap_Action2;
    public struct InputsMapActions
    {
        private PlayerActions m_Wrapper;
        public InputsMapActions(PlayerActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Action0 => m_Wrapper.m_InputsMap_Action0;
        public InputAction @Action1 => m_Wrapper.m_InputsMap_Action1;
        public InputAction @Walk => m_Wrapper.m_InputsMap_Walk;
        public InputAction @Action2 => m_Wrapper.m_InputsMap_Action2;
        public InputActionMap Get() { return m_Wrapper.m_InputsMap; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(InputsMapActions set) { return set.Get(); }
        public void SetCallbacks(IInputsMapActions instance)
        {
            if (m_Wrapper.m_InputsMapActionsCallbackInterface != null)
            {
                Action0.started -= m_Wrapper.m_InputsMapActionsCallbackInterface.OnAction0;
                Action0.performed -= m_Wrapper.m_InputsMapActionsCallbackInterface.OnAction0;
                Action0.canceled -= m_Wrapper.m_InputsMapActionsCallbackInterface.OnAction0;
                Action1.started -= m_Wrapper.m_InputsMapActionsCallbackInterface.OnAction1;
                Action1.performed -= m_Wrapper.m_InputsMapActionsCallbackInterface.OnAction1;
                Action1.canceled -= m_Wrapper.m_InputsMapActionsCallbackInterface.OnAction1;
                Walk.started -= m_Wrapper.m_InputsMapActionsCallbackInterface.OnWalk;
                Walk.performed -= m_Wrapper.m_InputsMapActionsCallbackInterface.OnWalk;
                Walk.canceled -= m_Wrapper.m_InputsMapActionsCallbackInterface.OnWalk;
                Action2.started -= m_Wrapper.m_InputsMapActionsCallbackInterface.OnAction2;
                Action2.performed -= m_Wrapper.m_InputsMapActionsCallbackInterface.OnAction2;
                Action2.canceled -= m_Wrapper.m_InputsMapActionsCallbackInterface.OnAction2;
            }
            m_Wrapper.m_InputsMapActionsCallbackInterface = instance;
            if (instance != null)
            {
                Action0.started += instance.OnAction0;
                Action0.performed += instance.OnAction0;
                Action0.canceled += instance.OnAction0;
                Action1.started += instance.OnAction1;
                Action1.performed += instance.OnAction1;
                Action1.canceled += instance.OnAction1;
                Walk.started += instance.OnWalk;
                Walk.performed += instance.OnWalk;
                Walk.canceled += instance.OnWalk;
                Action2.started += instance.OnAction2;
                Action2.performed += instance.OnAction2;
                Action2.canceled += instance.OnAction2;
            }
        }
    }
    public InputsMapActions @InputsMap => new InputsMapActions(this);
    public interface IInputsMapActions
    {
        void OnAction0(InputAction.CallbackContext context);
        void OnAction1(InputAction.CallbackContext context);
        void OnWalk(InputAction.CallbackContext context);
        void OnAction2(InputAction.CallbackContext context);
    }
}
