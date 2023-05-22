using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VoxelSystem;

public class VoxelMapVisualizer : Visualizer<VoxelMap>
{
    enum VoxelMapVisualizeMode
    {
        VOXEL,
        PILLAR
    }

    [SerializeField]
    private VoxelMapVisualizeMode _mode;

    [SerializeField]
    private Gradient _densityGradient;

    protected override void Visualize()
    {
        if (!_target.activated) return;
        VoxelMapData mapData = _target.mapData;

        for(int x = 0; x < mapData.size.x; x++)
        {
            for(int z = 0; z < mapData.size.z; z++)
            {
                switch (_mode)
                {
                    case VoxelMapVisualizeMode.VOXEL:
                        for (int y = 0; y < mapData.size.y; y++)
                        {
                            VoxelData voxelData = _target.GetVoxel(x, y, z).voxelData;
                            if (voxelData.volume <= 0.0f) break;

                            Gizmos.color = _densityGradient.Evaluate(Mathf.InverseLerp(mapData.minDensity, mapData.maxDensity, voxelData.density));

                            Vector3 size_voxel = new Vector3(mapData.resolution, voxelData.height, mapData.resolution);
                            Gizmos.DrawWireCube(mapData.origin + voxelData.position + Vector3.up * size_voxel.y * 0.5f, size_voxel);
                        }
                        break;
                    case VoxelMapVisualizeMode.PILLAR:
                        VoxelData pillarData = _target.GetPillar(x, z).pillarData;
                        Vector3 size_pillar = new Vector3(mapData.resolution, pillarData.height, mapData.resolution);
                        Gizmos.DrawWireCube(mapData.origin + pillarData.position + Vector3.up * pillarData.height * 0.5f, size_pillar);
                        break;
                }
            }
        }
    }
}
