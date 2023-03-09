using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[System.Serializable]
public class AttachableScriptableObjectManager
{
    public AttachableScriptableObject scriptableObject;

    public string _parametersCache;
    [ReadableScriptableObject]
    [SerializeField]
    protected AttachableScriptableObject _scriptableObject;

    public virtual void Start()
    {
        if (!_scriptableObject && scriptableObject) _scriptableObject = GameObject.Instantiate(scriptableObject);
        if (_scriptableObject) JsonUtility.FromJsonOverwrite(_parametersCache, _scriptableObject);
    }

    public virtual void Update()
    {
        if (!Application.isPlaying)
        {
            if (!scriptableObject) return;
            if (!_scriptableObject || _scriptableObject.GetType() != scriptableObject.GetType())
            {
                _scriptableObject = GameObject.Instantiate(scriptableObject);
                JsonUtility.FromJsonOverwrite(_parametersCache, _scriptableObject);
            }
            if (!_scriptableObject) return;
            _parametersCache = JsonUtility.ToJson(_scriptableObject);
            return;
        }
        if (_scriptableObject) _scriptableObject.Update();
    }
}
