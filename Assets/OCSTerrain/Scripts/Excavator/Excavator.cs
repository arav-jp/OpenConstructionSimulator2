using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VoxelSystem;

public class Excavator : MonoBehaviour
{
    #region Inspector
    [SerializeField]
    private VoxelTerrain _voxelTerrain;

    [SerializeField]
    private ActiveZone _activeZone;

    [SerializeField]
    private Transform _originOffsetDirection;

    [SerializeField]
    private float _originOffset;

    [SerializeField]
    private float _height_min;
    [SerializeField]
    private float _height_max;

    [SerializeField]
    private float _timeout;

    [SerializeField]
    private LayerMask _terrainLayer;
    #endregion

    #region Parameters
    private Transform _transform;
    private float _time_start;
    private float _raycastRange;
    #endregion

    #region Properties
    public ActiveZone activeZone { get => _activeZone; }
    #endregion

    private void Awake()
    {
        _transform = transform;
    }

    private void Update()
    {
        float time_now = Time.time;
        if(time_now - _time_start > _timeout)
        {
            _voxelTerrain.Inactivate();
        }
        _raycastRange = _height_max - _height_min;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Terrain") return;
        _voxelTerrain.Inactivate();

        Vector3 origin = new Vector3(_transform.position.x, _height_max, _transform.position.z) - _originOffsetDirection.forward * _originOffset;
        Ray ray = new Ray(origin, Vector3.down);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, _raycastRange, _terrainLayer))
        {
            TerrainManager tm = other.GetComponent<TerrainManager>();
            if (tm) _voxelTerrain.SetTargetTerrain(tm);
            _voxelTerrain.Activate(hit.point);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag != "Terrain") return;
        _time_start = Time.time;
    }
}
