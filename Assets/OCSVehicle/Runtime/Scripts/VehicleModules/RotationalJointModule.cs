using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OCS.Vehicle
{
    public class RotationalJointModule : MonoBehaviour
    {
        [SerializeField]
        private RotationalJoint _joint;

        public void Drive(float input)
        {
            _joint.Drive(input);
        }
    }
}
