using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VoxelSystem;

public class VoxelMapVisualizer : Visualizer<VoxelMap>
{
    protected override void Visualize()
    {
        if (!_target.activated) return;
        VoxelMapData mapData = _target.mapData;

        for(int x = 0; x < mapData.size.x; x++)
        {
            for(int z = 0; z < mapData.size.z; z++)
            {
                /*
                for(int y = 0; y < mapData.size.y; y++)
                {
                    VoxelData voxelData = _target.GetVoxel(x, y, z).voxelData;
                    if (voxelData.volume <= 0.0f) break;
                    Vector3 size = new Vector3(mapData.resolution, voxelData.height, mapData.resolution);
                    Gizmos.DrawWireCube(mapData.origin + voxelData.position + Vector3.up*size.y*0.5f, size);
                }
                */
                VoxelData pillarData = _target.GetPillar(x, z).pillarData;
                Vector3 size = new Vector3(mapData.resolution, pillarData.height, mapData.resolution);
                Gizmos.DrawWireCube(mapData.origin + pillarData.position + Vector3.up * pillarData.height * 0.5f, size);
            }
        }
    }
}
