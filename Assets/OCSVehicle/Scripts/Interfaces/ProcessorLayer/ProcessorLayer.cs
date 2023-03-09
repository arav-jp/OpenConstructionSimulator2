using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ProcessorLayer : AttachableScriptableObject
{
    [ReadOnly]
    public float input;

    [ReadOnly]
    public float output;

    public virtual void Start()
    {

    }

    public override void Update()
    {
        base.Update();
    }
}
