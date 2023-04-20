using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillarZone : Zone
{
    [SerializeField]
    private float _height;

    [SerializeField]
    private Transform[] _vertices;

    private Vector3[] _vertexPoints;

    private float _height_2;

    protected override void Awake()
    {
        base.Awake();
        _vertexPoints = new Vector3[_vertices.Length];
    }

    protected override void Start()
    {
        _height_2 = _height * 0.5f;
        for (int i = 0; i < _vertices.Length; i++)
        {
            _vertices[i].parent = base._transform;
            _vertexPoints[i] = _vertices[i].localPosition;
        }
    }

    public override bool IsPointInZone(Vector3 point)
    {
        Vector3 point_local = base._transform.InverseTransformPoint(point);
        if (Mathf.Abs(point_local.y) > _height_2) return false;

        bool flag = false;
        int j = _vertexPoints.Length - 1;
        for (int i = 0; i < _vertexPoints.Length; i++)
        {
            if ((_vertexPoints[i].x > point_local.x) != (_vertexPoints[j].x > point_local.x) &&
                (point_local.z < (_vertexPoints[j].z - _vertexPoints[i].z) * (point_local.x - _vertexPoints[i].x) / (_vertexPoints[j].x - _vertexPoints[i].x) + _vertexPoints[i].z))
                flag = !flag;
            j = i;
        }

        return flag;
    }

    public override void Visualize()
    {
        Vector3[] vertexPoints_world = new Vector3[_vertexPoints.Length];
        for (int i = 0; i < _vertexPoints.Length; i++)
        {
            vertexPoints_world[i] = base._transform.TransformPoint(_vertexPoints[i]);
        }

        Vector3 height_2_vec = base._transform.up*_height_2;
        int j = vertexPoints_world.Length - 1;
        for (int i = 0; i < vertexPoints_world.Length; i++)
        {
            Gizmos.DrawLine(vertexPoints_world[i] - height_2_vec, vertexPoints_world[i] + height_2_vec);
            Gizmos.DrawLine(vertexPoints_world[i] - height_2_vec, vertexPoints_world[j] - height_2_vec);
            Gizmos.DrawLine(vertexPoints_world[i] + height_2_vec, vertexPoints_world[j] + height_2_vec);
            j = i;
        }
    }
}
