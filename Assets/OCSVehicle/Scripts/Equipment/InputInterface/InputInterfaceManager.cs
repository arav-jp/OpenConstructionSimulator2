using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InputInterfaceManager
{
    [System.Serializable]
    public struct InputInterfaceParameters
    {
        [ReadOnly]
        public string[] stringParams;
    }

    public InputInterface inputInterface;
    [ReadableScriptableObject]
    [SerializeField]
    InputInterface _inputInterface;

    [SerializeField]
    private InputInterfaceParameters parameters;

    public float inputValue { get => _inputInterface.inputValue; }

    public void Start()
    {
        if (!inputInterface) Debug.LogError("No input interface");
        if (!_inputInterface) _inputInterface = Object.Instantiate(inputInterface);
        _inputInterface.SetParams(ref parameters);
        _inputInterface.Start();
    }

    [ExecuteInEditMode]
    public void Update()
    {
        if (!Application.isPlaying)
        {
            if (inputInterface && (!_inputInterface || _inputInterface.GetType() != inputInterface.GetType()))
            {
                _inputInterface = Object.Instantiate(inputInterface);
                _inputInterface.SetParams(ref parameters);
            }
            if (_inputInterface)
            {
                _inputInterface.GetParams(ref parameters);
            }
            return;
        }
        _inputInterface.Update();
    }
}
