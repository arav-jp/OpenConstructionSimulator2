using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class RigidbodyLimitter : MonoBehaviour
{
    [SerializeField]
    private Rigidbody _rb;

    [SerializeField]
    private float _maxVelocity = 1.0f;
    private float _maxVelocity2;
    [SerializeField]
    private float _maxAngularVelocity = 1.0f;

    private void Awake()
    {
        if (!_rb) _rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        _rb.maxDepenetrationVelocity = _maxVelocity;
        _rb.maxAngularVelocity = _maxAngularVelocity;

        _maxVelocity2 = _maxVelocity * _maxVelocity;
    }

    public void Update()
    {
        if (_rb.velocity.sqrMagnitude > _maxVelocity2)
        {
            _rb.velocity = _rb.velocity.normalized * _maxVelocity;
        }
    }
}
