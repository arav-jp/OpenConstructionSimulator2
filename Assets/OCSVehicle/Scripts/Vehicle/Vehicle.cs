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

    public bool Input(string name, float value)
    {
        if (!_modules[name]) return false;
        _modules[name].input.unityInput = value;
        return true;
    }
}
