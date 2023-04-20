using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiZone : Zone
{
    [SerializeField]
    private Zone[] _zones;

    public override bool IsPointInZone(Vector3 point)
    {
        foreach(Zone zone in _zones)
        {
            if (zone.IsPointInZone(point)) return true;
        }
        return false;
    }

    public override void Visualize()
    {
        foreach (Zone zone in _zones)
        {
            zone.Visualize();
        }
    }
}
