using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VoxelSystem
{
    public class DepositionTest : MonoBehaviour
    {
        [SerializeField]
        private VoxelTerrain _terrain;
        [SerializeField]
        private SoilManager _soilManager;

        [SerializeField]
        private Transform _spawnPosition;
        [SerializeField]
        private float _volume = 0.0f;
        [SerializeField]
        private float _density = 2700.0f;

        [SerializeField]
        private float _intervalTime = 1.0f;

        private float _time_old;

        void Start()
        {
        }

        private void OnEnable()
        {
            _terrain.Activate(transform.position);
        }

        void Update()
        {
            float time = Time.time;
            if (time - _time_old < _intervalTime) return;
            _time_old = time;

            _soilManager.Spawn(_spawnPosition.position, _volume, _density);
        }
    }
}
