using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionBasedRotaryJoint : RotaryJoint
{
    [Header("Parameters (will override TransferFunction params)")]
    [SerializeField]
    private bool _override = false;
    [SerializeField] 
    private float _angle_min = 0.0f;
    [SerializeField]
    private float _angle_max = 180.0f;

    public override void Start()
    {
        if (_override)
        {
            _transferFunction._output_min = _angle_min;
            _transferFunction._output_max = _angle_max;
        }
        else
        {
            _angle_min = _transferFunction._output_min;
            _angle_max = _transferFunction._output_max;
        }
        base.Start();
    }
    public override void Update()
    {
        _controlTarget.rotation *= Quaternion.AngleAxis(_transferFunction.D_Output(), _axis);
        base.Update();
    }
}
