using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Equipment : MonoBehaviour
{
    #region Debug
#if UNITY_EDITOR
    [Header("Debug")]
    [SerializeField]
    private bool _use_inspectorInput = false;

    [SerializeField]
    private float _inspectorInput;
#endif
    #endregion

    #region Input
    public bool useUnityInput;
    public InputInterfaceManager inputManager;
    #endregion

    public virtual void Start()
    {
        if (!Application.isPlaying) return;
        inputManager.Start();
    }

    public virtual void Update()
    {
        inputManager.Update();
        if (!Application.isPlaying) return;
#if UNITY_EDITOR
        if (_use_inspectorInput) UnityInput(_inspectorInput);
#endif
    }

    public virtual void UnityInput(float inputValue) { }
}
