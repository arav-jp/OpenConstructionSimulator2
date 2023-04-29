using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VoxelSystem
{
    public class VoxelPillar
    {
        private VoxelMapData _mapData;
        private Voxel[] _voxels;

        private VoxelData _pillarData;

        private float _resolution { get => _mapData.resolution; }
        private int _size { get => _mapData.size.y; }
        private Vector3Int _index { get => _pillarData.index; }
        public VoxelData pillarData { get => _pillarData; }

        public VoxelPillar(VoxelMapData mapData, Vector3Int index)
        {
            _mapData = mapData;
            _pillarData.index = index;
        }

        public void Awake()
        {
            _voxels = new Voxel[_size];
            for(int y = 0; y < _size; y++)
            {
                _voxels[y] = new Voxel(_mapData, _index + Vector3Int.up * y);
                _voxels[y].Awake();
            }
        }

        public void Start()
        {
            _pillarData.position = _pillarData.index;
            _pillarData.position *= _resolution;
            _pillarData.area = _resolution * _resolution;
            _pillarData.height = _resolution * _size;

            for (int y = 0; y < _size; y++)
            {
                _voxels[y].Start();
            }
        }

        public void SetHeight(float height, float density)
        {
            _pillarData.volume = _resolution * _resolution * height;
            _pillarData.density = density;

            for (int y = 0; y < _size; y++)
            {
                _voxels[y].Set(Mathf.Clamp(height, 0, _resolution), density);
                height -= _resolution;
            }
        }

        public Voxel GetVoxel(int index)
        {
            if (index < 0 || index >= _size) return null;
            return _voxels[index];
        }
    }
}
