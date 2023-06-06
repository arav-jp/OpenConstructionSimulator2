using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class InspectorInput : InputInterface
{
    [SerializeField] private float _inputValue;

    public override void Update()
    {
        base.input = _inputValue;
    }
}
