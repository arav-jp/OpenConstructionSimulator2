using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OCS.Vehicle
{
    public class LightModule : MonoBehaviour
    {
        [SerializeField]
        private GameObject _light_obj;

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
