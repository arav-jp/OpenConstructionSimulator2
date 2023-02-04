using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class FirstOrderLag : TransferFunction
{
    [SerializeField] private float _T;
    private float _output_last;

    public override void Awake()
    {
        _output_last = 0.0f;
        base.Awake();
    }

    public override void Update()
    {
        float t = (1.0f - Mathf.Exp(-(Time.time - _time_input) / _T));
        _output = Mathf.Clamp(t * _input + (1 - t) * _output_last, _output_min, _output_max);
        base.Update();
    }

    public override void Input(float input)
    {
        if (_input == input) return;
        _output_last = _output;
        base.Input(input);
    }
}
