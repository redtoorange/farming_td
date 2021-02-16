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
        },
        {
            ""name"": ""FPS"",
            ""id"": ""38bf268e-a0e9-44d8-b673-ab82e319602d"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""7df968b2-d04b-49ed-989a-7d62cff55a0d"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""e7acab8f-9bbb-44c3-9768-02d3a648e935"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Sprint"",
                    ""type"": ""Button"",
                    ""id"": ""dae57e5e-edad-4c11-9789-58d9973b8e0c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LookX"",
                    ""type"": ""Value"",
                    ""id"": ""7ddd58c6-ecdb-4843-bbd7-5774ebe938f3"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LookY"",
                    ""type"": ""Value"",
                    ""id"": ""b0ccf47d-548d-42ca-b1e7-acc63e6868b4"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""8fec73c2-fd8d-4917-8c22-ae385af937ae"",
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
                    ""id"": ""c1eaaf1f-bc20-42b7-beef-7c7b90e94e8c"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""367eb525-9ead-4e10-ad86-1ff7226ec747"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""d40f097b-7358-446c-9b7a-2f31aa22bf40"",
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
                    ""id"": ""f266cee3-a3de-476a-9fba-631dbedd7602"",
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
                    ""id"": ""16ac3934-9d5b-45c2-bcaf-a84f82fedc34"",
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
                    ""id"": ""9e4f14af-a606-478e-a3fd-0c7378d415f2"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Sprint"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fcbce025-11a0-4be3-802e-aa1a89b6ec60"",
                    ""path"": ""<Mouse>/delta/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LookX"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f7863d74-ccf9-4a1a-b545-9754167dfcb1"",
                    ""path"": ""<Mouse>/delta/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LookY"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""RTS"",
            ""id"": ""22bbb2a6-89a1-4a50-b4f4-82577014a3cc"",
            ""actions"": [
                {
                    ""name"": ""New action"",
                    ""type"": ""Button"",
                    ""id"": ""6a045118-1231-491e-83e7-4da5e6925886"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""7eee40cb-de7f-42c7-9b99-a852fc655294"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""New action"",
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
            // FPS
            m_FPS = asset.FindActionMap("FPS", throwIfNotFound: true);
            m_FPS_Movement = m_FPS.FindAction("Movement", throwIfNotFound: true);
            m_FPS_Jump = m_FPS.FindAction("Jump", throwIfNotFound: true);
            m_FPS_Sprint = m_FPS.FindAction("Sprint", throwIfNotFound: true);
            m_FPS_LookX = m_FPS.FindAction("LookX", throwIfNotFound: true);
            m_FPS_LookY = m_FPS.FindAction("LookY", throwIfNotFound: true);
            // RTS
            m_RTS = asset.FindActionMap("RTS", throwIfNotFound: true);
            m_RTS_Newaction = m_RTS.FindAction("New action", throwIfNotFound: true);
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

        // FPS
        private readonly InputActionMap m_FPS;
        private IFPSActions m_FPSActionsCallbackInterface;
        private readonly InputAction m_FPS_Movement;
        private readonly InputAction m_FPS_Jump;
        private readonly InputAction m_FPS_Sprint;
        private readonly InputAction m_FPS_LookX;
        private readonly InputAction m_FPS_LookY;
        public struct FPSActions
        {
            private @PlayerActions m_Wrapper;
            public FPSActions(@PlayerActions wrapper) { m_Wrapper = wrapper; }
            public InputAction @Movement => m_Wrapper.m_FPS_Movement;
            public InputAction @Jump => m_Wrapper.m_FPS_Jump;
            public InputAction @Sprint => m_Wrapper.m_FPS_Sprint;
            public InputAction @LookX => m_Wrapper.m_FPS_LookX;
            public InputAction @LookY => m_Wrapper.m_FPS_LookY;
            public InputActionMap Get() { return m_Wrapper.m_FPS; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(FPSActions set) { return set.Get(); }
            public void SetCallbacks(IFPSActions instance)
            {
                if (m_Wrapper.m_FPSActionsCallbackInterface != null)
                {
                    @Movement.started -= m_Wrapper.m_FPSActionsCallbackInterface.OnMovement;
                    @Movement.performed -= m_Wrapper.m_FPSActionsCallbackInterface.OnMovement;
                    @Movement.canceled -= m_Wrapper.m_FPSActionsCallbackInterface.OnMovement;
                    @Jump.started -= m_Wrapper.m_FPSActionsCallbackInterface.OnJump;
                    @Jump.performed -= m_Wrapper.m_FPSActionsCallbackInterface.OnJump;
                    @Jump.canceled -= m_Wrapper.m_FPSActionsCallbackInterface.OnJump;
                    @Sprint.started -= m_Wrapper.m_FPSActionsCallbackInterface.OnSprint;
                    @Sprint.performed -= m_Wrapper.m_FPSActionsCallbackInterface.OnSprint;
                    @Sprint.canceled -= m_Wrapper.m_FPSActionsCallbackInterface.OnSprint;
                    @LookX.started -= m_Wrapper.m_FPSActionsCallbackInterface.OnLookX;
                    @LookX.performed -= m_Wrapper.m_FPSActionsCallbackInterface.OnLookX;
                    @LookX.canceled -= m_Wrapper.m_FPSActionsCallbackInterface.OnLookX;
                    @LookY.started -= m_Wrapper.m_FPSActionsCallbackInterface.OnLookY;
                    @LookY.performed -= m_Wrapper.m_FPSActionsCallbackInterface.OnLookY;
                    @LookY.canceled -= m_Wrapper.m_FPSActionsCallbackInterface.OnLookY;
                }
                m_Wrapper.m_FPSActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Movement.started += instance.OnMovement;
                    @Movement.performed += instance.OnMovement;
                    @Movement.canceled += instance.OnMovement;
                    @Jump.started += instance.OnJump;
                    @Jump.performed += instance.OnJump;
                    @Jump.canceled += instance.OnJump;
                    @Sprint.started += instance.OnSprint;
                    @Sprint.performed += instance.OnSprint;
                    @Sprint.canceled += instance.OnSprint;
                    @LookX.started += instance.OnLookX;
                    @LookX.performed += instance.OnLookX;
                    @LookX.canceled += instance.OnLookX;
                    @LookY.started += instance.OnLookY;
                    @LookY.performed += instance.OnLookY;
                    @LookY.canceled += instance.OnLookY;
                }
            }
        }
        public FPSActions @FPS => new FPSActions(this);

        // RTS
        private readonly InputActionMap m_RTS;
        private IRTSActions m_RTSActionsCallbackInterface;
        private readonly InputAction m_RTS_Newaction;
        public struct RTSActions
        {
            private @PlayerActions m_Wrapper;
            public RTSActions(@PlayerActions wrapper) { m_Wrapper = wrapper; }
            public InputAction @Newaction => m_Wrapper.m_RTS_Newaction;
            public InputActionMap Get() { return m_Wrapper.m_RTS; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(RTSActions set) { return set.Get(); }
            public void SetCallbacks(IRTSActions instance)
            {
                if (m_Wrapper.m_RTSActionsCallbackInterface != null)
                {
                    @Newaction.started -= m_Wrapper.m_RTSActionsCallbackInterface.OnNewaction;
                    @Newaction.performed -= m_Wrapper.m_RTSActionsCallbackInterface.OnNewaction;
                    @Newaction.canceled -= m_Wrapper.m_RTSActionsCallbackInterface.OnNewaction;
                }
                m_Wrapper.m_RTSActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Newaction.started += instance.OnNewaction;
                    @Newaction.performed += instance.OnNewaction;
                    @Newaction.canceled += instance.OnNewaction;
                }
            }
        }
        public RTSActions @RTS => new RTSActions(this);
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
        public interface IFPSActions
        {
            void OnMovement(InputAction.CallbackContext context);
            void OnJump(InputAction.CallbackContext context);
            void OnSprint(InputAction.CallbackContext context);
            void OnLookX(InputAction.CallbackContext context);
            void OnLookY(InputAction.CallbackContext context);
        }
        public interface IRTSActions
        {
            void OnNewaction(InputAction.CallbackContext context);
        }
    }
}
