using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class RotaryJoint : Equipment
{
    #region Objects
    [Header("Objects")]
    public TransferFunction transferFunction;
    [ReadableScriptableObject]
    public TransferFunction _transferFunction;

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
        _transferFunction.Awake();
    }

    public virtual void Start()
    {
    }

    new public virtual void Update()
    {
        base.Update();
        _transferFunction.Update();
    }

    public override void UpdateInput(float[] inputValues)
    {
        if (inputValues.Length != 1)
        {
            return;
        }
        _transferFunction.Input(inputValues[0]);
    }
}

#if UNITY_EDITOR
[CustomEditor(typeof(RotaryJoint), true)]
[CanEditMultipleObjects]
public class RotaryJointEditor : Editor
{
    RotaryJoint _target;

    private void OnEnable()
    {
        if (_target) return;
        _target = (RotaryJoint) target;
    }
    public override void OnInspectorGUI()
    {
        if (_target.transferFunction && (!_target._transferFunction || !_target._transferFunction.name.Contains(_target.transferFunction.name)))
        {
            _target._transferFunction = Instantiate(_target.transferFunction);
        }
        base.OnInspectorGUI();
    }
}
#endif
