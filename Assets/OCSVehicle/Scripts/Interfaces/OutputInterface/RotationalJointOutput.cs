using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class RotationalJointOutput : OutputInterface
{
    enum ControlType
    {
        Position,
        Velocity
    }

    [SerializeField] private ControlType _controlType;

    [SerializeField] private Vector3 _axis = Vector3.right;

    [SerializeField] private float _angularVelocity_min;
    [SerializeField] private float _angularVelocity_max;
    [SerializeField] private bool _angle_limit;
    [SerializeField] private float _angle_init;
    [SerializeField] private float _angle_min;
    [SerializeField] private float _angle_max;

    private float _output_old;
    private float _angle;

    public override void Start()
    {
        _output_old = 0.0f;
        _angle = _angle_init;
        base.Start();
    }

    public override void Update()
    {
        float d_output = base.output - _output_old;
        _output_old = base.output;
        switch (_controlType)
        {
            case ControlType.Position:
                base._transform.rotation *= Quaternion.AngleAxis(d_output, _axis);
                break;
            case ControlType.Velocity:
                float d_angle = Mathf.Clamp(base.output, _angularVelocity_min, _angularVelocity_max) * Time.deltaTime;
                base._transform.rotation *= Quaternion.AngleAxis(d_angle, _axis);
                _angle += d_angle;

                if (_angle > _angle_max && _angle_limit)
                {
                    base._transform.rotation *= Quaternion.AngleAxis(-_angle + _angle_max, _axis);
                    _angle = _angle_max;
                }
                else if (_angle < _angle_min && _angle_limit)
                {
                    base._transform.rotation *= Quaternion.AngleAxis(-_angle + _angle_min, _axis);
                    _angle = _angle_min;
                }
                break;
            default:
                break;
        }
        base.Update();
    }
}

