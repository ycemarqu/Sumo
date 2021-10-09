// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/PlayerActionController.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerActionController : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerActionController()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerActionController"",
    ""maps"": [
        {
            ""name"": ""PhoneControl"",
            ""id"": ""a150ef4a-65cd-4469-8920-75351374f28c"",
            ""actions"": [
                {
                    ""name"": ""TouchControl"",
                    ""type"": ""PassThrough"",
                    ""id"": ""fb479c84-013a-4816-b3cb-39f3dc1873fb"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""ac5cf005-e2da-438a-96e9-d5dd5c4f2769"",
                    ""path"": ""<Touchscreen>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TouchControl"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""ComputerControl"",
            ""id"": ""114eaedc-9bd5-44ef-b60c-0fe766525da6"",
            ""actions"": [
                {
                    ""name"": ""MouseControl"",
                    ""type"": ""PassThrough"",
                    ""id"": ""ce5a8ee0-e2e5-423d-8e8d-cea5903976cb"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""1885d712-8242-434a-846d-82151b7dcade"",
                    ""path"": ""<Touchscreen>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MouseControl"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // PhoneControl
        m_PhoneControl = asset.FindActionMap("PhoneControl", throwIfNotFound: true);
        m_PhoneControl_TouchControl = m_PhoneControl.FindAction("TouchControl", throwIfNotFound: true);
        // ComputerControl
        m_ComputerControl = asset.FindActionMap("ComputerControl", throwIfNotFound: true);
        m_ComputerControl_MouseControl = m_ComputerControl.FindAction("MouseControl", throwIfNotFound: true);
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

    // PhoneControl
    private readonly InputActionMap m_PhoneControl;
    private IPhoneControlActions m_PhoneControlActionsCallbackInterface;
    private readonly InputAction m_PhoneControl_TouchControl;
    public struct PhoneControlActions
    {
        private @PlayerActionController m_Wrapper;
        public PhoneControlActions(@PlayerActionController wrapper) { m_Wrapper = wrapper; }
        public InputAction @TouchControl => m_Wrapper.m_PhoneControl_TouchControl;
        public InputActionMap Get() { return m_Wrapper.m_PhoneControl; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PhoneControlActions set) { return set.Get(); }
        public void SetCallbacks(IPhoneControlActions instance)
        {
            if (m_Wrapper.m_PhoneControlActionsCallbackInterface != null)
            {
                @TouchControl.started -= m_Wrapper.m_PhoneControlActionsCallbackInterface.OnTouchControl;
                @TouchControl.performed -= m_Wrapper.m_PhoneControlActionsCallbackInterface.OnTouchControl;
                @TouchControl.canceled -= m_Wrapper.m_PhoneControlActionsCallbackInterface.OnTouchControl;
            }
            m_Wrapper.m_PhoneControlActionsCallbackInterface = instance;
            if (instance != null)
            {
                @TouchControl.started += instance.OnTouchControl;
                @TouchControl.performed += instance.OnTouchControl;
                @TouchControl.canceled += instance.OnTouchControl;
            }
        }
    }
    public PhoneControlActions @PhoneControl => new PhoneControlActions(this);

    // ComputerControl
    private readonly InputActionMap m_ComputerControl;
    private IComputerControlActions m_ComputerControlActionsCallbackInterface;
    private readonly InputAction m_ComputerControl_MouseControl;
    public struct ComputerControlActions
    {
        private @PlayerActionController m_Wrapper;
        public ComputerControlActions(@PlayerActionController wrapper) { m_Wrapper = wrapper; }
        public InputAction @MouseControl => m_Wrapper.m_ComputerControl_MouseControl;
        public InputActionMap Get() { return m_Wrapper.m_ComputerControl; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ComputerControlActions set) { return set.Get(); }
        public void SetCallbacks(IComputerControlActions instance)
        {
            if (m_Wrapper.m_ComputerControlActionsCallbackInterface != null)
            {
                @MouseControl.started -= m_Wrapper.m_ComputerControlActionsCallbackInterface.OnMouseControl;
                @MouseControl.performed -= m_Wrapper.m_ComputerControlActionsCallbackInterface.OnMouseControl;
                @MouseControl.canceled -= m_Wrapper.m_ComputerControlActionsCallbackInterface.OnMouseControl;
            }
            m_Wrapper.m_ComputerControlActionsCallbackInterface = instance;
            if (instance != null)
            {
                @MouseControl.started += instance.OnMouseControl;
                @MouseControl.performed += instance.OnMouseControl;
                @MouseControl.canceled += instance.OnMouseControl;
            }
        }
    }
    public ComputerControlActions @ComputerControl => new ComputerControlActions(this);
    public interface IPhoneControlActions
    {
        void OnTouchControl(InputAction.CallbackContext context);
    }
    public interface IComputerControlActions
    {
        void OnMouseControl(InputAction.CallbackContext context);
    }
}
