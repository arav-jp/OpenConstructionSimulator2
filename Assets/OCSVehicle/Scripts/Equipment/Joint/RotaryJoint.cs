using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotaryJoint : Equipment
{
    #region Objects
    [Header("Objects")]
    [SerializeField]
    protected LagSystem _lagSystem;

    [SerializeField]
    protected Transform _controlTarget;
    #endregion

    #region Parameters
    [Header("Parameters")]
    [SerializeField]
    protected Vector3 _axis = Vector3.right;
    #endregion

    public virtual void Start()
    {
    }

    new public virtual void Update()
    {
        base.Update();
    }

    public override void UpdateInput(float[] inputValues)
    {
        if (inputValues.Length != 1)
        {
            return;
        }
        _lagSystem.SetTarget(inputValues[0]);
    }
}
