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
        Vector3 dir_projected = base._transform.forward;
        dir_projected -= Vector3.up * dir_projected.y;
        Quaternion rot_cache = base._transform.rotation;
        base._transform.rotation = Quaternion.LookRotation(dir_projected, Vector3.up);

        point_local = base._transform.InverseTransformPoint(point);

        bool flag = true;
        if (Mathf.Abs(point.x) > _width_2 || point.z > length || point.z < 0) flag =  false;
        base._transform.rotation = rot_cache;
        return flag;
    }

    /*
    public bool IsPointInZone(Vector3 pos_world)
    {
        Vector3 pos_local = _transform.InverseTransformPoint(pos_world);
        if (pos_local.x > _width * 0.5f || pos_local.x < -_width * 0.5f) return false;
        bool isInside = false;
        int j = _vertices.Length - 1;
        for (int i = 0; i < _vertices.Length; i++)
        {
            // vector calc
            if ((_vertices[i].y > pos_local.y) != (_vertices[j].y > pos_local.y) &&
                (pos_local.z < (_vertices[j].z - _vertices[i].z) * (pos_local.y - _vertices[i].y) / (_vertices[j].y - _vertices[i].y) + _vertices[i].z))
                isInside = !isInside;

            j = i;
        }
        return isInside;
    }
    */

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
