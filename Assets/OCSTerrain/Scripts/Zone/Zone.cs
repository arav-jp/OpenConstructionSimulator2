using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class Zone : MonoBehaviour
{
    protected Transform _transform;

    protected float _volume;
    public float volume { get => _volume; }

    protected virtual void Awake()
    {
        _transform = transform;
    }

    protected virtual void Start()
    {
    
    }

    private void OnEnable()
    {
        Awake();
        Start();
    }

    private void Update()
    {
        if(!Application.isPlaying) Start();
    }

    public virtual bool IsPointInZone(Vector3 point) { return false; }

    public virtual void Visualize() { }
}
