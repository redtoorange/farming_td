// GENERATED AUTOMATICALLY FROM 'Assets/Resources/Input/PlayerActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace Input
{
    public class @PlayerActions : IInputActionCollection, IDisposable
    {
        public InputActionAsset asset { get; }
        public @PlayerActions()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerActions"",
    ""maps"": [
        {
            ""name"": ""PlayerControls"",
            ""id"": ""f48e329d-4afa-4063-9c8d-5a70106efd04"",
            ""actions"": [
                {
                    ""name"": ""CameraMove"",
                    ""type"": ""Value"",
                    ""id"": ""499556bf-9b12-4e58-8510-00a39856a1f2"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""CameraZoom"",
                    ""type"": ""Value"",
                    ""id"": ""cf50310f-a082-4057-8998-b0ec3b9698ac"",
                    ""expectedControlType"": ""Digital"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""CameraSprint"",
                    ""type"": ""Button"",
                    ""id"": ""2cd8fa9c-7633-41eb-add7-63f169d8bd43"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""f5207c4b-44f1-448f-9bd3-bc5ddf5fa5b7"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CameraMove"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""6048e582-d622-41ef-8322-f186fb29a5b7"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard/Mouse"",
                    ""action"": ""CameraMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""6b54cd46-6671-410b-956a-f0cc000bfbf2"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard/Mouse"",
                    ""action"": ""CameraMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""fc3405a1-3603-4a35-8ef4-59a71ddc348a"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard/Mouse"",
                    ""action"": ""CameraMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""910753f2-9837-4dd5-9350-97dff9a63fa9"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard/Mouse"",
                    ""action"": ""CameraMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""ca749161-287e-4da4-bbe4-cbfd5bc20d96"",
                    ""path"": ""<Mouse>/scroll/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CameraZoom"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7bdde5a7-c974-4a03-8fa2-5255028ad021"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CameraSprint"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard/Mouse"",
            ""bindingGroup"": ""Keyboard/Mouse"",
            ""devices"": []
        }
    ]
}");
            // PlayerControls
            m_PlayerControls = asset.FindActionMap("PlayerControls", throwIfNotFound: true);
            m_PlayerControls_CameraMove = m_PlayerControls.FindAction("CameraMove", throwIfNotFound: true);
            m_PlayerControls_CameraZoom = m_PlayerControls.FindAction("CameraZoom", throwIfNotFound: true);
            m_PlayerControls_CameraSprint = m_PlayerControls.FindAction("CameraSprint", throwIfNotFound: true);
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

        // PlayerControls
        private readonly InputActionMap m_PlayerControls;
        private IPlayerControlsActions m_PlayerControlsActionsCallbackInterface;
        private readonly InputAction m_PlayerControls_CameraMove;
        private readonly InputAction m_PlayerControls_CameraZoom;
        private readonly InputAction m_PlayerControls_CameraSprint;
        public struct PlayerControlsActions
        {
            private @PlayerActions m_Wrapper;
            public PlayerControlsActions(@PlayerActions wrapper) { m_Wrapper = wrapper; }
            public InputAction @CameraMove => m_Wrapper.m_PlayerControls_CameraMove;
            public InputAction @CameraZoom => m_Wrapper.m_PlayerControls_CameraZoom;
            public InputAction @CameraSprint => m_Wrapper.m_PlayerControls_CameraSprint;
            public InputActionMap Get() { return m_Wrapper.m_PlayerControls; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(PlayerControlsActions set) { return set.Get(); }
            public void SetCallbacks(IPlayerControlsActions instance)
            {
                if (m_Wrapper.m_PlayerControlsActionsCallbackInterface != null)
                {
                    @CameraMove.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnCameraMove;
                    @CameraMove.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnCameraMove;
                    @CameraMove.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnCameraMove;
                    @CameraZoom.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnCameraZoom;
                    @CameraZoom.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnCameraZoom;
                    @CameraZoom.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnCameraZoom;
                    @CameraSprint.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnCameraSprint;
                    @CameraSprint.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnCameraSprint;
                    @CameraSprint.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnCameraSprint;
                }
                m_Wrapper.m_PlayerControlsActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @CameraMove.started += instance.OnCameraMove;
                    @CameraMove.performed += instance.OnCameraMove;
                    @CameraMove.canceled += instance.OnCameraMove;
                    @CameraZoom.started += instance.OnCameraZoom;
                    @CameraZoom.performed += instance.OnCameraZoom;
                    @CameraZoom.canceled += instance.OnCameraZoom;
                    @CameraSprint.started += instance.OnCameraSprint;
                    @CameraSprint.performed += instance.OnCameraSprint;
                    @CameraSprint.canceled += instance.OnCameraSprint;
                }
            }
        }
        public PlayerControlsActions @PlayerControls => new PlayerControlsActions(this);
        private int m_KeyboardMouseSchemeIndex = -1;
        public InputControlScheme KeyboardMouseScheme
        {
            get
            {
                if (m_KeyboardMouseSchemeIndex == -1) m_KeyboardMouseSchemeIndex = asset.FindControlSchemeIndex("Keyboard/Mouse");
                return asset.controlSchemes[m_KeyboardMouseSchemeIndex];
            }
        }
        public interface IPlayerControlsActions
        {
            void OnCameraMove(InputAction.CallbackContext context);
            void OnCameraZoom(InputAction.CallbackContext context);
            void OnCameraSprint(InputAction.CallbackContext context);
        }
    }
}
