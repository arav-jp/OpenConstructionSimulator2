using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Parameters = InputInterfaceManager.InputInterfaceParameters;

[CreateAssetMenu]
public class InputInterface : ScriptableObject
{
    private Parameters _params;

    protected float _input;
    public float inputValue { get => this._input; }

    public virtual void Start()
    {
    
    }

    public virtual void Update()
    {
    
    }

    public virtual void SetParams(ref Parameters param)
    {

    }

    public virtual void GetParams(ref Parameters param)
    {
    
    }
}
