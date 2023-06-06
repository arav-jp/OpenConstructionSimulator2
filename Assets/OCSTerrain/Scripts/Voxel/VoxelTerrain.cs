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
        private SoilManager _soilManager;

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

        [SerializeField]
        private bool _cutting = true;
        [SerializeField]
        private bool _voxel2terrain = true;

        private float _hz_inv;
        private float _time_old;
        private bool _activated = false;

        public VoxelMapData mapData { get => _voxelMap.mapData; }

        private void Start()
        {
            _hz_inv = 1.0f / _hz;
            _soilManager.SetVoxelTerrain(this);
        }

        private void Update()
        {
            if (!_activated) return;
            float time_now = Time.time;
            if (time_now - _time_old < _hz_inv) return;
            _time_old = time_now;
            if(_cutting) Cutting();
            if(_voxel2terrain) Voxel2Terrain();
        }

        private void Cutting()
        {
            for (int x = 0; x < mapData.size.x; x++)
            {
                for (int z = 0; z < mapData.size.z; z++)
                {
                    float height = _voxelMap.GetPillar(x, z).pillarHeight + mapData.origin.y;
                    Vector3 surface = _voxelMap.IndexToPosition(x, z) + Vector3.up * height;
                    if (!_excavator.activeZone.IsPointInZone(surface)) continue;
                    float height_cutting = _excavator.activeZone.GetSurfaceHeight(surface);
                    if (height_cutting > surface.y) continue;
                    int index_start = (int)((height - mapData.origin.y) / mapData.resolution);
                    int index_end = (int)((height_cutting - mapData.origin.y) / mapData.resolution);

                    for (int y = index_start; y > index_end; y--)
                    {
                        if (y < 0 || y >= mapData.size.y) continue;
                        Voxel voxel = _voxelMap.GetVoxel(x, y, z);
                        Vector3 voxelPosition = voxel.voxelData.position + mapData.origin;
                        if (voxelPosition.y < height_cutting) continue;
                        _soilManager.Spawn(voxelPosition, mapData.resolution * mapData.resolution * mapData.resolution, voxel.voxelData.density);
                    }

                    _voxelMap.GetPillar(x, z).SetHeight(height_cutting - mapData.origin.y);
                }
            }
        }

        public void Depositting(Vector3 pos, float volume, float density)
        {
            Vector3Int index = _voxelMap.PositionToIndex(pos.x, pos.z);
            if (index.x < 0 || index.x >= mapData.size.x || index.z < 0 || index.z >= mapData.size.z) return;
            _voxelMap.GetPillar(index.x, index.z).Depositting(volume, density);
        }

        private void Voxel2Terrain()
        {
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
            _voxelMap.Inactivate();
            _soilManager.Inactivate();
            Voxel2Terrain();
            _activated = false;
        }

        public void SetTargetTerrain(TerrainManager terrainManager)
        {
            _terrainManager = terrainManager;
        }
    }
}
