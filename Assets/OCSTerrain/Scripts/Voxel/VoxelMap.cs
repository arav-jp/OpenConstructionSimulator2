using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VoxelSystem
{
    [System.Serializable]
    public struct VoxelMapData
    {
        public float resolution;    // [m/cell]
        public Vector3Int size;     // [cell]
        [ReadOnly]
        public Vector3 origin;      // [m]
        [ReadOnly]
        public Vector3Int originIndex;
    }

    public class VoxelMap : MonoBehaviour
    {
        #region Inspector
        [SerializeField]
        private VoxelMapData _mapData;
        #endregion

        #region Parameter
        private VoxelPillar[,] _pillars;
        private bool _activated;
        #endregion
        
        #region Properties
        private float _resolution { get => _mapData.resolution; }
        private Vector3Int _size { get => _mapData.size; }
        private Vector3 _origin { get => _mapData.origin; }
        private Vector3Int _originIndex { get => _mapData.originIndex; }

        public VoxelMapData mapData { get => _mapData; }
        public bool activated { get => _activated; }
        #endregion

        public VoxelMap(VoxelMapData mapData)
        {
            _mapData = mapData;
        }

        private void Awake()
        {
            _pillars = new VoxelPillar[_size.x, _size.z];
            for(int x = 0; x < _size.x; x++)
            {
                for(int z = 0; z < _size.z; z++)
                {
                    Vector3Int index = new Vector3Int(x, 0, z);
                    _pillars[x, z] = new VoxelPillar(_mapData, index);
                    _pillars[x, z].Awake();
                }
            }
        }

        private void Start()
        {
            for (int x = 0; x < _size.x; x++)
            {
                for (int z = 0; z < _size.z; z++)
                {
                    _pillars[x, z].Start();
                }
            }
        }

        public void Activate()
        {
            _activated = true;
        }

        public void Inactivate()
        {
            _activated = false;
        }

        public void SetOrigin(Vector3 origin)
        {
            _mapData.origin = origin;
            _mapData.originIndex = Vector3Int.CeilToInt(_mapData.origin / _resolution);
            _mapData.origin = (Vector3)(_originIndex) * _resolution;
        }

        public VoxelPillar GetPillar(int x, int z)
        {
            if (x < 0 || _size.x <= x || z < 0 || _size.z <= z) return null;
            return _pillars[x, z];
        }

        public Voxel GetVoxel(Vector3Int index)
        {
            if (index.x < 0 || _size.x <= index.x || index.z < 0 || _size.z <= index.z) return null;
            return _pillars[index.x, index.z].GetVoxel(index.y);    
        }

        public Voxel GetVoxel(int x, int y, int z)
        {
            if (x < 0 || _size.x <= x || z < 0 || _size.z <= z) return null;
            return _pillars[x, z].GetVoxel(y);
        }
    }
}
