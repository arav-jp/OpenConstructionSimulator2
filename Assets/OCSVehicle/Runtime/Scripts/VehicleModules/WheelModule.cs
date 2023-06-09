using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OCS.Vehicle
{
    public class WheelModule : VehicleModule
    {
        [SerializeField]
        private Wheel[] _wheels;

        [SerializeField]
        private float _magnification = 1.0f;
        public override Type moduleType { get => typeof(WheelModule); }

        public void Drive(float input)
        {
            input *= _magnification;
            foreach(Wheel wheel in _wheels)
            {
                wheel.Drive(input);
            }
        }
    }
}
