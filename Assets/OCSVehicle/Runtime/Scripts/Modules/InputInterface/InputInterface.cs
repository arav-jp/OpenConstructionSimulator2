using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class InputInterface : AttachableScriptableObject
{
    [ReadOnly]
    public float input;

    protected Transform _transform;

    public virtual void Start()
    {
    
    }

    public override void Update()
    {
        base.Update();
    }

    public void SetTransform(Transform transform) { _transform = transform; }
}
