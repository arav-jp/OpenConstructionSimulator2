using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OCS.VehicleIO
{
    using Vehicle = Vehicle.Vehicle;

    [System.Serializable]
    public struct JoyStickInput
    {
        [SerializeField]
        private float _x;
        [SerializeField]
        private float _y;

        public float x { get => _x; set => _x = Mathf.Clamp(value, -1.0f, 1.0f); }
        public float y { get => _y; set => _y = Mathf.Clamp(value, -1.0f, 1.0f); }

        public Vector2 vector { get => new Vector2(_x, _y); set => SetVector(value); }

        private void SetVector(Vector2 vec)
        {
            _x = vec.x;
            _y = vec.y;
        }
    }

    public class VehicleController<T> : MonoBehaviour where T : Vehicle
    {
        [SerializeField]
        protected T _controlTarget;

        public T controlTarget { get => _controlTarget; set => _controlTarget = value; }
    }
}
