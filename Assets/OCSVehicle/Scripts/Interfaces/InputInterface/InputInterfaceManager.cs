using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InputInterfaceManager : AttachableScriptableObjectManager
{
    private InputInterface _interface;
    [HideInInspector]
    public float input;

    [HideInInspector]
    public Transform transform;

    public override void Start()
    {
        base.Start();
        _interface = base._scriptableObject as InputInterface;
        if (_interface) {
            if (transform) _interface.SetTransform(transform);
            _interface.Start(); 
        }
        else Debug.LogError("Type of InputInterface does not match.");
    }

    public override void Update()
    {
        if (Application.isPlaying && _interface)
        {
            input = _interface.input;
        }
        base.Update();
    }
}
