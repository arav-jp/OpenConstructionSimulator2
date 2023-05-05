using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soil : MonoBehaviour
{
    [SerializeField, ReadOnly]
    private float _volume;
    [SerializeField, ReadOnly]
    private float _diameter;

    private const float _v2d_coef = 0.458359213f; // 12.0f / (5.0f * (3.0f + Mathf.Sqrt(5.0f)))

    public void Init(float volume)
    {
        _volume = volume;
        _diameter = Mathf.Pow(_volume * _v2d_coef, 1.0f / 3.0f);
    }

    private void Awake()
    {
        
    }

    private void Start()
    {
    }

    private void Update()
    {
        
    }
}
