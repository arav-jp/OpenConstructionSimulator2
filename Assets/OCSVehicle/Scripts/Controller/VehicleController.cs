using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleController : MonoBehaviour
{
    [SerializeField]
    protected float[] _inputValues;
    public float[] inputValues { get => this._inputValues; }
}
