using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class OutputInterface : AttachableScriptableObject
{
    [ReadOnly]
    public float output;

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
