using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OCS.Utility;

namespace OCS.Terrain
{
    [System.Serializable]
    public struct VoxelData
    {
        [ReadOnly]
        public Vector3Int index;

        [ReadOnly]
        public Vector3 position;

        [SerializeField, ReadOnly]
        private float _volume;

        [SerializeField, ReadOnly]
        private float _height;

        [SerializeField, ReadOnly]
        private float _mass;

        [SerializeField, ReadOnly]
        private float _density;

        [HideInInspector]
        public float area;

        public float volume { get => _volume; set => SetVolume(value); }
        public float height { get => _height; set => SetHeight(value); }
        public float mass { get => _mass; set => SetMass(value); }
        public float density { get => _density; set => SetDensity(value); }

        private void SetVolume(float value)
        {
            _volume = value;
            _height = _volume / area;
        }

        private void SetHeight(float value)
        {
            _height = value;
            _volume = _height * area;
        }

        private void SetMass(float value)
        {
            _mass = value;
            _density = _mass / _volume;
        }

        private void SetDensity(float value)
        {
            _density = value;
            _mass = _density * _volume;
        }
    }
}
