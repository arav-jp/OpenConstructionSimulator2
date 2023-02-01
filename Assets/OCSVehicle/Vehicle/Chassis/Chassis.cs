using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chassis : MonoBehaviour
{
    #region Debug
#if UNITY_EDITOR
    [Header("Debug")]
    [SerializeField]
    private bool _use_inspectorInput = false;

    [SerializeField]
    private float[] _inspectorInput;
#endif
    #endregion

    public virtual void Update()
    {
#if UNITY_EDITOR
        if(_use_inspectorInput) UpdateInput(_inspectorInput);
#endif
    }

    public virtual void UpdateInput(float[] inputValues) { }
}
