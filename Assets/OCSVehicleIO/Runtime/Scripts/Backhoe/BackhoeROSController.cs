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
        private string _testTopicName = "joy/leftCrawler";

        private ROSConnection _ros;

        private void Awake()
        {
            // ROS�I�u�W�F�N�g�̐����E�擾
            _ros = ROSConnection.GetOrCreateInstance();
        }

        private void Start()
        {
            // Subscriber�ݒ�
            // Subscribe<���b�Z�[�W�^>(�g�s�b�N��, �R�[���o�b�N�֐�)�Ŏw��
            _ros.Subscribe<JoyMsg>(_testTopicName, JoyCallback);
        }

        private void JoyCallback(JoyMsg msg)
        {
            _leftCrawlerJoystick.y = msg.axes[0] * 0.01f;
        }
    }
}
