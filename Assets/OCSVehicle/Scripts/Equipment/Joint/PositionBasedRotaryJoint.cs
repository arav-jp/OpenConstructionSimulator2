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
            transferFunction.output_min = _angle_min;
            transferFunction.output_max = _angle_max;
        }
        else
        {
            _angle_min = transferFunction.output_min;
            _angle_max = transferFunction.output_max;
        }
        base.Start();
    }
    public override void Update()
    {
        base.Update();
        if (!Application.isPlaying) return;
        _controlTarget.rotation *= Quaternion.AngleAxis(transferFunction.d_output, _axis);
    }
}
