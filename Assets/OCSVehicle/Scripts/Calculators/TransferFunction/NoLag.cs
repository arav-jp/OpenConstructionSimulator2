using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class NoLag : TransferFunction
{
    public override void Update()
    {
        _output = Mathf.Clamp(_input, _output_min, _output_max);
        base.Update();
    }
}
