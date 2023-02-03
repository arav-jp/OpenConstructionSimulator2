using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LagSystem : MonoBehaviour
{
    #region Debug
#if UNITY_EDITOR
    [Header("Debug")]
    [SerializeField]
    private bool _setTarget = false;
    [SerializeField]
    private float _targetValue = 0.0f;
#endif
    #endregion

    #region Parameters
    [Header("Parameters")]

    [SerializeField]
    protected float _T;
    public float T { get => _T; set => _T = value; }

    [SerializeField]
    protected float _value_min;
    public float value_min { get => _value_min; set => _value_min = value; }

    [SerializeField]
    protected float _value_max;
    public float value_max { get => _value_max; set => _value_max = value; }
    #endregion

    #region Result
    [Header("Results")]
    [SerializeField]
    protected float _value;
    public float value { get => this._value; }

    [SerializeField]
    private float _d_value;
    public float d_value { get => this._d_value; }
    #endregion

    [HideInInspector]
    public float _value_target;
    private float _value_old;

    protected float _value_last;
    protected float _time_last;

    protected virtual void Update()
    {
        _d_value = _value - _value_old;
        _value_old = _value;
#if UNITY_EDITOR
        if (_setTarget)
        {
            SetTarget(_targetValue);
            _setTarget = false;
        }
#endif
    }

    public virtual void SetTarget(float value_target)
    {
        if (value_target == _value_target) return;
        _value_target = value_target;
        _value_last = _value;
        _time_last = Time.time;
    }
}
