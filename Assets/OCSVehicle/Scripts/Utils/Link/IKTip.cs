using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKTip : MonoBehaviour
{
    [SerializeField]
    private Transform _target;

    private Transform _transform;

    private void Awake()
    {
        _transform = this.transform;
    }

    private void Update()
    {
        _target.position = _transform.position;
    }
}
