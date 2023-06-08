using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OCS.Utility;

namespace OCS.Terrain
{
    public class SoilManager : MonoBehaviour
    {
        #region Inspector
        [SerializeField]
        private Zone _particleZone;
        [SerializeField]
        private GameObject _soilObj;
        [SerializeField]
        private int _soilNum;
        #endregion

        #region Parameters
        private Soil[] _soils;
        private Transform _transform;

        private bool _inited = false;
        VoxelTerrain _vt;
        #endregion

        #region Properties
        #endregion

        private void Awake()
        {
            _transform = transform;
            _soils = new Soil[_soilNum];

            _inited = false;
        }

        private void Start()
        {
            for (int i = 0; i < _soilNum; i++)
            {
                var soil_obj = Instantiate(_soilObj);
                soil_obj.transform.parent = _transform;
                _soils[i] = soil_obj.GetComponent<Soil>();
                _soils[i].Init(this, _particleZone);
                _soils[i].Inactivate();
                if (_vt) _soils[i].SetVoxelTerrain(_vt);
            }

            _inited = true;
        }

        public Soil Spawn(Vector3 position, float volume, float density)
        {
            foreach (Soil soil in _soils)
            {
                if (soil.IsActivated()) continue;
                if (soil.Activate(position, volume, density)) return soil;
                break;
            }
            return null;
        }


        public void SetVoxelTerrain(VoxelTerrain voxelTerrain)
        {
            _vt = voxelTerrain;
            if (!_inited) return;
            foreach (Soil soil in _soils)
            {
                soil.SetVoxelTerrain(voxelTerrain);
            }
        }

        public void Inactivate()
        {
            foreach (Soil soil in _soils)
            {
                if (!_particleZone.IsPointInZone(soil.transform.position))
                    soil.Inactivate();
            }
        }
    }
}