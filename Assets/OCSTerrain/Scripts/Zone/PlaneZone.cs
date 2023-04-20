using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneZone : Zone
{
    public float width;
    public float length;

    private float _width_2;

    protected override void Awake()
    {
        base.Awake();
    }

    protected override void Start()
    {
        _width_2 = width * 0.5f;
    }

    private void Update()
    {
        IsPointInZone(Vector3.zero);
    }

    public override bool IsPointInZone(Vector3 point)
    {
        Vector3 point_local = base._transform.InverseTransformPoint(point);
        if (point_local.y < 0.0f) return false;
        Vector3 origin = base._transform.position;
        Vector3 width_2_vec = base._transform.right * _width_2;
        Vector3 length_vec = base._transform.forward * length;
        Vector3[] _vertexPoints = new Vector3[4];
        _vertexPoints[0] = origin - width_2_vec;
        _vertexPoints[1] = origin + width_2_vec;
        _vertexPoints[2] = _vertexPoints[1] + length_vec;
        _vertexPoints[3] = _vertexPoints[0] + length_vec;

        bool flag = false;
        int j = _vertexPoints.Length - 1;
        for (int i = 0; i < _vertexPoints.Length; i++)
        {
            if ((_vertexPoints[i].x > point.x) != (_vertexPoints[j].x > point.x) &&
                (point.z < (_vertexPoints[j].z - _vertexPoints[i].z) * (point.x - _vertexPoints[i].x) / (_vertexPoints[j].x - _vertexPoints[i].x) + _vertexPoints[i].z))
                flag = !flag;
            j = i;
        }

        return flag;
    }

    public override void Visualize()
    {
        Vector3 origin = base._transform.position;
        Vector3 width_2_vec = base._transform.right * _width_2;
        Vector3 length_vec = base._transform.forward * length;
        Vector3[] _vertexPoints = new Vector3[4];
        _vertexPoints[0] = origin - width_2_vec;
        _vertexPoints[1] = origin + width_2_vec;
        _vertexPoints[2] = _vertexPoints[1] + length_vec;
        _vertexPoints[3] = _vertexPoints[0] + length_vec;

        int j = 3;
        for (int i = 0; i < 4; i++)
        {
            Gizmos.DrawLine(_vertexPoints[i], _vertexPoints[j]);
            j = i;
        }
    }
}
