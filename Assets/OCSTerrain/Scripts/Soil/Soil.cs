using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soil : MonoBehaviour
{
    [SerializeField, ReadOnly]
    private float _volume;
    [SerializeField, ReadOnly]
    private float _diameter;

    private Transform _transform;

    private const float _v2d_coef = 3.666873708f; // 12.0f / (5.0f * (3.0f + Mathf.Sqrt(5.0f))) * 2.0^3

    public void Init(float volume)
    {
        _volume = volume;
        _diameter = Mathf.Pow(_volume * _v2d_coef, 1.0f / 3.0f);
    }

    private void Awake()
    {
        _transform = transform;
    }

    private void Start()
    {
        _transform.localScale = Vector3.one * _diameter;
    }

    private void Update()
    {
        
    }
}
