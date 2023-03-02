using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class FirstOrderLagCalculator : TransferFunctionCalculator
{
    [SerializeField] private float _T;

    public override float Calc(float input, float time, float initial)
    {
        float t = (1.0f - Mathf.Exp(-time / _T));
        return Mathf.Clamp(t * input + (1 - t) * initial, output_min, output_max);
    }

    public override void SetParams(ref float[] parameters)
    {
        if (parameters == null)
        {
            GetParams(ref parameters);
            return;
        }
        if (parameters.Length != 1) return;
        _T = parameters[0];
    }

    public override void GetParams(ref float[] parameters)
    {
        parameters = new float[1];
        parameters[0] = _T;
    }
}

