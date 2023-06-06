using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class FirstOrderLag : ProcessorLayer
{
    [SerializeField] private float _T;
    [SerializeField] private float _output_min;
    [SerializeField] private float _output_max;

    private float _input_old;
    private float _output_old;
    private float _time_old;

    public override void Start()
    {
        _input_old = 0.0f;
        _output_old = 0.0f;
        _time_old = 0.0f;
    }

    public override void Update()
    {
        if(base.input != _input_old)
        {
            _input_old = base.input;
            _output_old = base.output;
            _time_old = Time.time;
        }

        float t = (1.0f - Mathf.Exp((_time_old - Time.time) / _T));
        base.output = Mathf.Clamp(t * input + (1 - t) * _output_old, _output_min, _output_max);
    }
}
