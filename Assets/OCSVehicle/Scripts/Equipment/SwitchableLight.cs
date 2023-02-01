using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchableLight : Equipment
{
    #region Objects
    [SerializeField]
    private Light[] _lights;
    #endregion

    public override void Update()
    {
        base.Update();
    }

    public override void UpdateInput(float[] inputValues)
    {
        if (inputValues.Length != 1)
        {
            return;
        }
        foreach (Light light in _lights)
        {
            light.enabled = inputValues[0] > 0.5f ? true : false;
        }
    }
}
