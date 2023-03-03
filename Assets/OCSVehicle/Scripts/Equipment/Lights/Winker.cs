using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Winker : Equipment
{
    #region Objects
    [SerializeField]
    private Light[] _lights;
    #endregion

    #region Parameters
    [SerializeField]
    private float _frequency = 20.0f;
    [SerializeField]
    private float _maxIntensity = 1.0f;
    #endregion

    private bool _enabled;

    public override void Update()
    {
        float intensity = _enabled ? 0.5f * (Mathf.Sin(Time.time * _frequency) + 1.0f) * _maxIntensity : 0.0f;
        foreach (Light light in _lights)
            light.intensity = intensity;


        base.Update();
    }

    public override void UnityInput(float inputValue)
    {
        _enabled = inputValue  > 0.5f ? true : false;
    }
}
