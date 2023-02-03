using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityBasedRotaryJoint : RotaryJoint
{
    [Header("Parameters (will override LagSystem params)")]
    [SerializeField]
    private bool _override = false;
    [SerializeField]
    private float _T = 1.0f;
    [SerializeField]
    private float _angle_init = 0.0f;
    [SerializeField]
    private float _angle_min = 0.0f;
    [SerializeField]
    private float _angle_max = 180.0f;
    [SerializeField]
    private float _angleVelocity_min = -1.0f;
    [SerializeField]
    private float _angleVelocity_max = 1.0f;

    [SerializeField]
    private float _angle;

    public override void Start()
    {
        if (_override)
        {
            _lagSystem.T = _T;
            _lagSystem.value_min = _angleVelocity_min;
            _lagSystem.value_max = _angleVelocity_max;
        }
        else
        {
            _T = _lagSystem.T;
            _angleVelocity_min = _lagSystem.value_min;
            _angleVelocity_max = _lagSystem.value_max;
        }
        _angle = _angle_init;
        base.Start();
    }
    public override void Update()
    {
        float d_angle = _lagSystem.value*Time.deltaTime;
        _controlTarget.rotation *= Quaternion.AngleAxis(d_angle, _axis);
        _angle += d_angle;

        if (_angle > _angle_max)
        {
            _controlTarget.rotation *= Quaternion.AngleAxis(- _angle + _angle_max, _axis);
            _angle = _angle_max;
        }
        else if (_angle < _angle_min) 
        {
            _controlTarget.rotation *= Quaternion.AngleAxis(- _angle + _angle_min, _axis);
            _angle = _angle_min;
        }

        base.Update();
    }
}
