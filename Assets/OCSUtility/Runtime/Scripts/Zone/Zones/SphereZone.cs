using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OCS.Utility
{
    public class SphereZone : Zone
    {
        [SerializeField]
        private float _radius;
        private float _radius2;

        protected override void Start()
        {
            _radius2 = _radius * _radius;
        }

        public override bool IsPointInZone(Vector3 point)
        {
            if ((point - base._transform.position).sqrMagnitude < _radius2) return true;
            return false;
        }

        public override void Visualize()
        {
            Gizmos.DrawWireSphere(base._transform.position, _radius);
        }
    }
}
