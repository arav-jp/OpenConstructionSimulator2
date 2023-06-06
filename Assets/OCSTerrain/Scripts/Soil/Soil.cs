using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soil : MonoBehaviour
{
    [SerializeField]
    private Rigidbody _rb;

    [SerializeField]
    private float _lifeTime;

    [SerializeField]
    private float _maxVelocity;

    [SerializeField, ReadOnly]
    private float _volume;
    [SerializeField, ReadOnly]
    private float _density;
    [SerializeField, ReadOnly]
    private float _diameter;

    [SerializeField]
    private LayerMask _terrainLayer;

    private SoilManager _manager;
    private VoxelSystem.VoxelTerrain _voxelTerrain;
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
        _rb.maxDepenetrationVelocity = _maxVelocity;
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

    public bool Activate(Vector3 position, float volume, float density)
    {
        _diameter = Mathf.Pow(volume * _v2d_coef, 1.0f / 3.0f);

        Ray ray = new Ray(_transform.position - Vector3.down * _diameter * 0.5f, Vector3.down);
        if (!Physics.Raycast(ray, 10.0f, _terrainLayer))
        {
            return false;
        }

        _transform.position = position;
        _volume = volume;
        _density = density;
        _transform.localScale = Vector3.one * _diameter;

        _rb.mass = _volume * _density;
        _rb.velocity = Vector3.zero;
        _rb.angularVelocity = Vector3.zero;

        _gameObject.SetActive(true);
        return true;
    }

    public void Inactivate()
    {
        if (!_gameObject.activeSelf) return;
        if (_voxelTerrain)
        {
            _voxelTerrain.Depositting(_transform.position, _volume, _density);
        }
        _gameObject.SetActive(false);
    }

    public bool IsActivated()
    {
        return _gameObject.activeSelf;
    }

    public void SetVoxelTerrain(VoxelSystem.VoxelTerrain voxelTerrain)
    {
        _voxelTerrain = voxelTerrain;
    }
}
