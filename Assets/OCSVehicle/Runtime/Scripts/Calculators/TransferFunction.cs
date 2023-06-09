using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OCS.Vehicle
{
    public class TransferFunction : MonoBehaviour
    {
        [SerializeField]
        private float _hz = 10.0f;

        protected float _input;
        protected float _output;

        private float _hz_inv;
        private float _time_last;

        public float input { get => _input; set => SetInput(value); }
        public float output { get => _output; }
        public float hz_inv { get => _hz_inv; }

        protected virtual void Start()
        {
            _hz_inv = 1.0f / _hz;
            _time_last = Time.time;
        }

        protected virtual void SetInput(float value)
        {
            _input = value;
        }

        private void Update()
        {
            float time_now = Time.time;
            if (time_now - _time_last < _hz_inv) return;
            Calc();
            _time_last = time_now;
        }

        protected virtual void Calc()
        {
            
        }
    }
}
