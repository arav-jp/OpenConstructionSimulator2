using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeZone : Zone
{
    [SerializeField]
    private Vector3 _size;

    private Vector3 _size_2;
    private Vector3[] _vertexPoints;

    protected override void Awake()
    {
        base.Awake();
        _size_2 = new Vector3(Mathf.Abs(_size.x), Mathf.Abs(_size.y), Mathf.Abs(_size.z)) * 0.5f;
        _vertexPoints = new Vector3[8];
    }

    protected override void Start()
    {
        _vertexPoints[0] = new Vector3(-_size_2.x, -_size_2.y, -_size_2.z);
        _vertexPoints[1] = new Vector3(+_size_2.x, -_size_2.y, -_size_2.z);
        _vertexPoints[2] = new Vector3(+_size_2.x, -_size_2.y, +_size_2.z);
        _vertexPoints[3] = new Vector3(-_size_2.x, -_size_2.y, +_size_2.z);
        _vertexPoints[4] = new Vector3(-_size_2.x, +_size_2.y, -_size_2.z);
        _vertexPoints[5] = new Vector3(+_size_2.x, +_size_2.y, -_size_2.z);
        _vertexPoints[6] = new Vector3(+_size_2.x, +_size_2.y, +_size_2.z);
        _vertexPoints[7] = new Vector3(-_size_2.x, +_size_2.y, +_size_2.z);

        base._volume = _size.x * _size.y * _size.z;
    }

    public override bool IsPointInZone(Vector3 point)
    {
        Vector3 point_local = base._transform.InverseTransformPoint(point);
        if (Mathf.Abs(point_local.x) > _size_2.x || Mathf.Abs(point_local.y) > _size_2.y || Mathf.Abs(point_local.z) > _size_2.z) return false;
        return true;
    }

    public override void Visualize()
    {
        Vector3[] vertexPoints_world = new Vector3[8];
        for (int i = 0; i < 8; i++)
        {
            vertexPoints_world[i] = base._transform.TransformPoint(_vertexPoints[i]);
        }

        int j = 3;
        for (int i = 0; i < 4; i++)
        {
            Gizmos.DrawLine(vertexPoints_world[i], vertexPoints_world[j]);
            Gizmos.DrawLine(vertexPoints_world[i + 4], vertexPoints_world[j + 4]);
            Gizmos.DrawLine(vertexPoints_world[i], vertexPoints_world[i + 4]);
            j = i;
        }
    }

    private bool BitRead(int value, int bitNum)
    {
        return (value & (1 << bitNum))!=0;
    }
}
