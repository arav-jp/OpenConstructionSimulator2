using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : MonoBehaviour
{
    private Dictionary<string, VehicleModule> _modules;

    private void Awake()
    {
        _modules = new Dictionary<string, VehicleModule>();

        VehicleModule[] vms = GetComponentsInChildren<VehicleModule>();
        foreach (VehicleModule vm in vms)
        {
            _modules.Add(vm.name, vm);
        }
    }

    public VehicleModule GetModule(string name)
    {
        if (!_modules[name]) return null;
        return _modules[name];
    }
}
