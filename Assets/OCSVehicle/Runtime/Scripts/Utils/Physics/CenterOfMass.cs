using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterOfMass : MonoBehaviour
{
    [SerializeField]
    private Rigidbody _rb;

    [SerializeField]
    private Vector3 _centerOfMass;

    [SerializeField]
    private Transform _centerOfMassObj;

    private void Awake()
    {
        if (!_rb) _rb = GetComponent<Rigidbody>();
        if (_centerOfMassObj) _centerOfMass = _centerOfMassObj.position - this.transform.position;
        if (_rb) _rb.centerOfMass = _centerOfMass;
    }
}
