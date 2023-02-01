using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crawler : Chassis
{
    #region Objects
    [Header("Objects")]
    [SerializeField]
    private Rigidbody _rb;
    [SerializeField]
    private CrawlerUnit _unitL;
    [SerializeField]
    private CrawlerUnit _unitR;
    #endregion

    #region Parameters
    [SerializeField]
    private float _maxTorque = 1.0f;

    [SerializeField]
    private float _maxVelocity = 1.0f;
    private float _maxVelocity2;
    [SerializeField]
    private float _maxAngularVelocity = 1.0f;
    #endregion

    private void Awake()
    {
        
    }

    private void Start()
    {
        _rb.maxDepenetrationVelocity = _maxVelocity;
        _rb.maxAngularVelocity = _maxAngularVelocity;

        _maxVelocity2 = _maxVelocity * _maxVelocity;
    }

    public override void Update()
    {
        if(_rb.velocity.sqrMagnitude > _maxVelocity2)
        {
            _rb.velocity = _rb.velocity.normalized * _maxVelocity;
        }
        base.Update();
    }

    public override void UpdateInput(float[] inputValues)
    {
        if (inputValues.Length != 2)
        {
            return;
        }
        _unitL.UpdateTorque(Mathf.Clamp(inputValues[0], -1.0f, 1.0f)*_maxTorque);
        _unitR.UpdateTorque(Mathf.Clamp(inputValues[1], -1.0f, 1.0f)*_maxTorque);
    }
}
