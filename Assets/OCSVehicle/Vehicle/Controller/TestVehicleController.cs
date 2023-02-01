using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestVehicleController : VehicleController
{
    private void Awake()
    {
        _inputValues = new float[2];
    }
    
    private void Update()
    {
        _inputValues[0] = 1.0f;
        _inputValues[1] = 1.0f;
    }
}
