using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using OCS.Utility;
using OCS.Vehicle;

namespace OCS.VehicleIO
{
    public class BackhoeController : VehicleController
    {
        private BackhoeInput _input;

        [SerializeField, ReadOnly]
        private float _leftCrawlerThrottle;
        [SerializeField, ReadOnly]
        private bool _leftCrawlerReverse;
        [SerializeField, ReadOnly]
        private float _rightCrawlerThrottle;
        [SerializeField, ReadOnly]
        private bool _rightCrawlerReverse;

        private void Awake()
        {
            _input = new BackhoeInput();
        }

        private void Start()
        {
            _input.Backhoe.LeftCrawlerThrottle.performed += LeftCrawlerThrottle;
            _input.Backhoe.LeftCrawlerReverse.started += LeftCrawlerReverse;
            _input.Backhoe.RightCrawlerThrottle.performed += RightCrawlerThrottle;
            _input.Backhoe.RightCrawlerReverse.started += RightCrawlerReverse;
            _input.Backhoe.Body.performed += Body;
            _input.Backhoe.Boom.performed += Boom;
            _input.Backhoe.Arm.performed += Arm;
            _input.Backhoe.Bucket.performed += Bucket;
            _input.Enable();
        }

        private void Update()
        {
            float throttle_l = _leftCrawlerThrottle * (_leftCrawlerReverse ? -1.0f : 1.0f);
            float throttle_r = _rightCrawlerThrottle * (_rightCrawlerReverse ? -1.0f : 1.0f);
            _controlTarget.GetModule<WheelModule>("LeftCrawler").Drive(throttle_l);
            _controlTarget.GetModule<WheelModule>("RightCrawler").Drive(throttle_r);
        }

        private void LeftCrawlerThrottle(InputAction.CallbackContext context)
        {
            _leftCrawlerThrottle = context.ReadValue<float>();
        }

        private void LeftCrawlerReverse(InputAction.CallbackContext context)
        {
            _leftCrawlerReverse = !_leftCrawlerReverse;
        }

        private void RightCrawlerThrottle(InputAction.CallbackContext context)
        {
            _rightCrawlerThrottle = context.ReadValue<float>();
        }

        private void RightCrawlerReverse(InputAction.CallbackContext context)
        {
            _rightCrawlerReverse = !_rightCrawlerReverse;
        }

        private void Body(InputAction.CallbackContext context)
        {
            _controlTarget.GetModule<RotationalJointModule>("Body").Drive(context.ReadValue<float>() * 30.0f);
        }

        private void Boom(InputAction.CallbackContext context)
        {
            _controlTarget.GetModule<RotationalJointModule>("Boom").Drive(context.ReadValue<float>() * 30.0f);
        }

        private void Arm(InputAction.CallbackContext context)
        {
            _controlTarget.GetModule<RotationalJointModule>("Arm").Drive(context.ReadValue<float>() * 30.0f);
        }

        private void Bucket(InputAction.CallbackContext context)
        {
            _controlTarget.GetModule<RotationalJointModule>("Bucket").Drive(context.ReadValue<float>() * -30.0f);
        }
    }
}
