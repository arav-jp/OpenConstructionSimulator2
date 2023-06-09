using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterOfMass : MonoBehaviour
{
    [SerializeField]
    private ArticulationBody _ab;

    [SerializeField]
    private Vector3 _centerOfMass;

    [SerializeField]
    private Transform _centerOfMassObj;

    private void Awake()
    {
        if (!_ab) _ab = GetComponent<ArticulationBody>();
    }

    private void Start()
    {
        if (_centerOfMassObj) _centerOfMass = _centerOfMassObj.position - this.transform.position;
        if (_ab) _ab.centerOfMass = _centerOfMass;
    }
}
