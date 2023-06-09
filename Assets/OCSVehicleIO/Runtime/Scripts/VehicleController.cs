using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;
using OCS.Vehicle;

namespace OCS.VehicleIO
{
    using Vehicle = OCS.Vehicle.Vehicle;

    public class VehicleController : MonoBehaviour
    {
        [SerializeField] protected Vehicle _controlTarget;

        public void SetControlTarget(Vehicle controlTarget)
        {
            _controlTarget = controlTarget;
        }
    }
}
