//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.3.0
//     from Assets/OCSVehicleIO/Runtime/InputActions/Backhoe/OCSInput.inputactions
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

public partial class @OCSInput : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @OCSInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""OCSInput"",
    ""maps"": [
        {
            ""name"": ""Backhoe"",
            ""id"": ""86d20947-02da-471f-9e8d-276796a5d47d"",
            ""actions"": [
                {
                    ""name"": ""LeftCrawlerJoystickMagnitude"",
                    ""type"": ""PassThrough"",
                    ""id"": ""c1bb502a-700a-40cb-aae6-b8f7708208a3"",
                    ""expectedControlType"": ""Analog"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""LeftCrawlerJoystickReverse"",
                    ""type"": ""Button"",
                    ""id"": ""5a1a6149-ab8b-4394-924c-778ac4d1ca74"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""RightCrawlerJoystickMagnitude"",
                    ""type"": ""PassThrough"",
                    ""id"": ""013081dc-c6f4-4758-a99d-139eb6e4a06e"",
                    ""expectedControlType"": ""Analog"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""RightCrawlerJoystickReverse"",
                    ""type"": ""Button"",
                    ""id"": ""3453f6fe-f532-4b44-bbf8-036e99b45ba0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""JointJoystickLeft"",
                    ""type"": ""PassThrough"",
                    ""id"": ""72d1edeb-6d69-4971-a669-ef19c3d89e63"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": ""NormalizeVector2"",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""JoytJoystickRight"",
                    ""type"": ""PassThrough"",
                    ""id"": ""7ffdec9d-7819-4af0-9caf-d817db4fa980"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": ""NormalizeVector2"",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""9b076fcc-f70b-4bd1-b362-822b75e357f9"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": ""Normalize(max=1)"",
                    ""groups"": """",
                    ""action"": ""LeftCrawlerJoystickMagnitude"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""342df045-23ca-4709-8f3d-68d39915ae41"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftCrawlerJoystickReverse"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a4943a58-e81a-46fb-962e-70caab169667"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": ""Normalize(max=1)"",
                    ""groups"": """",
                    ""action"": ""RightCrawlerJoystickMagnitude"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e6eea573-ceeb-4cae-bd68-bdd4948decbe"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightCrawlerJoystickReverse"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3ce57c22-7509-4e6b-be57-66e4b3dae55c"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""JointJoystickLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b789e4f1-cf9d-4eb0-862f-85fecca668d3"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""JoytJoystickRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Backhoe
        m_Backhoe = asset.FindActionMap("Backhoe", throwIfNotFound: true);
        m_Backhoe_LeftCrawlerJoystickMagnitude = m_Backhoe.FindAction("LeftCrawlerJoystickMagnitude", throwIfNotFound: true);
        m_Backhoe_LeftCrawlerJoystickReverse = m_Backhoe.FindAction("LeftCrawlerJoystickReverse", throwIfNotFound: true);
        m_Backhoe_RightCrawlerJoystickMagnitude = m_Backhoe.FindAction("RightCrawlerJoystickMagnitude", throwIfNotFound: true);
        m_Backhoe_RightCrawlerJoystickReverse = m_Backhoe.FindAction("RightCrawlerJoystickReverse", throwIfNotFound: true);
        m_Backhoe_JointJoystickLeft = m_Backhoe.FindAction("JointJoystickLeft", throwIfNotFound: true);
        m_Backhoe_JoytJoystickRight = m_Backhoe.FindAction("JoytJoystickRight", throwIfNotFound: true);
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

    // Backhoe
    private readonly InputActionMap m_Backhoe;
    private IBackhoeActions m_BackhoeActionsCallbackInterface;
    private readonly InputAction m_Backhoe_LeftCrawlerJoystickMagnitude;
    private readonly InputAction m_Backhoe_LeftCrawlerJoystickReverse;
    private readonly InputAction m_Backhoe_RightCrawlerJoystickMagnitude;
    private readonly InputAction m_Backhoe_RightCrawlerJoystickReverse;
    private readonly InputAction m_Backhoe_JointJoystickLeft;
    private readonly InputAction m_Backhoe_JoytJoystickRight;
    public struct BackhoeActions
    {
        private @OCSInput m_Wrapper;
        public BackhoeActions(@OCSInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @LeftCrawlerJoystickMagnitude => m_Wrapper.m_Backhoe_LeftCrawlerJoystickMagnitude;
        public InputAction @LeftCrawlerJoystickReverse => m_Wrapper.m_Backhoe_LeftCrawlerJoystickReverse;
        public InputAction @RightCrawlerJoystickMagnitude => m_Wrapper.m_Backhoe_RightCrawlerJoystickMagnitude;
        public InputAction @RightCrawlerJoystickReverse => m_Wrapper.m_Backhoe_RightCrawlerJoystickReverse;
        public InputAction @JointJoystickLeft => m_Wrapper.m_Backhoe_JointJoystickLeft;
        public InputAction @JoytJoystickRight => m_Wrapper.m_Backhoe_JoytJoystickRight;
        public InputActionMap Get() { return m_Wrapper.m_Backhoe; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(BackhoeActions set) { return set.Get(); }
        public void SetCallbacks(IBackhoeActions instance)
        {
            if (m_Wrapper.m_BackhoeActionsCallbackInterface != null)
            {
                @LeftCrawlerJoystickMagnitude.started -= m_Wrapper.m_BackhoeActionsCallbackInterface.OnLeftCrawlerJoystickMagnitude;
                @LeftCrawlerJoystickMagnitude.performed -= m_Wrapper.m_BackhoeActionsCallbackInterface.OnLeftCrawlerJoystickMagnitude;
                @LeftCrawlerJoystickMagnitude.canceled -= m_Wrapper.m_BackhoeActionsCallbackInterface.OnLeftCrawlerJoystickMagnitude;
                @LeftCrawlerJoystickReverse.started -= m_Wrapper.m_BackhoeActionsCallbackInterface.OnLeftCrawlerJoystickReverse;
                @LeftCrawlerJoystickReverse.performed -= m_Wrapper.m_BackhoeActionsCallbackInterface.OnLeftCrawlerJoystickReverse;
                @LeftCrawlerJoystickReverse.canceled -= m_Wrapper.m_BackhoeActionsCallbackInterface.OnLeftCrawlerJoystickReverse;
                @RightCrawlerJoystickMagnitude.started -= m_Wrapper.m_BackhoeActionsCallbackInterface.OnRightCrawlerJoystickMagnitude;
                @RightCrawlerJoystickMagnitude.performed -= m_Wrapper.m_BackhoeActionsCallbackInterface.OnRightCrawlerJoystickMagnitude;
                @RightCrawlerJoystickMagnitude.canceled -= m_Wrapper.m_BackhoeActionsCallbackInterface.OnRightCrawlerJoystickMagnitude;
                @RightCrawlerJoystickReverse.started -= m_Wrapper.m_BackhoeActionsCallbackInterface.OnRightCrawlerJoystickReverse;
                @RightCrawlerJoystickReverse.performed -= m_Wrapper.m_BackhoeActionsCallbackInterface.OnRightCrawlerJoystickReverse;
                @RightCrawlerJoystickReverse.canceled -= m_Wrapper.m_BackhoeActionsCallbackInterface.OnRightCrawlerJoystickReverse;
                @JointJoystickLeft.started -= m_Wrapper.m_BackhoeActionsCallbackInterface.OnJointJoystickLeft;
                @JointJoystickLeft.performed -= m_Wrapper.m_BackhoeActionsCallbackInterface.OnJointJoystickLeft;
                @JointJoystickLeft.canceled -= m_Wrapper.m_BackhoeActionsCallbackInterface.OnJointJoystickLeft;
                @JoytJoystickRight.started -= m_Wrapper.m_BackhoeActionsCallbackInterface.OnJoytJoystickRight;
                @JoytJoystickRight.performed -= m_Wrapper.m_BackhoeActionsCallbackInterface.OnJoytJoystickRight;
                @JoytJoystickRight.canceled -= m_Wrapper.m_BackhoeActionsCallbackInterface.OnJoytJoystickRight;
            }
            m_Wrapper.m_BackhoeActionsCallbackInterface = instance;
            if (instance != null)
            {
                @LeftCrawlerJoystickMagnitude.started += instance.OnLeftCrawlerJoystickMagnitude;
                @LeftCrawlerJoystickMagnitude.performed += instance.OnLeftCrawlerJoystickMagnitude;
                @LeftCrawlerJoystickMagnitude.canceled += instance.OnLeftCrawlerJoystickMagnitude;
                @LeftCrawlerJoystickReverse.started += instance.OnLeftCrawlerJoystickReverse;
                @LeftCrawlerJoystickReverse.performed += instance.OnLeftCrawlerJoystickReverse;
                @LeftCrawlerJoystickReverse.canceled += instance.OnLeftCrawlerJoystickReverse;
                @RightCrawlerJoystickMagnitude.started += instance.OnRightCrawlerJoystickMagnitude;
                @RightCrawlerJoystickMagnitude.performed += instance.OnRightCrawlerJoystickMagnitude;
                @RightCrawlerJoystickMagnitude.canceled += instance.OnRightCrawlerJoystickMagnitude;
                @RightCrawlerJoystickReverse.started += instance.OnRightCrawlerJoystickReverse;
                @RightCrawlerJoystickReverse.performed += instance.OnRightCrawlerJoystickReverse;
                @RightCrawlerJoystickReverse.canceled += instance.OnRightCrawlerJoystickReverse;
                @JointJoystickLeft.started += instance.OnJointJoystickLeft;
                @JointJoystickLeft.performed += instance.OnJointJoystickLeft;
                @JointJoystickLeft.canceled += instance.OnJointJoystickLeft;
                @JoytJoystickRight.started += instance.OnJoytJoystickRight;
                @JoytJoystickRight.performed += instance.OnJoytJoystickRight;
                @JoytJoystickRight.canceled += instance.OnJoytJoystickRight;
            }
        }
    }
    public BackhoeActions @Backhoe => new BackhoeActions(this);
    public interface IBackhoeActions
    {
        void OnLeftCrawlerJoystickMagnitude(InputAction.CallbackContext context);
        void OnLeftCrawlerJoystickReverse(InputAction.CallbackContext context);
        void OnRightCrawlerJoystickMagnitude(InputAction.CallbackContext context);
        void OnRightCrawlerJoystickReverse(InputAction.CallbackContext context);
        void OnJointJoystickLeft(InputAction.CallbackContext context);
        void OnJoytJoystickRight(InputAction.CallbackContext context);
    }
}