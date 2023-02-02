using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstOrderLagSystem : LagSystem
{
    protected override void Update()
    {
        float t = (1.0f - Mathf.Exp(-(Time.time - _time_last) / _T));
        _value = Mathf.Clamp(t * _value_target + (1 - t) * _value_last, _value_min, _value_max);
        base.Update();
    }
}
