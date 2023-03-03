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

    public override void UnityInput(float inputValue)
    {
        foreach (Light light in _lights)
        {
            light.enabled = inputValue > 0.5f ? true : false;
        }
    }
}
