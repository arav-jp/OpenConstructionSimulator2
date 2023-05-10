using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Robotics.ROSTCPConnector;

using Float64 = RosMessageTypes.Std.Float64Msg;

[CreateAssetMenu]
public class RosInput : InputInterface
{
    [SerializeField] private string _topic;

    public override void Start()
    {
        ROSConnection.GetOrCreateInstance().Subscribe<Float64>(_topic, InputCB);
    }

    private void InputCB(Float64 msg)
    {
        base.input = (float)msg.data;
    }
}
