using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OCS.Vehicle
{
    public class LightModule : VehicleModule
    {
        [SerializeField]
        private GameObject _light_obj;

        public override Type moduleType { get => typeof(LightModule); }

        public void On()
        {
            _light_obj.SetActive(true);
        }
        
        public void Off()
        {
            _light_obj.SetActive(false);
        }
    }
}
