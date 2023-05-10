using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ProcessorLayerManager : AttachableScriptableObjectManager
{
    private ProcessorLayer _processor;
    [HideInInspector]
    public float input;

    [HideInInspector]
    public float output;

    public override void Start()
    {
        base.Start();
        _processor = base._scriptableObject as ProcessorLayer;
        if (_processor) _processor.Start();
        else Debug.LogError("Type of ProcessorLayer does not match.");
    }

    public override void Update()
    {
        if (Application.isPlaying && _processor)
        {
            _processor.input = input;
            output = _processor.output;
        }
        base.Update();
    }
}
