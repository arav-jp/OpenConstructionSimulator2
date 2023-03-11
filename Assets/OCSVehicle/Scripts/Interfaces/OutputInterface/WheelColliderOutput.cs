using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class WheelColliderOutput : OutputInterface
{
    [SerializeField]
    private float _torqueCoef;
    [SerializeField]
    private float _maxTorque;
    [SerializeField]
    private float _brakeTorque;
    [SerializeField]
    private float _brakeThreshold;
    private WheelCollider[] _wheelColliders;

    public override void Start()
    {
        _wheelColliders = base._transform.GetComponentsInChildren<WheelCollider>();
        base.Start();
    }

    public override void Update()
    {
        UpdateTorque(Mathf.Clamp(base.output*_torqueCoef, -_maxTorque, _maxTorque));
        UpdateBrakeTorque(Mathf.Abs(base.output) < _brakeThreshold ? _brakeTorque : 0.0f);
        base.Update();
    }

    public void UpdateTorque(float torque)
    {
        foreach (WheelCollider wc in _wheelColliders)
        {
            wc.motorTorque = torque;
        }
    }

    public void UpdateBrakeTorque(float torque)
    {
        foreach (WheelCollider wc in _wheelColliders)
        {
            wc.brakeTorque = torque;
        }
    }
}
