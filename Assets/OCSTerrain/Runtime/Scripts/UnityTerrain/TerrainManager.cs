using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Terrain))]
public class TerrainManager : MonoBehaviour
{
    #region Inspector
    [SerializeField]
    private float _hz;
    [SerializeField]
    private float _depth;
    #endregion
    #region Parameters
    private Transform _transform;
    private Terrain _terrain;
    private TerrainData _terrainData;

    private Vector3 _offset;

    private float[,] _heightmap;
    private float[,] _heightmap_original;

    private Vector3 _dimentionRatio;

    private float _hz_inv;
    private float _time_old;
    #endregion

    #region Properties
    public Vector3 terrainSize { get => _terrainData.size; }
    public float[,] heightmap { get => _heightmap; set => _heightmap = value; }
    public float height { get => _terrainData.size.y; }
    public float height_min { get => _transform.position.y; }
    public float height_max { get => _transform.position.y + _terrainData.size.y; }
    public Vector3 dimentionRatio { get => _dimentionRatio; }
    public int heightmapResolution { get => _terrainData.heightmapResolution; }
    #endregion

    private void Awake()
    {
        _transform = transform;
        _terrain = GetComponent<Terrain>();
    }

    private void Start()
    {
        _terrainData = _terrain.terrainData;
        _transform.position -= Vector3.up * _depth;
        _offset = _transform.position;
        _heightmap = _terrainData.GetHeights(0, 0, heightmapResolution, heightmapResolution);
        _heightmap_original = _terrainData.GetHeights(0, 0, heightmapResolution, heightmapResolution);
        _dimentionRatio = new Vector3(heightmapResolution / terrainSize.x, 1.0f / terrainSize.y, heightmapResolution / terrainSize.z);
        _hz_inv = 1.0f / _hz;

        AddOffset(_depth);
    }

    private void Update()
    {
        float time_now = Time.time;
        if (time_now - _time_old < _hz_inv) return;
        _time_old = time_now;
        _terrain.terrainData.SetHeights(0, 0, _heightmap);
    }

    private void OnApplicationQuit()
    {
        _terrain.terrainData.SetHeights(0, 0, _heightmap_original);
    }

    public void AddOffset(float offset)
    {
        for(int x = 0; x < heightmapResolution; x++)
        {
            for (int z = 0; z < heightmapResolution; z++)
            {
                _heightmap[z, x] += offset * _dimentionRatio.y;
            }
        }
        _terrain.terrainData.SetHeights(0, 0, _heightmap);
    }

    public void SetHeight(int x, int z, float height)
    {
        if (x < 0 || heightmapResolution <= x || z < 0 || heightmapResolution <= z) return;
        _heightmap[z, x] = (height - _offset.y) * _dimentionRatio.y;
    }

    public (int, int) Position2Index(Vector3 pos)
    {
        pos -= _offset;
        return (Mathf.FloorToInt(pos.x * _dimentionRatio.x), Mathf.FloorToInt(pos.z * _dimentionRatio.z));
    }

    public Vector3 Index2Position(int x, int z)
    {
        return new Vector3(x/_dimentionRatio.x, 0, z/_dimentionRatio.z) + _offset;
    }
}