using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestVehicle : Vehicle
{
    private void Awake()
    {
        
    }

    private void Start()
    {
        int[] separateIndices = {0, 2};
        base._separateIndices = separateIndices;
    }

    public override void Update()
    {
        base.Update();
    }
}
