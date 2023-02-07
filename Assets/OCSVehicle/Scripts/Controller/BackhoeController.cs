using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackhoeController : VehicleController
{
    private void Awake()
    {
        _inputValues = new float[7];
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

        if (Input.GetKeyDown(KeyCode.Y)) _inputValues[2] = _inputValues[2] > -10.0f ? -20.0f : 0.0f;
        _inputValues[3] = Input.GetKey(KeyCode.RightArrow) ? 30.0f : (Input.GetKey(KeyCode.LeftArrow) ? -30.0f : 0);
        _inputValues[4] = Input.GetKey(KeyCode.U) ? 15.0f : (Input.GetKey(KeyCode.J) ? -15.0f : 0);
        _inputValues[5] = Input.GetKey(KeyCode.I) ? 25.0f : (Input.GetKey(KeyCode.K) ? -25.0f : 0);
        _inputValues[6] = Input.GetKey(KeyCode.O) ? 35.0f : (Input.GetKey(KeyCode.L) ? -35.0f : 0);
    }
}
