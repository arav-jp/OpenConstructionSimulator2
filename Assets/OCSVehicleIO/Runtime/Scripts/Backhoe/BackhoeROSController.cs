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
            // ROSオブジェクトの生成・取得
            _ros = ROSConnection.GetOrCreateInstance();
        }

        private void Start()
        {
            // Subscriber設定
            // Subscribe<メッセージ型>(トピック名, コールバック関数)で指定
            _ros.Subscribe<JoyMsg>(_testTopicName, JoyCallback);
        }

        private void JoyCallback(JoyMsg msg)
        {
            _leftCrawlerJoystick.y = msg.axes[0] * 0.01f;
        }
    }
}
