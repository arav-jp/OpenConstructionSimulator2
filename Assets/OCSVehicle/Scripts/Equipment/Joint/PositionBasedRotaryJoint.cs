using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionBasedRotaryJoint : RotaryJoint
{
    [Header("Parameters (will override LagSystem params)")]
    [SerializeField]
    private bool _override = false;
    [SerializeField]
    private float _T = 1.0f;
    [SerializeField] 
    private float _angle_min = 0.0f;
    [SerializeField]
    private float _angle_max = 180.0f;

    public override void Start()
    {
        if (_override)
        {
            _lagSystem.T = _T;
            _lagSystem.value_min = _angle_min;
            _lagSystem.value_max = _angle_max;
        }
        else
        {
            _T = _lagSystem.T;
            _angle_min = _lagSystem.value_min;
            _angle_max = _lagSystem.value_max;
        }
        base.Start();
    }
    public override void Update()
    {
        _controlTarget.rotation *= Quaternion.AngleAxis(_lagSystem.d_value, _axis);
        base.Update();
    }
}
