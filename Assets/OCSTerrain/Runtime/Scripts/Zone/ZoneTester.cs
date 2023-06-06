using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneTester : MonoBehaviour
{
    [SerializeField]
    private bool _result;

    [SerializeField]
    private Zone _targetZone;

    private Transform _transform;

    private void Awake()
    {
        _transform = transform;
    }

    private void Update()
    {
        _result = _targetZone.IsPointInZone(_transform.position);
    }
}
