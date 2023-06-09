using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OCS.Vehicle
{
    public class RotationalJointModule : VehicleModule
    {
        [SerializeField]
        private RotationalJoint _joint;

        public override Type moduleType { get => typeof(RotationalJointModule); }

        public void Drive(float input)
        {
            _joint.Drive(input);
        }
    }
}
