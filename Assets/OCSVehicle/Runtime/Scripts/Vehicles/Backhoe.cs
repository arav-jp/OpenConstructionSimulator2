using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OCS.Vehicle
{
    public class Backhoe : Vehicle
    {
        [SerializeField]
        private WheelModule _leftCrawler;
        [SerializeField]
        private WheelModule _rightCrawler;
        [SerializeField]
        private RotationalJointModule _bodyJoint;
        [SerializeField]
        private RotationalJointModule _boomJoint;
        [SerializeField]
        private RotationalJointModule _armJoint;
        [SerializeField]
        private RotationalJointModule _bucketJoint;

        public WheelModule leftCrawler { get => _leftCrawler; }
        public WheelModule rightCrawler { get => _rightCrawler; }
        public RotationalJointModule bodyJoint { get => _bodyJoint; }
        public RotationalJointModule boomJoint { get => _boomJoint; }
        public RotationalJointModule armJoint { get => _armJoint; }
        public RotationalJointModule bucketJoint { get => _bucketJoint; }

    }
}
