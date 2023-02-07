using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class TransferFunction : ScriptableObject
{
    protected float _input;
    protected float _output;

    protected float _time_input;

    public float _output_min;
    public float _output_max;

    private float _d_output;
    private float _output_old;

    public virtual void Awake()
    {
        _input = 0.0f;
        _output = 0.0f;
        _time_input = 0.0f;
        _d_output = 0.0f;
        _output_old = 0.0f;
    }

    public virtual void Update()
    {
        _d_output = _output - _output_old;
        _output_old = _output;
    }

    public virtual void Input(float input)
    {
        if (_input == input) return;
        _input = input;
        _time_input = Time.time;
    }

    public virtual float Output()
    {
        return _output;
    }

    public virtual float D_Output()
    {
        return _d_output;
    }
}