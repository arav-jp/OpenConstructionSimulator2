using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrawlerUnit : MonoBehaviour
{
    #region Objects
    [Header("Objects")]
    [SerializeField]
    private WheelCollider[] _wheelColliders;

    [SerializeField]
    private Transform _wheelCollidersParent;
    #endregion

    #region Parameters
    #endregion

    #region Utils
    private Transform _transform;
    #endregion

    #region Debug
#if UNITY_EDITOR
    [Header("Debug")]

    [SerializeField]
    private bool _useInspectorInput = false;

    [SerializeField, Range(-1.0f, 1.0f)]
    private float _inspectorInput = 0.0f;
    [SerializeField]
    private float _inspectorInputMagnitude = 1.0f;
#endif
    #endregion

    private void Awake()
    {
        _transform = this.transform;

        if (_wheelCollidersParent)
            _wheelColliders = new WheelCollider[_wheelCollidersParent.childCount];
    }

    private void Start()
    {
        if (_wheelCollidersParent)
        {
            for (int i = 0; i < _wheelCollidersParent.childCount; i++)
            {
                Transform child = _wheelCollidersParent.GetChild(i);
                _wheelColliders[i] = child.GetComponent<WheelCollider>();
            }
        }
    }

    private void Update()
    {
#if UNITY_EDITOR
        if (_useInspectorInput) UpdateTorque(_inspectorInput*_inspectorInputMagnitude);
#endif
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
