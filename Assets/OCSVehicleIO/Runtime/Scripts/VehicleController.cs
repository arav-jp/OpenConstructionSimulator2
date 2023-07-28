using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OCS.VehicleIO
{
    using Vehicle = Vehicle.Vehicle;

    public struct JoyStickInput
    {
        private float _x;
        private float _y;

        public float x { get => _x; set => Mathf.Clamp01(value); }
        public float y { get => _y; set => Mathf.Clamp01(value); }
    }

    public class VehicleController<T> : MonoBehaviour where T : Vehicle
    {
        [SerializeField]
        protected T _controlTarget;

        public T controlTarget { get => _controlTarget; set => _controlTarget = value; }
    }
}
