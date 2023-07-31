using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OCS.Vehicle
{
    public class WheelModule : MonoBehaviour
    {
        [SerializeField]
        private Wheel[] _wheels;

        public void Drive(float input)
        {
            foreach(Wheel wheel in _wheels)
            {
                wheel.Drive(input);
            }
        }
    }
}
