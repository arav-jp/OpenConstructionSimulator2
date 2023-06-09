using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OCS.Utility
{
#if UNITY_EDITOR
    [RequireComponent(typeof(Zone))]
    [ExecuteAlways]
    public class ZoneVisualizer : Visualizer<Zone>
    {
        protected override void Visualize()
        {
            if (Application.isPlaying || Time.time > 1.0f)
                _target.Visualize();
        }
    }
#endif
}