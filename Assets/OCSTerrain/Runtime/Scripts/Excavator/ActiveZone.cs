using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OCS.Utility;

namespace OCS.Terrain
{
    public class ActiveZone : MonoBehaviour
    {
        [SerializeField]
        private Transform _plane;
        [SerializeField]
        private PlaneZone _planeZone;
        [SerializeField]
        private Zone _collisionZone;
        [SerializeField]
        private Transform _topEdge;
        [SerializeField]
        private Transform _cuttingEdge;

        [SerializeField, Range(0.0f, 1.0f)]
        private float _deadLoad = 0.0f;

        private Transform _transform;

        private void Awake()
        {
            _transform = this.transform;
        }

        private void Update()
        {
            if (!Application.isPlaying) return;
            Vector3 forward = Quaternion.AngleAxis(-90.0f, _transform.right) * Vector3.Lerp(_transform.forward, _cuttingEdge.position - _topEdge.position, _deadLoad);
            _plane.rotation = Quaternion.LookRotation(forward, Vector3.Cross(forward, _transform.right).normalized);
        }

        public bool IsPointInZone(Vector3 point)
        {
            if (_planeZone.IsPointInZone(point) || _collisionZone.IsPointInZone(point))
            {
                return true;
            }
            return false;
        }

        public float GetSurfaceHeight(Vector3 point)
        {
            point.y = 0.0f;
            float distanceToSurface = Vector3.Dot(_plane.position - point, _plane.up) / Vector3.Dot(Vector3.up, _plane.up);
            return distanceToSurface;
        }
    }
}
