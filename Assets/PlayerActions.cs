// GENERATED AUTOMATICALLY FROM 'Assets/Albatross/Player Controlls.inputactions'

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
                    ""name"": ""Action"",
                    ""type"": ""Button"",
                    ""id"": ""079279d2-a840-4a17-95c8-a3f8d3c1d5d0"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
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
                    ""name"": ""OptionsMenu"",
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
                    ""action"": ""Action"",
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
                    ""action"": ""Action"",
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
                    ""action"": ""Action"",
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
                    ""action"": ""Jump"",
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
                    ""action"": ""Jump"",
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
                    ""action"": ""Jump"",
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
                    ""action"": ""OptionsMenu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ecb016e9-418b-49ef-9b0e-a5f41a97e2bc"",
                    ""path"": ""<Keyboard>/m"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""OptionsMenu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""UI"",
            ""id"": ""b2093992-1db1-4a74-9abc-b029384bff53"",
            ""actions"": [
                {
                    ""name"": ""ConfirmSelection"",
                    ""type"": ""Button"",
                    ""id"": ""0c7d8168-0175-40a9-8264-7268663c3c23"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SelectCycle"",
                    ""type"": ""Button"",
                    ""id"": ""a04701fc-0324-46b1-b725-3844c6c29afd"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""CloseMenu"",
                    ""type"": ""Button"",
                    ""id"": ""40e6461b-9e8c-4238-abe4-ef198d14b6ee"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""40261b58-f06f-4408-92cd-cf15337fd61f"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ConfirmSelection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""de682790-0e40-4c07-9a61-56202b9ae09e"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SelectCycle"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""80561148-7a09-49bc-b926-e15722be3d5d"",
                    ""path"": ""<Gamepad>/dpad"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SelectCycle"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Arrows"",
                    ""id"": ""fe1c4f15-dd3b-43b4-bf62-cb30e3646198"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SelectCycle"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""be7230cf-12f4-4379-b538-8f957ddaaa25"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SelectCycle"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""6ad7d5d2-d09b-407f-9d8a-5b9ead550559"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SelectCycle"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""e65f97fd-23f1-4f7d-a5d8-2f880392ff55"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SelectCycle"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""2819fbd8-e9f3-40fc-8fba-a0c288502435"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SelectCycle"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""b2837da3-e1fa-4cbf-b685-4adbb559abb9"",
                    ""path"": ""<Keyboard>/m"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CloseMenu"",
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
        m_InputsMap_Action = m_InputsMap.GetAction("Action");
        m_InputsMap_Jump = m_InputsMap.GetAction("Jump");
        m_InputsMap_Walk = m_InputsMap.GetAction("Walk");
        m_InputsMap_OptionsMenu = m_InputsMap.GetAction("OptionsMenu");
        // UI
        m_UI = asset.GetActionMap("UI");
        m_UI_ConfirmSelection = m_UI.GetAction("ConfirmSelection");
        m_UI_SelectCycle = m_UI.GetAction("SelectCycle");
        m_UI_CloseMenu = m_UI.GetAction("CloseMenu");
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
    private readonly InputAction m_InputsMap_Action;
    private readonly InputAction m_InputsMap_Jump;
    private readonly InputAction m_InputsMap_Walk;
    private readonly InputAction m_InputsMap_OptionsMenu;
    public struct InputsMapActions
    {
        private PlayerActions m_Wrapper;
        public InputsMapActions(PlayerActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Action => m_Wrapper.m_InputsMap_Action;
        public InputAction @Jump => m_Wrapper.m_InputsMap_Jump;
        public InputAction @Walk => m_Wrapper.m_InputsMap_Walk;
        public InputAction @OptionsMenu => m_Wrapper.m_InputsMap_OptionsMenu;
        public InputActionMap Get() { return m_Wrapper.m_InputsMap; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(InputsMapActions set) { return set.Get(); }
        public void SetCallbacks(IInputsMapActions instance)
        {
            if (m_Wrapper.m_InputsMapActionsCallbackInterface != null)
            {
                Action.started -= m_Wrapper.m_InputsMapActionsCallbackInterface.OnAction;
                Action.performed -= m_Wrapper.m_InputsMapActionsCallbackInterface.OnAction;
                Action.canceled -= m_Wrapper.m_InputsMapActionsCallbackInterface.OnAction;
                Jump.started -= m_Wrapper.m_InputsMapActionsCallbackInterface.OnJump;
                Jump.performed -= m_Wrapper.m_InputsMapActionsCallbackInterface.OnJump;
                Jump.canceled -= m_Wrapper.m_InputsMapActionsCallbackInterface.OnJump;
                Walk.started -= m_Wrapper.m_InputsMapActionsCallbackInterface.OnWalk;
                Walk.performed -= m_Wrapper.m_InputsMapActionsCallbackInterface.OnWalk;
                Walk.canceled -= m_Wrapper.m_InputsMapActionsCallbackInterface.OnWalk;
                OptionsMenu.started -= m_Wrapper.m_InputsMapActionsCallbackInterface.OnOptionsMenu;
                OptionsMenu.performed -= m_Wrapper.m_InputsMapActionsCallbackInterface.OnOptionsMenu;
                OptionsMenu.canceled -= m_Wrapper.m_InputsMapActionsCallbackInterface.OnOptionsMenu;
            }
            m_Wrapper.m_InputsMapActionsCallbackInterface = instance;
            if (instance != null)
            {
                Action.started += instance.OnAction;
                Action.performed += instance.OnAction;
                Action.canceled += instance.OnAction;
                Jump.started += instance.OnJump;
                Jump.performed += instance.OnJump;
                Jump.canceled += instance.OnJump;
                Walk.started += instance.OnWalk;
                Walk.performed += instance.OnWalk;
                Walk.canceled += instance.OnWalk;
                OptionsMenu.started += instance.OnOptionsMenu;
                OptionsMenu.performed += instance.OnOptionsMenu;
                OptionsMenu.canceled += instance.OnOptionsMenu;
            }
        }
    }
    public InputsMapActions @InputsMap => new InputsMapActions(this);

    // UI
    private readonly InputActionMap m_UI;
    private IUIActions m_UIActionsCallbackInterface;
    private readonly InputAction m_UI_ConfirmSelection;
    private readonly InputAction m_UI_SelectCycle;
    private readonly InputAction m_UI_CloseMenu;
    public struct UIActions
    {
        private PlayerActions m_Wrapper;
        public UIActions(PlayerActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @ConfirmSelection => m_Wrapper.m_UI_ConfirmSelection;
        public InputAction @SelectCycle => m_Wrapper.m_UI_SelectCycle;
        public InputAction @CloseMenu => m_Wrapper.m_UI_CloseMenu;
        public InputActionMap Get() { return m_Wrapper.m_UI; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UIActions set) { return set.Get(); }
        public void SetCallbacks(IUIActions instance)
        {
            if (m_Wrapper.m_UIActionsCallbackInterface != null)
            {
                ConfirmSelection.started -= m_Wrapper.m_UIActionsCallbackInterface.OnConfirmSelection;
                ConfirmSelection.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnConfirmSelection;
                ConfirmSelection.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnConfirmSelection;
                SelectCycle.started -= m_Wrapper.m_UIActionsCallbackInterface.OnSelectCycle;
                SelectCycle.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnSelectCycle;
                SelectCycle.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnSelectCycle;
                CloseMenu.started -= m_Wrapper.m_UIActionsCallbackInterface.OnCloseMenu;
                CloseMenu.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnCloseMenu;
                CloseMenu.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnCloseMenu;
            }
            m_Wrapper.m_UIActionsCallbackInterface = instance;
            if (instance != null)
            {
                ConfirmSelection.started += instance.OnConfirmSelection;
                ConfirmSelection.performed += instance.OnConfirmSelection;
                ConfirmSelection.canceled += instance.OnConfirmSelection;
                SelectCycle.started += instance.OnSelectCycle;
                SelectCycle.performed += instance.OnSelectCycle;
                SelectCycle.canceled += instance.OnSelectCycle;
                CloseMenu.started += instance.OnCloseMenu;
                CloseMenu.performed += instance.OnCloseMenu;
                CloseMenu.canceled += instance.OnCloseMenu;
            }
        }
    }
    public UIActions @UI => new UIActions(this);
    public interface IInputsMapActions
    {
        void OnAction(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnWalk(InputAction.CallbackContext context);
        void OnOptionsMenu(InputAction.CallbackContext context);
    }
    public interface IUIActions
    {
        void OnConfirmSelection(InputAction.CallbackContext context);
        void OnSelectCycle(InputAction.CallbackContext context);
        void OnCloseMenu(InputAction.CallbackContext context);
    }
}
