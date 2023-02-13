using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityBasedRotaryJoint : RotaryJoint
{
    [SerializeField]
    private float _angle_init = 0.0f;
    [SerializeField]
    private bool _angle_limit = false;
    [SerializeField]
    private float _angle_min = 0.0f;
    [SerializeField]
    private float _angle_max = 180.0f;

    [Header("Parameters (will override LagSystem params)")]
    [SerializeField]
    private bool _override = false;
    [SerializeField]
    private float _angleVelocity_min = -1.0f;
    [SerializeField]
    private float _angleVelocity_max = 1.0f;

    private float _angle;

    public override void Start()
    {
        if (_override)
        {
            transferFunction.output_min = _angleVelocity_min;
            transferFunction.output_max = _angleVelocity_max;
        }
        else
        {
            _angle_min = transferFunction.output_min;
            _angle_max = transferFunction.output_max;
        }
        _angle = _angle_init;
        base.Start();
    }
    public override void Update()
    {
        base.Update();
        if (!Application.isPlaying) return;
        float d_angle = transferFunction.output*Time.deltaTime;
        _controlTarget.rotation *= Quaternion.AngleAxis(d_angle, _axis);
        _angle += d_angle;

        if (_angle > _angle_max && _angle_limit)
        {
            _controlTarget.rotation *= Quaternion.AngleAxis(- _angle + _angle_max, _axis);
            _angle = _angle_max;
        }
        else if (_angle < _angle_min && _angle_limit) 
        {
            _controlTarget.rotation *= Quaternion.AngleAxis(- _angle + _angle_min, _axis);
            _angle = _angle_min;
        }
    }
}
