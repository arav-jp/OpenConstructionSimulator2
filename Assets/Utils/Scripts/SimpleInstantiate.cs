using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleInstantiate : MonoBehaviour
{
    [SerializeField]
    private GameObject _obj;
    private Transform _transform;

    private void Awake()
    {
        _transform = transform;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) Instantiate(_obj, _transform.position, _transform.rotation);
    }
}
