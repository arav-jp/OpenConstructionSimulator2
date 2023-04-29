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
        private VoxelMap _voxelMap;

        [SerializeField]
        private LayerMask _terrainLayer;

        [SerializeField]
        private Vector3 _offset;

        public void Activate(Vector3 origin)
        {
            origin += _offset;
            _voxelMap.SetOrigin(origin);

            
            VoxelMapData mapData = _voxelMap.mapData;
            
            
            for(int x = 0; x < mapData.size.x; x++)
            {
                for (int z = 0; z < mapData.size.z; z++)
                {
                    VoxelPillar pillar = _voxelMap.GetPillar(x, z);
                    Vector3 rayOrigin = mapData.origin + pillar.pillarData.position;
                    Ray ray = new Ray(rayOrigin + Vector3.up * _terrainManager.terrainSize.y , Vector3.down);
                    RaycastHit hit;

                    float height = 0.0f;
                    if(Physics.Raycast(ray, out hit, _terrainManager.terrainSize.y, _terrainLayer))
                    {
                        height = hit.point.y - mapData.origin.y;
                    }
                    pillar.SetHeight(height, 2700.0f);
                }
            }

            _voxelMap.Activate();
        }

        public void Inactivate()
        {
            _voxelMap.Inactivate();
        }
    }
}
