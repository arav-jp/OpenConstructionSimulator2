using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TerrainManager
{
    public Terrain terrain;
    public Transform transform;
    private TerrainData _terrainData;

    private float[,] _originalHeightmap;

    private float _depth = 0.0f;

    public void Init()
    {
        _terrainData = terrain.terrainData;
        _originalHeightmap = _terrainData.GetHeights(0, 0, _terrainData.heightmapResolution, _terrainData.heightmapResolution);
    }

    public void Reset()
    {
        _terrainData.SetHeights(0, 0, _originalHeightmap);
    }

    public void SetHeight(float x, float z, float height)
    {
        Vector3 pos = transform.InverseTransformPoint(new Vector3(x, height, z));
        pos.x *= _terrainData.heightmapResolution/_terrainData.size.x;
        pos.z *= _terrainData.heightmapResolution/_terrainData.size.z;
        float originalHeight = GetHeight(x, z);
        float[,] heights = _terrainData.GetHeights(0, 0, _terrainData.heightmapResolution, _terrainData.heightmapResolution);
        heights[(int)pos.z, (int)pos.x] = (height )/_terrainData.size.y;
        heights[(int)pos.z, (int)pos.x + 1]= (height ) / _terrainData.size.y;
        heights[(int)pos.z + 1, (int)pos.x] = (height ) / _terrainData.size.y;
        heights[(int)pos.z + 1, (int)pos.x + 1] = (height ) / _terrainData.size.y;
        _terrainData.SetHeights(0, 0, heights);
    }

    public float GetHeight(float x, float z)
    {
        if (!_terrainData) return 0.0f;
        Vector3 pos = transform.InverseTransformPoint(new Vector3(x, 0, z));
        return _terrainData.GetInterpolatedHeight(pos.x/_terrainData.size.x, z/_terrainData.size.z);
    }

    public void SetDepth(float depth)
    {
        float[,] heights = _terrainData.GetHeights(0, 0, _terrainData.heightmapResolution, _terrainData.heightmapResolution);
        for(int z = 0; z < _terrainData.heightmapResolution; z++)
        {
            for(int x = 0; x < _terrainData.heightmapResolution; x++)
            {
                heights[z, x] += (depth - _depth) / _terrainData.size.y;
            }
        }
        _terrainData.SetHeights(0, 0, heights);
        transform.position += new Vector3(0, -depth + _depth, 0);
        _depth = depth;
    }
}
