using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformVelocityVisualizer : Visualizer<TransformVelocity>
{
    [SerializeField]
    private float _lengthCoef;

    protected override void Visualize()
    {
        Gizmos.DrawLine(_target.position, _target.position + _target.velocity.normalized * _lengthCoef);
    }
}
