using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soil : MonoBehaviour
{
    [SerializeField, ReadOnly]
    private float _volume;
    [SerializeField, ReadOnly]
    private float _diameter;

    private SoilManager _manager;
    private Transform _transform;
    private GameObject _gameObject;

    private const float _v2d_coef = 3.666873708f; // 12.0f / (5.0f * (3.0f + Mathf.Sqrt(5.0f))) * 2.0^3

    public void Init(SoilManager manager)
    {
        _manager = manager;
    }

    private void Awake()
    {
        _transform = transform;
        _gameObject = gameObject;
    }

    private void Start()
    {
        _transform.localScale = Vector3.one * _diameter;
    }

    private void Update()
    {
        
    }

    public void Activate(Vector3 position, float volume)
    {
        _transform.position = position;
        _diameter = Mathf.Pow(volume * _v2d_coef, 1.0f / 3.0f);
        _transform.localScale = Vector3.one * _diameter;
        _gameObject.SetActive(true);
    }

    public void Inactivate()
    {
        _gameObject.SetActive(false);
    }

    public bool IsActivated()
    {
        return _gameObject.activeSelf;
    }
}
