using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Robotics.ROSTCPConnector;

using Float64 = RosMessageTypes.Std.Float64Msg;
using Parameters = InputInterfaceManager.InputInterfaceParameters;

[CreateAssetMenu]
public class RosInput : InputInterface
{
    [SerializeField] private string _topic;

    public override void Start()
    {
        ROSConnection.GetOrCreateInstance().Subscribe<Float64>(_topic, InputCB);
        base.Start();
    }

    public override void Update()
    {
        base.Update();
    }

    public override void SetParams(ref Parameters param)
    {
        if (param.stringParams == null)
        {
            GetParams(ref param);
            return;
        }
        if (param.stringParams.Length != 1) return;
        _topic = param.stringParams[0];
    }

    public override void GetParams(ref Parameters param)
    {
        param = new Parameters();
        param.stringParams = new string[1];
        param.stringParams[0] = _topic;
    }

    private void InputCB(Float64 msg)
    {
        _input = (float)msg.data;
    }
}
