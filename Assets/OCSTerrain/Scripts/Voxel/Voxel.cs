using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VoxelSystem
{
    public class Voxel
    {
        private VoxelMapData _mapData;
        private VoxelData _voxelData;

        private float _resolution { get => _mapData.resolution; }
        public VoxelData voxelData { get => _voxelData; }
        public float height { get => _voxelData.height; set => _voxelData.height = value; }
        public float density { get => _voxelData.density; set => _voxelData.density = value; }

        public Voxel(VoxelMapData mapData, Vector3Int index)
        {
            _mapData = mapData;
            _voxelData.index = index;
        }

        public void Awake()
        {
        
        }

        public void Start()
        {
            _voxelData.position = _voxelData.index;
            _voxelData.position *= _resolution;
            _voxelData.area = _resolution * _resolution;
            _voxelData.volume = 0.0f;
        }

        public void Set(float height, float density)
        {
            _voxelData.height= height;
            _voxelData.density = density;
        }
    }
}
