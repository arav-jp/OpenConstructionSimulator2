using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soil : MonoBehaviour
{
    [SerializeField]
    private Rigidbody _rb;

    [SerializeField]
    private float _lifeTime;

    [SerializeField, ReadOnly]
    private float _volume;
    [SerializeField, ReadOnly]
    private float _diameter;

    private SoilManager _manager;
    private Zone _zone;
    private Transform _transform;
    private GameObject _gameObject;

    private float _timer;

    private const float _v2d_coef = 3.666873708f; // 12.0f / (5.0f * (3.0f + Mathf.Sqrt(5.0f))) * 2.0^3

    public void Init(SoilManager manager, Zone zone)
    {
        _manager = manager;
        _zone = zone;
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
        float time_now = Time.time;
        if (_zone.IsPointInZone(_transform.position))
        {
            _timer = time_now;
            return;
        }
        if(time_now - _timer > _lifeTime)
        {
            Inactivate();
        }
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
