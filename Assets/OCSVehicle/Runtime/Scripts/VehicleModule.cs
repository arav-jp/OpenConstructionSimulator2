using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OCS.Vehicle
{
    public class VehicleModule : MonoBehaviour
    {
        [SerializeField]
        protected string _moduleName;
        public string moduleName { get => _moduleName; }
        public virtual System.Type moduleType { get => typeof(VehicleModule); }
    }
}

/*
[ExecuteAlways]
public class VehicleModule : MonoBehaviour
{
    [SerializeField] private InputInterfaceManager _input;
    [SerializeField] private ProcessorLayerManager _transferFunction; 
    [SerializeField] private OutputInterfaceManager _output;

    public InputInterfaceManager input { get => this._input; }

    private Transform _transform;

    private void Awake()
    {
        _transform = this.transform;
    }

    private void Start()
    {
        if (!Application.isPlaying) return;

        _input.transform = _transform;
        _output.transform = _transform;

        _input.Start();
        _transferFunction.Start();
        _output.Start();
    }

    private void Update()
    {
        _input.Update();

        _transferFunction.input = _input.input;
        _transferFunction.Update();
        _output.output = _transferFunction.output;

        _output.Update();

        if (!Application.isPlaying && (_input.updated || _transferFunction.updated || _output.updated))
        {
            EditorUtility.SetDirty(this);
        }
    }
}
*/