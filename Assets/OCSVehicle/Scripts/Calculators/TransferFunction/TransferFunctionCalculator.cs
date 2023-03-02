using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class TransferFunctionCalculator : ScriptableObject
{
    public float output_min;
    public float output_max;

    public virtual float Calc(float input, float time, float initial)
    {
        return input;
    }

    public virtual void SetParams(ref float[] parameters)
    {
    }

    public virtual void GetParams(ref float[] parameters)
    {
        
    }
}

