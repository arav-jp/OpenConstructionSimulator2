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

    new public virtual void Start()
    {
        transferFunction.Start();
        base.Start();
    }

    new public virtual void Update()
    {
        transferFunction.Update();
        base.Update();
        if (!Application.isPlaying) return;
        if (!useUnityInput) transferFunction.SetInput(inputManager.input);
    }

    public override void UnityInput(float inputValue)
    {
        if (!useUnityInput) return;
        transferFunction.SetInput(inputValue);
    }
}
