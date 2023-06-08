using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MultiZone : Zone
{
    [SerializeField]
    private Zone[] _zones;

    public override bool IsPointInZone(Vector3 point)
    {
        foreach(Zone zone in _zones)
        {
            if (zone == this) continue;
            if (zone.IsPointInZone(point)) return true;
        }
        return false;
    }

    public override void Visualize()
    {
        foreach (Zone zone in _zones)
        {
            if (zone == this) continue;
            zone.Visualize();
        }
    }

    public List<Zone> LoadChildrenAsZones()
    {
        List<Zone> zones = new List<Zone>();
        List<Zone> containedZones = new List<Zone>();

        Zone[] zones_array = _transform.GetComponentsInChildren<Zone>();

        foreach(Zone zone in zones_array)
        {
            if (zone != this && zone as MultiZone)
            {
                zones.Add(zone);
                containedZones.AddRange((zone as MultiZone).GetZones());
            }
        }
        foreach (Zone zone in zones_array)
        {
            if (zone != this && !(zone as MultiZone) && !containedZones.Contains(zone))
            {
                zones.Add(zone);
            }
        }
        _zones = zones.ToArray();
        return zones;
    }

    public List<Zone> GetZones()
    {
        return new List<Zone>(_zones);
    }
}

[CustomEditor(typeof(MultiZone))]
public class MultiZoneEditor : Editor
{
    MultiZone _target;
    public void OnEnable()
    {
        _target = target as MultiZone;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if (GUILayout.Button("Load Children as Zones"))
        {
            _target.LoadChildrenAsZones();
        }
    }

}
