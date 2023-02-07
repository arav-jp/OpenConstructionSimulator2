using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SecondOrderLag : TransferFunction
{
    [SerializeField] private float _zeta;
    [SerializeField] private float _omega_n;
    private float _output_last;

    public override void Awake()
    {
        _output_last = 0.0f;
        base.Awake();
    }

    public override void Update()
    {
        float omega_n_t = (Time.time - _time_input)*_omega_n;
        float e = Mathf.Exp(-_zeta*omega_n_t);
        float mag;

        if(_zeta > 1.0f)
        {
            float zeta_sqrt = Mathf.Sqrt(-1.0f + _zeta*_zeta);
            float ep = Mathf.Exp(+zeta_sqrt*omega_n_t);
            float em = Mathf.Exp(-zeta_sqrt * omega_n_t);
            mag = 1.0f - e / zeta_sqrt * 0.5f * ((ep-em)*_zeta + (ep+em)*zeta_sqrt);
        }
        else if(_zeta < 1.0f)
        {
            float zeta_sqrt = Mathf.Sqrt(1.0f - _zeta * _zeta);
            mag = 1.0f - e / zeta_sqrt * Mathf.Sin(zeta_sqrt * omega_n_t + Mathf.Atan(zeta_sqrt / _zeta));
        }
        else
        {
            mag = 1.0f - e * (omega_n_t + 1.0f);
        }
        _output = Mathf.Clamp(_output_last + (_input - _output_last) * mag, _output_min, _output_max);

        base.Update();
    }

    public override void Input(float input)
    {
        if (_input == input) return;
        _output_last = _output;
        base.Input(input);
    }
}
