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
    private float _angleVelocity_min = 0.0f;
    [SerializeField]
    private float _angleVelocity_max = 180.0f;

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
        base.Start();
    }
    public override void Update()
    {
        _controlTarget.rotation *= Quaternion.AngleAxis(_lagSystem.value*Time.deltaTime, _axis);
        base.Update();
    }
}
