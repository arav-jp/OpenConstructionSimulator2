using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VoxelSystem
{
    public class VoxelTerrain : MonoBehaviour
    {
        [SerializeField]
        private TerrainManager _terrainManager;
        [SerializeField]
        private Excavator _excavator;
        [SerializeField]
        private VoxelMap _voxelMap;

        [SerializeField]
        private LayerMask _terrainLayer;

        [SerializeField]
        private Vector3 _offset;

        [SerializeField]
        private float _hz;

        private float _hz_inv;
        private float _time_old;
        private bool _activated = false;

        private void Start()
        {
            _hz_inv = 1.0f / _hz;
        }

        private void Update()
        {
            if (!_activated) return;
            float time_now = Time.time;
            if (time_now - _time_old < _hz_inv) return;
            _time_old = time_now;
            Cutting();
            Voxel2Terrain();
        }

        private void Cutting()
        {
            VoxelMapData mapData = _voxelMap.mapData;
            for (int x = 0; x < mapData.size.x; x++)
                for (int z = 0; z < mapData.size.z; z++)
                {
                    float height = _voxelMap.GetPillar(x, z).pillarHeight + mapData.origin.y;
                    Vector3 pos = _voxelMap.IndexToPosition(x, z) + Vector3.up * height;
                    if (!_excavator.activeZone.IsPointInZone(pos)) continue;
                    float height_cutting = _excavator.activeZone.GetSurfaceHeight(pos);
                    if (height_cutting > pos.y) continue;
                    int index_start = (int)(height / mapData.resolution) + 1;
                    int index_end = (int)(height_cutting / mapData.resolution);
                    for (int y = index_start; y > index_end; y--)
                    {
                        if (y < 0 || y >= mapData.size.y) continue;
                        /*
                        if (_voxelMap..volume_max == 0.0f) continue;
                        var obj = Instantiate(_soilObj, _voxels.GetPosition(x, z) + Vector3.up * y * _voxels.resolution, Quaternion.identity);
                        obj.GetComponent<Soil>().Init(_bucket, _voxels, _voxels.pillars[x, z].voxels[y].volume_max, _voxels.pillars[x, z].voxels[y].density);
                        _voxels.pillars[x, z].voxels[y].Digged();
                        */
                    }
                    _voxelMap.GetPillar(x, z).SetHeight(height_cutting - mapData.origin.y);
                }
        }

        private void Voxel2Terrain()
        {
            VoxelMapData mapData = _voxelMap.mapData;
            Vector3 start = mapData.origin;
            Vector3 end = start + (Vector3)(mapData.size) * mapData.resolution;

            int index_start_x, index_end_x, index_start_z, index_end_z;
            (index_start_x, index_start_z) = _terrainManager.Position2Index(start);
            (index_end_x, index_end_z) = _terrainManager.Position2Index(end);
            index_start_x++;
            index_start_z++;
            index_end_x--;
            index_end_z--;

            index_start_x = Mathf.Clamp(index_start_x, 0, _terrainManager.heightmapResolution);
            index_start_z = Mathf.Clamp(index_start_z, 0, _terrainManager.heightmapResolution);
            index_end_x = Mathf.Clamp(index_end_x, 0, _terrainManager.heightmapResolution);
            index_end_z = Mathf.Clamp(index_end_z, 0, _terrainManager.heightmapResolution);

            for (int x = index_start_x; x <= index_end_x; x++)
            {
                for (int z = index_start_z; z <= index_end_z; z++)
                {
                    Vector3 pos = _terrainManager.Index2Position(x, z);
                    _terrainManager.SetHeight(x, z, _voxelMap.GetHeightVerbose(pos));
                }
            }
        }

        private void Terrain2Voxel()
        {
            VoxelMapData mapData = _voxelMap.mapData;

            for (int x = 0; x < mapData.size.x; x++)
            {
                for (int z = 0; z < mapData.size.z; z++)
                {
                    VoxelPillar pillar = _voxelMap.GetPillar(x, z);
                    Vector3 rayOrigin = mapData.origin + pillar.pillarData.position;
                    Ray ray = new Ray(rayOrigin + Vector3.up * _terrainManager.terrainSize.y, Vector3.down);
                    RaycastHit hit;

                    float height = 0.0f;
                    if (Physics.Raycast(ray, out hit, _terrainManager.terrainSize.y, _terrainLayer))
                    {
                        height = hit.point.y - mapData.origin.y;
                    }
                    pillar.SetHeight(height, 2700.0f);
                }
            }
        }

        public void Activate(Vector3 origin)
        {
            origin += _offset;
            _voxelMap.SetOrigin(origin);

            Terrain2Voxel();

            _voxelMap.Activate();
            _activated = true;
        }

        public void Inactivate()
        {
            if (!_activated) return;
            Voxel2Terrain();
            _voxelMap.Inactivate();
            _activated = false;
        }
    }
}
