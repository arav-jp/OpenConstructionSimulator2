using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class NoLag : TransferFunctionCalculator
{
    public override float Calc(float input, float time, float initial)
    {
        return Mathf.Clamp(input, output_min, output_max);
    }
}
