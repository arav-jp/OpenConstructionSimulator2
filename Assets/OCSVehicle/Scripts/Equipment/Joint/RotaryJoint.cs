using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

[ExecuteInEditMode]
public class RotaryJoint : Equipment
{
    #region Objects
    [Header("Objects")]
    public TransferFunction transferFunction;

    [SerializeField]
    protected Transform _controlTarget;
    #endregion

    #region Parameters
    [Header("Parameters")]
    [SerializeField]
    protected Vector3 _axis = Vector3.right;
    #endregion

    public virtual void Awake()
    {
    }

    public virtual void Start()
    {
        transferFunction.Start();
    }

    new public virtual void Update()
    {
        transferFunction.Update();
        if (!Application.isPlaying) return;
        base.Update();
    }

    public override void UpdateInput(float[] inputValues)
    {
        if (inputValues.Length != 1)
        {
            return;
        }
        transferFunction.SetInput(inputValues[0]);
    }
}
