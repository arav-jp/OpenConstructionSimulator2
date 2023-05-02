using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VoxelSystem;

public class Excavator : MonoBehaviour
{
    #region Inspector
    [SerializeField]
    private TerrainManager _terrain;

    [SerializeField]
    private VoxelTerrain _voxelTerrain;

    [SerializeField]
    private ActiveZone _activeZone;

    [SerializeField]
    private float _timeout;

    [SerializeField]
    private LayerMask _terrainLayer;
    #endregion

    #region Parameters
    private Transform _transform;
    private float _time_start;
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
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Terrain") return;

        Vector3 origin = new Vector3(_transform.position.x, _terrain.height_max + 0.05f, _transform.position.z);
        Ray ray = new Ray(origin, Vector3.down);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, _terrain.height + 0.1f, _terrainLayer))
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
