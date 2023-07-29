using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OCS.Utility;
using OCS.Vehicle;

namespace OCS.VehicleIO
{
    public class BackhoeController : VehicleController<Backhoe>
    {
        [SerializeField]
        private float _maxLeftCrawlerInput = 1.0f;
        [SerializeField]
        private float _maxRightCrawlerInput = 1.0f;
        [SerializeField]
        private float _maxBodyInput = 1.0f;
        [SerializeField]
        private float _maxBoomInput = 1.0f;
        [SerializeField]
        private float _maxArmInput = 1.0f;
        [SerializeField]
        private float _maxBucketInput = 1.0f;

        protected JoyStickInput _leftCrawlerJoystick;
        protected JoyStickInput _rightCrawlerJoystick;
        protected JoyStickInput _jointJoystick_left;
        protected JoyStickInput _jointJoystick_right;

        protected virtual void Update()
        {
            _controlTarget.leftCrawler.Drive(_leftCrawlerJoystick.y * _maxLeftCrawlerInput);
            _controlTarget.rightCrawler.Drive(_rightCrawlerJoystick.y * _maxRightCrawlerInput);
            _controlTarget.bodyJoint.Drive(_jointJoystick_left.x * _maxBodyInput);
            _controlTarget.boomJoint.Drive(_jointJoystick_right.y * _maxBoomInput);
            _controlTarget.armJoint.Drive(_jointJoystick_left.y * _maxArmInput);
            _controlTarget.bucketJoint.Drive(-_jointJoystick_right.x * _maxBucketInput);
        }
    }
}
