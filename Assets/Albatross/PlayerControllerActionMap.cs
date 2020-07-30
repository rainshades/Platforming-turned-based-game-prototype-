// GENERATED AUTOMATICALLY FROM 'Assets/Albatross/PlayerControllerActionMap.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace Albatross
{
    public class @PlayerControllerActionMap : IInputActionCollection, IDisposable
    {
        public InputActionAsset asset { get; }
        public @PlayerControllerActionMap()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControllerActionMap"",
    ""maps"": [
        {
            ""name"": ""WorldInteraction"",
            ""id"": ""6a269ad1-b315-4313-8957-f5e1fd8de384"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Button"",
                    ""id"": ""3a5c4fda-46c6-4bd6-87c3-39183c52b57d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Augment"",
                    ""type"": ""Button"",
                    ""id"": ""85f11b3c-b49a-4903-ac6c-29b4ee6451af"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""fa3d7207-6cdf-4854-b24c-7efbf5f684fc"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""OptionsMenu"",
                    ""type"": ""Button"",
                    ""id"": ""fb1b1d28-7333-49e1-9cd2-12ba78a88f80"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""69ddb07e-3910-41e5-8508-a22fd83874c4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Melee"",
                    ""type"": ""Button"",
                    ""id"": ""01a1a217-114c-4581-8cde-d0a6712ce853"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""fc4298da-9653-4ce3-93db-177813d5358b"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Augment"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cca62b67-ff9f-4d09-8e93-b17dadf4dafb"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""38941f64-c11c-4a0a-8b39-7ee97b633603"",
                    ""path"": ""<Keyboard>/tab"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""OptionsMenu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""14160dfb-7ed9-4dca-a50f-85138a2c2981"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""4399fe78-faed-4bd6-8abd-65661e0481ff"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""ff637c5e-79d8-426a-bfac-4516a9030995"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""f38ae01a-9866-4b7a-84bb-3a72630b6432"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""b99d8ebe-46eb-4d56-943a-648569635f06"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""f2025da7-6341-469a-8c1f-9c280894b930"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""182469fe-eb32-419b-94f4-963b37bfaddf"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Melee"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""UI"",
            ""id"": ""d9f2784a-5750-4cfe-a412-7066b8ba76df"",
            ""actions"": [
                {
                    ""name"": ""ConfirmSelection"",
                    ""type"": ""Button"",
                    ""id"": ""305dbde5-5372-4598-bbd0-19210456bc0e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""b210cdd0-6a88-40ff-b160-1874ec505d94"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ConfirmSelection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
            // WorldInteraction
            m_WorldInteraction = asset.FindActionMap("WorldInteraction", throwIfNotFound: true);
            m_WorldInteraction_Movement = m_WorldInteraction.FindAction("Movement", throwIfNotFound: true);
            m_WorldInteraction_Augment = m_WorldInteraction.FindAction("Augment", throwIfNotFound: true);
            m_WorldInteraction_Jump = m_WorldInteraction.FindAction("Jump", throwIfNotFound: true);
            m_WorldInteraction_OptionsMenu = m_WorldInteraction.FindAction("OptionsMenu", throwIfNotFound: true);
            m_WorldInteraction_Interact = m_WorldInteraction.FindAction("Interact", throwIfNotFound: true);
            m_WorldInteraction_Melee = m_WorldInteraction.FindAction("Melee", throwIfNotFound: true);
            // UI
            m_UI = asset.FindActionMap("UI", throwIfNotFound: true);
            m_UI_ConfirmSelection = m_UI.FindAction("ConfirmSelection", throwIfNotFound: true);
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

        // WorldInteraction
        private readonly InputActionMap m_WorldInteraction;
        private IWorldInteractionActions m_WorldInteractionActionsCallbackInterface;
        private readonly InputAction m_WorldInteraction_Movement;
        private readonly InputAction m_WorldInteraction_Augment;
        private readonly InputAction m_WorldInteraction_Jump;
        private readonly InputAction m_WorldInteraction_OptionsMenu;
        private readonly InputAction m_WorldInteraction_Interact;
        private readonly InputAction m_WorldInteraction_Melee;
        public struct WorldInteractionActions
        {
            private @PlayerControllerActionMap m_Wrapper;
            public WorldInteractionActions(@PlayerControllerActionMap wrapper) { m_Wrapper = wrapper; }
            public InputAction @Movement => m_Wrapper.m_WorldInteraction_Movement;
            public InputAction @Augment => m_Wrapper.m_WorldInteraction_Augment;
            public InputAction @Jump => m_Wrapper.m_WorldInteraction_Jump;
            public InputAction @OptionsMenu => m_Wrapper.m_WorldInteraction_OptionsMenu;
            public InputAction @Interact => m_Wrapper.m_WorldInteraction_Interact;
            public InputAction @Melee => m_Wrapper.m_WorldInteraction_Melee;
            public InputActionMap Get() { return m_Wrapper.m_WorldInteraction; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(WorldInteractionActions set) { return set.Get(); }
            public void SetCallbacks(IWorldInteractionActions instance)
            {
                if (m_Wrapper.m_WorldInteractionActionsCallbackInterface != null)
                {
                    @Movement.started -= m_Wrapper.m_WorldInteractionActionsCallbackInterface.OnMovement;
                    @Movement.performed -= m_Wrapper.m_WorldInteractionActionsCallbackInterface.OnMovement;
                    @Movement.canceled -= m_Wrapper.m_WorldInteractionActionsCallbackInterface.OnMovement;
                    @Augment.started -= m_Wrapper.m_WorldInteractionActionsCallbackInterface.OnAugment;
                    @Augment.performed -= m_Wrapper.m_WorldInteractionActionsCallbackInterface.OnAugment;
                    @Augment.canceled -= m_Wrapper.m_WorldInteractionActionsCallbackInterface.OnAugment;
                    @Jump.started -= m_Wrapper.m_WorldInteractionActionsCallbackInterface.OnJump;
                    @Jump.performed -= m_Wrapper.m_WorldInteractionActionsCallbackInterface.OnJump;
                    @Jump.canceled -= m_Wrapper.m_WorldInteractionActionsCallbackInterface.OnJump;
                    @OptionsMenu.started -= m_Wrapper.m_WorldInteractionActionsCallbackInterface.OnOptionsMenu;
                    @OptionsMenu.performed -= m_Wrapper.m_WorldInteractionActionsCallbackInterface.OnOptionsMenu;
                    @OptionsMenu.canceled -= m_Wrapper.m_WorldInteractionActionsCallbackInterface.OnOptionsMenu;
                    @Interact.started -= m_Wrapper.m_WorldInteractionActionsCallbackInterface.OnInteract;
                    @Interact.performed -= m_Wrapper.m_WorldInteractionActionsCallbackInterface.OnInteract;
                    @Interact.canceled -= m_Wrapper.m_WorldInteractionActionsCallbackInterface.OnInteract;
                    @Melee.started -= m_Wrapper.m_WorldInteractionActionsCallbackInterface.OnMelee;
                    @Melee.performed -= m_Wrapper.m_WorldInteractionActionsCallbackInterface.OnMelee;
                    @Melee.canceled -= m_Wrapper.m_WorldInteractionActionsCallbackInterface.OnMelee;
                }
                m_Wrapper.m_WorldInteractionActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Movement.started += instance.OnMovement;
                    @Movement.performed += instance.OnMovement;
                    @Movement.canceled += instance.OnMovement;
                    @Augment.started += instance.OnAugment;
                    @Augment.performed += instance.OnAugment;
                    @Augment.canceled += instance.OnAugment;
                    @Jump.started += instance.OnJump;
                    @Jump.performed += instance.OnJump;
                    @Jump.canceled += instance.OnJump;
                    @OptionsMenu.started += instance.OnOptionsMenu;
                    @OptionsMenu.performed += instance.OnOptionsMenu;
                    @OptionsMenu.canceled += instance.OnOptionsMenu;
                    @Interact.started += instance.OnInteract;
                    @Interact.performed += instance.OnInteract;
                    @Interact.canceled += instance.OnInteract;
                    @Melee.started += instance.OnMelee;
                    @Melee.performed += instance.OnMelee;
                    @Melee.canceled += instance.OnMelee;
                }
            }
        }
        public WorldInteractionActions @WorldInteraction => new WorldInteractionActions(this);

        // UI
        private readonly InputActionMap m_UI;
        private IUIActions m_UIActionsCallbackInterface;
        private readonly InputAction m_UI_ConfirmSelection;
        public struct UIActions
        {
            private @PlayerControllerActionMap m_Wrapper;
            public UIActions(@PlayerControllerActionMap wrapper) { m_Wrapper = wrapper; }
            public InputAction @ConfirmSelection => m_Wrapper.m_UI_ConfirmSelection;
            public InputActionMap Get() { return m_Wrapper.m_UI; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(UIActions set) { return set.Get(); }
            public void SetCallbacks(IUIActions instance)
            {
                if (m_Wrapper.m_UIActionsCallbackInterface != null)
                {
                    @ConfirmSelection.started -= m_Wrapper.m_UIActionsCallbackInterface.OnConfirmSelection;
                    @ConfirmSelection.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnConfirmSelection;
                    @ConfirmSelection.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnConfirmSelection;
                }
                m_Wrapper.m_UIActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @ConfirmSelection.started += instance.OnConfirmSelection;
                    @ConfirmSelection.performed += instance.OnConfirmSelection;
                    @ConfirmSelection.canceled += instance.OnConfirmSelection;
                }
            }
        }
        public UIActions @UI => new UIActions(this);
        public interface IWorldInteractionActions
        {
            void OnMovement(InputAction.CallbackContext context);
            void OnAugment(InputAction.CallbackContext context);
            void OnJump(InputAction.CallbackContext context);
            void OnOptionsMenu(InputAction.CallbackContext context);
            void OnInteract(InputAction.CallbackContext context);
            void OnMelee(InputAction.CallbackContext context);
        }
        public interface IUIActions
        {
            void OnConfirmSelection(InputAction.CallbackContext context);
        }
    }
}
