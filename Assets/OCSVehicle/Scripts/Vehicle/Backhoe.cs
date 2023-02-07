using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backhoe : Vehicle
{
    private void Awake()
    {

    }

    private void Start()
    {
        int[] separateIndices = { 0, 2, 3, 4, 5 , 6, 7};
        base._separateIndices = separateIndices;
    }

    public override void Update()
    {
        base.Update();
    }
}
