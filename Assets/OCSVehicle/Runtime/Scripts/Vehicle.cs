using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OCS.Utility;

namespace OCS.Vehicle
{
    public class Vehicle : MonoBehaviour
    {
        [SerializeField, ReadOnly]
        private VehicleModule[] _modules;
        private Dictionary<string, VehicleModule> _modules_dic;

        private void Awake()
        {
            _modules = GetComponentsInChildren<VehicleModule>();
            _modules_dic = new Dictionary<string, VehicleModule>();
            foreach (VehicleModule module in _modules)
            {
                _modules_dic.Add(module.moduleName, module);
            }
        }

        public VehicleModule GetModule(string moduleName)
        {
            if (_modules_dic.ContainsKey(moduleName)) return null;
            return _modules_dic[moduleName];
        }

        public T GetModule<T>(string moduleName) where T : VehicleModule
        {
            if (!_modules_dic.ContainsKey(moduleName)) return null;
            VehicleModule vm = _modules_dic[moduleName];
            if (vm.moduleType != typeof(T)) return null;
            return vm as T;
        }
    }
}
