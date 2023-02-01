using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestVehicleController : VehicleController
{
    private void Awake()
    {
        _inputValues = new float[3];
    }
    
    private void Update()
    {
        if (Input.GetKey(KeyCode.W))
            _inputValues[0] = 1.0f;
        else if (Input.GetKey(KeyCode.S))
            _inputValues[0] = -1.0f;
        else
            _inputValues[0] = 0.0f;

        if (Input.GetKey(KeyCode.UpArrow))
            _inputValues[1] = 1.0f;
        else if (Input.GetKey(KeyCode.DownArrow))
            _inputValues[1] = -1.0f;
        else
            _inputValues[1] = 0.0f;

        if (Input.GetKeyDown(KeyCode.L))
        {
            _inputValues[2] = _inputValues[2] > 0.5f ? 0.0f : 1.0f;
        }
    }
}
