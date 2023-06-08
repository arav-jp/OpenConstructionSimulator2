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
    private Vector3 _offset;

    private void Awake()
    {
        _transform = transform;
    }

    private void Start()
    {
        _offset = _transform.position;
    }

    private void Update()
    {
        _transform.position = new Vector3(Mathf.Sin(Time.time) * 3.0f, 0.0f, 0.0f) + _offset;
        _result = _targetZone.IsPointInZone(_transform.position);
    }

    private void OnDrawGizmos()
    {
        if (!Application.isPlaying) return;
        Gizmos.color = _result ? Color.red : Color.blue;
        Gizmos.DrawSphere(_transform.position, 0.05f);
    }
}
