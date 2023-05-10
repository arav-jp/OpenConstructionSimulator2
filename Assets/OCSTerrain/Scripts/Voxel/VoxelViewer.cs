using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VoxelSystem
{
    public class VoxelViewer : MonoBehaviour
    {
        [SerializeField]
        private VoxelMap _voxelMap;
        [SerializeField]
        private Vector3Int _index;

        [SerializeField]
        private VoxelData _voxelData;

        private void Update()
        {
            Voxel v = _voxelMap.GetVoxel(_index);
            if (v != null)
                _voxelData = v.voxelData;
        }

        private void OnDrawGizmosSelected()
        {
            if (!Application.isPlaying) return;

        }
    }
}