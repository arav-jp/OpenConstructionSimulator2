using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OCS.Terrain
{
    public class Excavator : MonoBehaviour
    {
        #region Inspector
        [SerializeField]
        private VoxelTerrain _voxelTerrain;

        [SerializeField]
        private ActiveZone _activeZone;

        [SerializeField]
        private Transform _originOffsetDirection;

        [SerializeField]
        private float _originOffset;

        [SerializeField]
        private float _height_min;
        [SerializeField]
        private float _height_max;

        [SerializeField]
        private float _updateDistance;

        [SerializeField]
        private LayerMask _terrainLayer;
        #endregion

        #region Parameters
        private Transform _transform;
        private TerrainManager _tm;
        private float _raycastRange;
        private float _updateDistance_sqr;
        private Vector3 _positioin_last;
        #endregion

        #region Properties
        public ActiveZone activeZone { get => _activeZone; }
        #endregion

        private void Awake()
        {
            _transform = transform;
        }

        private void Start()
        {
            _raycastRange = _height_max - _height_min;

            _updateDistance_sqr = _updateDistance * _updateDistance;
        }

        private void Update()
        {
            if (!_tm) return;
            Vector3 position = _transform.position;
            position.y = 0;
            if ((position - _positioin_last).sqrMagnitude > _updateDistance_sqr)
            {
                ActivateVoxelTerrain();
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag != "Terrain") return;
            _tm = other.GetComponent<TerrainManager>();
            ActivateVoxelTerrain();
        }

        private void ActivateVoxelTerrain()
        {
            _voxelTerrain.Inactivate();

            Vector3 origin = new Vector3(_transform.position.x, _height_max, _transform.position.z) - _originOffsetDirection.forward * _originOffset;
            Ray ray = new Ray(origin, Vector3.down);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, _raycastRange, _terrainLayer))
            {
                if (_tm) _voxelTerrain.SetTargetTerrain(_tm);
                _voxelTerrain.Activate(hit.point);
            }

            _positioin_last = _transform.position;
            _positioin_last.y = 0;
        }
    }
}
