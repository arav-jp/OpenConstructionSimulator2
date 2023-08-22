using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OCS.VehicleIO
{
    using Vehicle = Vehicle.Vehicle;

    [System.Serializable]
    public struct JoyStickInput
    {
        [SerializeField, Range(0.01f, 1.0f)]
        private float _resolution;
        private float _x;
        private float _y;

        public float x
        {
            get => _x;
            set
            {
                _x = (int)(Mathf.Clamp(value, -1.0f, 1.0f) / _resolution) * _resolution;
            }
        }

        public float y
        {
            get => _y;
            set
            {
                _y = (int)(Mathf.Clamp(value, -1.0f, 1.0f) / _resolution) * _resolution;
            }
        }

        public Vector2 vector { get => new Vector2(_x, _y); set => SetVector(value); }

        private void SetVector(Vector2 vec)
        {
            x = vec.x;
            y = vec.y;
        }
    }

    public class VehicleController<T> : MonoBehaviour where T : Vehicle
    {
        [SerializeField]
        protected T _controlTarget;

        public T controlTarget { get => _controlTarget; set => _controlTarget = value; }
    }
}
