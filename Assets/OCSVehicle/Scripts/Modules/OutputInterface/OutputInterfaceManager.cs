using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class OutputInterfaceManager : AttachableScriptableObjectManager
{
    private OutputInterface _interface;

    [HideInInspector]
    public float output;

    [HideInInspector]
    public Transform transform;

    public override void Start()
    {
        base.Start();
        _interface = base._scriptableObject as OutputInterface;
        if (_interface)
        {
            if (transform) _interface.SetTransform(transform);
            _interface.Start();
        }
        else { Debug.LogError("Type of OutputInterface does not match."); }
    }

    public override void Update()
    {
        if (Application.isPlaying && _interface)
        {
            _interface.output = output;
        }
        base.Update();
    }
}
