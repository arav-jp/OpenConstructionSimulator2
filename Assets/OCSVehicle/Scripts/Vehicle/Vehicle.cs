using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : MonoBehaviour
{
    [SerializeField] private VehicleController _controller;
    [SerializeField] private Chassis _chassis;
    [SerializeField] private Equipment[] _equipments;

    protected int[] _separateIndices;

    public virtual void Update()
    {
        for(int i = 0; i < _separateIndices.Length - 1; i++)
        {
            int size = _separateIndices[i + 1] - _separateIndices[i];
            float[] input = new float[size];
            for(int j = 0; j < size; j++)
            {
                input[j] = _controller.inputValues[_separateIndices[i] + j];
            }
            if (i == 0) _chassis.UpdateInput(input);
            else if (_equipments[i - 1])_equipments[i - 1].UpdateInput(input);
        }
    }
}
