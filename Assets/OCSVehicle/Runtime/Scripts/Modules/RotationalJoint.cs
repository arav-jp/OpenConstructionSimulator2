using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OCS.Utility;

namespace OCS.Vehicle
{
    [RequireComponent(typeof(ArticulationBody))]
    public class RotationalJoint : MonoBehaviour
    {
        [SerializeField, ReadOnly]
        private float _speed;

        private ArticulationBody _joint;
        private float _target_position;

        private void Awake()
        {
            _joint = GetComponent<ArticulationBody>();
        }

        private void Update()
        {
            if (_speed != 0) _target_position = _joint.xDrive.target + _speed * Time.deltaTime;
            var xDrive = _joint.xDrive;
            xDrive.target = _target_position;
            xDrive.targetVelocity = _speed;
            _joint.xDrive = xDrive;
        }

        public void Drive(float speed)
        {
            _speed = speed;
        }
    }
}