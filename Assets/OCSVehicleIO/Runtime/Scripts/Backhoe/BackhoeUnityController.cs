using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

using OCS.Utility;

namespace OCS.VehicleIO
{
    public class BackhoeUnityController : BackhoeController
    {
        private OCSInput _input;

        private bool _leftCrawlerJoystickReverse;
        private bool _rightCrawlerJoystickReverse;

        private void Awake()
        {
            _input = new OCSInput();
        }

        private void Start()
        {
            _input.Backhoe.LeftCrawlerJoystickReverse.started += LeftCrawlerJoystickReverse;
            _input.Backhoe.RightCrawlerJoystickReverse.started += RightCrawlerJoystickReverse;
            _input.Backhoe.BoomLightSwitchButton.started += SwitchBoomLight;
            _input.Enable();
        }

        protected override void Update()
        {
            _leftCrawlerJoystick.y = (_leftCrawlerJoystickReverse ? -1.0f : 1.0f) * _input.Backhoe.LeftCrawlerJoystickMagnitude.ReadValue<float>();
            _rightCrawlerJoystick.y = (_rightCrawlerJoystickReverse ? -1.0f : 1.0f) * _input.Backhoe.RightCrawlerJoystickMagnitude.ReadValue<float>();
            _jointJoystick_left.vector = _input.Backhoe.JointJoystickLeft.ReadValue<Vector2>();
            _jointJoystick_right.vector = _input.Backhoe.JointJoystickRight.ReadValue<Vector2>();
            base.Update();
        }

        private void LeftCrawlerJoystickReverse(InputAction.CallbackContext context)
        {
            _leftCrawlerJoystickReverse = !_leftCrawlerJoystickReverse;
        }

        private void RightCrawlerJoystickReverse(InputAction.CallbackContext context)
        {
            _rightCrawlerJoystickReverse = !_rightCrawlerJoystickReverse;
        }

        private void SwitchBoomLight(InputAction.CallbackContext context)
        {
            base.SwitchBoomLight();
        }
    }
}