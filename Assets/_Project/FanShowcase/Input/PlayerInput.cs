//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/_Project/FanShowcase/Input/PlayerInput.inputactions
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

namespace FanShowcase.Input
{
    public partial class @PlayerInput: IInputActionCollection2, IDisposable
    {
        public InputActionAsset asset { get; }
        public @PlayerInput()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInput"",
    ""maps"": [
        {
            ""name"": ""Default"",
            ""id"": ""6bcfcca1-7113-4323-8c40-dfd030476b64"",
            ""actions"": [
                {
                    ""name"": ""Zoom"",
                    ""type"": ""PassThrough"",
                    ""id"": ""4ef2b4cf-a174-4d3c-9bfb-b740d1afa699"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Look"",
                    ""type"": ""Button"",
                    ""id"": ""f4af9747-530a-4c70-be17-c0d39aaf6d0e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""PointerDelta"",
                    ""type"": ""PassThrough"",
                    ""id"": ""2abbab04-e165-4713-a4d7-bcba0f278afa"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""e29daabf-fb6b-4a8e-9116-67aba59a10d6"",
                    ""path"": ""<Mouse>/scroll"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Zoom"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a409b1a3-8e70-48bb-834c-8405b0931aa8"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": ""Press(behavior=1)"",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4747ec82-5dac-42c7-93fa-6592482e9e17"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""PointerDelta"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard"",
            ""bindingGroup"": ""Keyboard"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
            // Default
            m_Default = asset.FindActionMap("Default", throwIfNotFound: true);
            m_Default_Zoom = m_Default.FindAction("Zoom", throwIfNotFound: true);
            m_Default_Look = m_Default.FindAction("Look", throwIfNotFound: true);
            m_Default_PointerDelta = m_Default.FindAction("PointerDelta", throwIfNotFound: true);
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

        // Default
        private readonly InputActionMap m_Default;
        private List<IDefaultActions> m_DefaultActionsCallbackInterfaces = new List<IDefaultActions>();
        private readonly InputAction m_Default_Zoom;
        private readonly InputAction m_Default_Look;
        private readonly InputAction m_Default_PointerDelta;
        public struct DefaultActions
        {
            private @PlayerInput m_Wrapper;
            public DefaultActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
            public InputAction @Zoom => m_Wrapper.m_Default_Zoom;
            public InputAction @Look => m_Wrapper.m_Default_Look;
            public InputAction @PointerDelta => m_Wrapper.m_Default_PointerDelta;
            public InputActionMap Get() { return m_Wrapper.m_Default; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(DefaultActions set) { return set.Get(); }
            public void AddCallbacks(IDefaultActions instance)
            {
                if (instance == null || m_Wrapper.m_DefaultActionsCallbackInterfaces.Contains(instance)) return;
                m_Wrapper.m_DefaultActionsCallbackInterfaces.Add(instance);
                @Zoom.started += instance.OnZoom;
                @Zoom.performed += instance.OnZoom;
                @Zoom.canceled += instance.OnZoom;
                @Look.started += instance.OnLook;
                @Look.performed += instance.OnLook;
                @Look.canceled += instance.OnLook;
                @PointerDelta.started += instance.OnPointerDelta;
                @PointerDelta.performed += instance.OnPointerDelta;
                @PointerDelta.canceled += instance.OnPointerDelta;
            }

            private void UnregisterCallbacks(IDefaultActions instance)
            {
                @Zoom.started -= instance.OnZoom;
                @Zoom.performed -= instance.OnZoom;
                @Zoom.canceled -= instance.OnZoom;
                @Look.started -= instance.OnLook;
                @Look.performed -= instance.OnLook;
                @Look.canceled -= instance.OnLook;
                @PointerDelta.started -= instance.OnPointerDelta;
                @PointerDelta.performed -= instance.OnPointerDelta;
                @PointerDelta.canceled -= instance.OnPointerDelta;
            }

            public void RemoveCallbacks(IDefaultActions instance)
            {
                if (m_Wrapper.m_DefaultActionsCallbackInterfaces.Remove(instance))
                    UnregisterCallbacks(instance);
            }

            public void SetCallbacks(IDefaultActions instance)
            {
                foreach (var item in m_Wrapper.m_DefaultActionsCallbackInterfaces)
                    UnregisterCallbacks(item);
                m_Wrapper.m_DefaultActionsCallbackInterfaces.Clear();
                AddCallbacks(instance);
            }
        }
        public DefaultActions @Default => new DefaultActions(this);
        private int m_KeyboardSchemeIndex = -1;
        public InputControlScheme KeyboardScheme
        {
            get
            {
                if (m_KeyboardSchemeIndex == -1) m_KeyboardSchemeIndex = asset.FindControlSchemeIndex("Keyboard");
                return asset.controlSchemes[m_KeyboardSchemeIndex];
            }
        }
        public interface IDefaultActions
        {
            void OnZoom(InputAction.CallbackContext context);
            void OnLook(InputAction.CallbackContext context);
            void OnPointerDelta(InputAction.CallbackContext context);
        }
    }
}
