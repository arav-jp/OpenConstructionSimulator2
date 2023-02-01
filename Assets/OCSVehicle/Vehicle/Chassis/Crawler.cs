using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crawler : Chassis
{
    #region Objects
    [Header("Objects")]
    [SerializeField]
    private CrawlerUnit _unitL;
    [SerializeField]
    private CrawlerUnit _unitR;
    #endregion

    #region Parameters
    [SerializeField]
    private float _maxTorque = 1.0f;
    #endregion

    private void Awake()
    {
        
    }

    private void Start()
    {
        
    }

    public override void Update()
    {
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
