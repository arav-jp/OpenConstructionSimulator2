using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OCS.Utility;

namespace OCS.Vehicle
{
    [RequireComponent(typeof(ArticulationBody))]
    public class RotationalJoint : MonoBehaviour
    {
        [SerializeField]
        private bool _isLimited;
        [SerializeField, ReadOnly]
        private float _speed;

        private ArticulationBody _joint;
        private float _target_position;

        private float _lowerLimit;
        private float _upperLimit;

        private void Awake()
        {
            _joint = GetComponent<ArticulationBody>();

            _lowerLimit = _joint.xDrive.lowerLimit;
            _upperLimit = _joint.xDrive.upperLimit;
        }

        private void Update()
        {
            if (_speed != 0) _target_position = _joint.xDrive.target + _speed * Time.deltaTime;
            if (_isLimited) _target_position = Mathf.Clamp(_target_position, _lowerLimit, _upperLimit);
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