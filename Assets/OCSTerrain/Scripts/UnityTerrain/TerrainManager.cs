using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Terrain))]
public class TerrainManager : MonoBehaviour
{
    #region Parameters
    private Transform _transform;
    private Terrain _terrain;
    private TerrainData _terrainData;

    private float[,] _heightmap;
    private float[,] _heightmap_original;
    #endregion

    #region Properties
    public Vector3 terrainSize { get => _terrainData.size; }
    public float height { get => _terrainData.size.y; }
    public float height_min { get => _transform.position.y; }
    public float height_max { get => _transform.position.y + _terrainData.size.y; }
    #endregion

    private void Awake()
    {
        _transform = transform;
        _terrain = GetComponent<Terrain>();
    }

    private void Start()
    {
        _terrainData = _terrain.terrainData;
    }

    private void Update()
    {
        
    }

    public float GetHeight(Vector3 pos)
    {
        return 0.0f;
    }
}
