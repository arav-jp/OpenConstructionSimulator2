using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformVelocity : MonoBehaviour
{
    private Transform _transform;
    private Vector3 _position_old;

    private Vector3 _position;
    [SerializeField, ReadOnly]
    private Vector3 _velocity;

    public Vector3 position { get => _position; }
    public Vector3 velocity { get => _velocity; }
    public Vector3 direction { get => _velocity.normalized; }

    private void Awake()
    {
        _transform = this.transform;
    }

    private void OnEnable()
    {
        _position_old = _transform.position;
    }

    private void Update()
    {
        _position = _transform.position;
        _velocity = (_position - _position_old) / Time.deltaTime;
        _position_old = _position;
    }
}
