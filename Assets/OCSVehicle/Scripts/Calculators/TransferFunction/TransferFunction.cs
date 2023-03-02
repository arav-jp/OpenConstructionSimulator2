using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[System.Serializable]
public class TransferFunction
{
    public TransferFunctionCalculator calculator;
    [ReadableScriptableObject]
    [SerializeField]
    TransferFunctionCalculator _calculator;

    [SerializeField]
    [ReadOnly]
    private float[] parameters;

    public float output_min { get => _calculator.output_min; set => _calculator.output_min = value; }
    public float output_max { get => _calculator.output_max; set => _calculator.output_max = value; }

    private float _input;
    public float input { set => SetInput(value); }

    private float _output;
    public float output { get => _output; }
    private float _output_last;

    private float _d_output;
    public float d_output { get => _d_output; }
    private float _output_old;

    private float _inputTime;

    public void Start()
    {
        if (!calculator) Debug.LogError("No calculator");
        if (!_calculator) _calculator = Object.Instantiate(calculator);
        _calculator.SetParams(ref parameters);
    }

    [ExecuteInEditMode]
    public void Update()
    {
        if (!Application.isPlaying)
        {
            if (calculator && (!_calculator || _calculator.GetType() != calculator.GetType()))
            {
                _calculator = Object.Instantiate(calculator);
                _calculator.SetParams(ref parameters);
            }
            if (_calculator)
            {
                _calculator.GetParams(ref parameters);
            }
            return; 
        }
        _output = _calculator.Calc(_input, Time.time - _inputTime, _output_last);
        _d_output = _output - _output_old;
        _output_old = _output;
    }

    public void SetInput(float value)
    {
        if (value == _input) return;
        _inputTime = Time.time;
        _output_last = _output;
        _input = value;
    }
}
