using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OCS.Utility;

namespace OCS.Vehicle
{
    [RequireComponent(typeof(ArticulationBody))]
    public class Wheel : MonoBehaviour
    {
        [SerializeField, ReadOnly]
        private float _speed;

        private ArticulationBody _wheel;
        private float _target_position;


        private void Awake()
        {
            _wheel = GetComponent<ArticulationBody>();
        }

        private void Update()
        {
            if (_speed != 0) _target_position = _wheel.xDrive.target + _speed * Time.deltaTime;
            var xDrive = _wheel.xDrive;
            xDrive.target = _target_position;
            xDrive.targetVelocity = _speed;
            _wheel.xDrive = xDrive;
        }

        public void Drive(float speed)
        {
            _speed = speed;
        }
    }
}
