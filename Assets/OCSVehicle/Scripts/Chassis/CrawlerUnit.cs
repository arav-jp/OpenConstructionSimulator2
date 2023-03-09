using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class CrawlerUnit : Equipment
{
    #region Objects
    [Header("Objects")]
    [SerializeField]
    private WheelCollider[] _wheelColliders;

    [SerializeField]
    private Transform _wheelCollidersParent;
    #endregion

    #region Parameters
    [SerializeField]
    private float _maxTorque = 1.0f;
    [SerializeField]
    private float _brakeTorque = 1.0f;
    #endregion

    #region Utils
    private Transform _transform;
    #endregion

    private void Awake()
    {
        _transform = this.transform;

        if (_wheelCollidersParent)
            _wheelColliders = new WheelCollider[_wheelCollidersParent.childCount];
    }

    public override void Start()
    {
        base.Start();
        if (!Application.isPlaying) return;
        if (_wheelCollidersParent)
        {
            for (int i = 0; i < _wheelCollidersParent.childCount; i++)
            {
                Transform child = _wheelCollidersParent.GetChild(i);
                _wheelColliders[i] = child.GetComponent<WheelCollider>();
            }
        }
    }

    public override void Update()
    {
        base.Update();
        if (!Application.isPlaying) return;
        if (!useUnityInput)
        {
            UpdateTorque(Mathf.Clamp(inputManager.input, -1.0f, 1.0f) * _maxTorque);
            UpdateBrakeTorque(Mathf.Abs(inputManager.input) < 0.01f ? _brakeTorque : 0.0f);
        }
    }

    public override void UnityInput(float inputValue)
    {
        if (!useUnityInput) return;
        UpdateTorque(Mathf.Clamp(inputValue, -1.0f, 1.0f) * _maxTorque);
        UpdateBrakeTorque(Mathf.Abs(inputValue) < 0.01f ? _brakeTorque : 0.0f);
    }

    public void UpdateTorque(float torque)
    {
        foreach(WheelCollider wc in _wheelColliders)
        {
            wc.motorTorque = torque;
        }
    }

    public void UpdateBrakeTorque(float torque)
    {
        foreach (WheelCollider wc in _wheelColliders)
        {
            wc.brakeTorque = torque;
        }
    }
}
