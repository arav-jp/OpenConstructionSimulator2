using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Robotics.ROSTCPConnector;

using Float64 = RosMessageTypes.Std.Float64Msg;

[CreateAssetMenu]
public class RosOutput : OutputInterface
{
    [SerializeField] private string _topic;
    [SerializeField] private float _hz;

    private ROSConnection _ros;
    private Float64 _msg;

    private float _time_old;

    public override void Start()
    {
        _ros = ROSConnection.GetOrCreateInstance();
        _ros.RegisterPublisher<Float64>(_topic);
        _msg = new Float64();
        _time_old = 0.0f;
    }

    public override void Update()
    {
        if (!Application.isPlaying) return;

        float time_now = Time.time; 
        if(time_now - _time_old >= (1.0f / _hz))
        {
            _msg.data = base.output;
            _ros.Publish(_topic, _msg);
            _time_old = time_now;
        }
        base.Update();
    }
}
