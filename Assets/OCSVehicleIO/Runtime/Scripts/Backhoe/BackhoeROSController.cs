using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Unity.Robotics.ROSTCPConnector;
using RosMessageTypes.Sensor;

namespace OCS.VehicleIO
{
    public class BackhoeROSController : BackhoeController
    {
        [SerializeField]
        private string _leftCrawlerJoystick_topicName = "backhoe/leftCrawlerJoyStick";
        [SerializeField]
        private string _rightCrawlerJoystick_topicName = "backhoe/rightCrawlerJoyStick";
        [SerializeField]
        private string _jointJoystick_left_topicName = "backhoe/jointJoyStick_left";
        [SerializeField]
        private string _jointJoystick_right_topicName = "backhoe/jointJoystick_right";

        private ROSConnection _ros;

        private void Awake()
        {
            _ros = ROSConnection.GetOrCreateInstance();
        }

        private void Start()
        {
            _ros.Subscribe<JoyMsg>(_leftCrawlerJoystick_topicName, LeftCrawlerJoyCallback);
            _ros.Subscribe<JoyMsg>(_rightCrawlerJoystick_topicName, RightCrawlerJoyCallback);
            _ros.Subscribe<JoyMsg>(_jointJoystick_left_topicName, JointJoyLeftCallback);
            _ros.Subscribe<JoyMsg>(_jointJoystick_right_topicName, JointJoyRightCallback);
        }

        private void LeftCrawlerJoyCallback(JoyMsg msg)
        {
            _leftCrawlerJoystick.y = msg.axes[0] * 0.01f;
        }

        private void RightCrawlerJoyCallback(JoyMsg msg)
        {
            _rightCrawlerJoystick.y = msg.axes[0] * 0.01f;
        }

        private void JointJoyLeftCallback(JoyMsg msg)
        {
            _jointJoystick_left.x = msg.axes[0] * 0.01f;
            _jointJoystick_left.y = msg.axes[1] * 0.01f;
        }

        private void JointJoyRightCallback(JoyMsg msg)
        {
            _jointJoystick_right.x = msg.axes[0] * 0.01f;
            _jointJoystick_right.y = msg.axes[1] * 0.01f;
        }
    }
}
