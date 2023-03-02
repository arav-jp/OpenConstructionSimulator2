using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SecondOrderLag : TransferFunctionCalculator
{
    [SerializeField] private float _zeta;
    [SerializeField] private float _omega_n;

    public override float Calc(float input, float time, float initial)
    {
        float omega_n_t = time * _omega_n;
        float e = Mathf.Exp(-_zeta * omega_n_t);
        float mag;

        if (_zeta > 1.0f)
        {
            float zeta_sqrt = Mathf.Sqrt(-1.0f + _zeta * _zeta);
            float ep = Mathf.Exp(+zeta_sqrt * omega_n_t);
            float em = Mathf.Exp(-zeta_sqrt * omega_n_t);
            mag = 1.0f - e / zeta_sqrt * 0.5f * ((ep - em) * _zeta + (ep + em) * zeta_sqrt);
        }
        else if (_zeta < 1.0f)
        {
            float zeta_sqrt = Mathf.Sqrt(1.0f - _zeta * _zeta);
            mag = 1.0f - e / zeta_sqrt * Mathf.Sin(zeta_sqrt * omega_n_t + Mathf.Atan(zeta_sqrt / _zeta));
        }
        else
        {
            mag = 1.0f - e * (omega_n_t + 1.0f);
        }
        return Mathf.Clamp(initial + (input - initial) * mag, output_min, output_max);
    }

    public override void SetParams(ref float[] parameters)
    {
        if (parameters == null)
        {
            GetParams(ref parameters);
            return;
        }
        if (parameters.Length != 2) return;
        _zeta = parameters[0];
        _omega_n = parameters[1];
    }

    public override void GetParams(ref float[] parameters)
    {
        parameters = new float[2];
        parameters[0] = _zeta;
        parameters[1] = _omega_n;
    }
}