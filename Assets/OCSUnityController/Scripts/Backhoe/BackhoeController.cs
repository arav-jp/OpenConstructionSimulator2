using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BackhoeController : VehicleController
{
    private BackhoeInput _input;

    [Header("Debug")]
    [SerializeField]
    [ReadOnly]
    private float _leftCrawlerThrottle;
    [SerializeField]
    [ReadOnly]
    private bool _leftCrawlerReverse;
    [SerializeField]
    [ReadOnly]
    private float _rightCrawlerThrottle;
    [SerializeField]
    [ReadOnly]
    private bool _rightCrawlerReverse;

    private void Awake()
    {
        _input = new BackhoeInput();
    }

    private void Start()
    {
        _input.Backhoe.LeftCrawlerThrottle.performed += LeftCrawlerThrottle;
        _input.Backhoe.LeftCrawlerReverse.started += LeftCrawlerReverse;
        _input.Backhoe.RightCrawlerThrottle.performed += RightCrawlerThrottle;
        _input.Backhoe.RightCrawlerReverse.started += RightCrawlerReverse;
        _input.Backhoe.Body.performed += Body;
        _input.Backhoe.Boom.performed += Boom;
        _input.Backhoe.Arm.performed += Arm;
        _input.Backhoe.Bucket.performed += Bucket;
        _input.Enable();
    }

    private void Update()
    {
        base._controlTarget.GetModule("LeftCrawler").input.unityInput = _leftCrawlerThrottle * (_leftCrawlerReverse ? -1.0f : 1.0f);
        base._controlTarget.GetModule("RightCrawler").input.unityInput = _rightCrawlerThrottle * (_rightCrawlerReverse ? -1.0f : 1.0f);
    }

    private void LeftCrawlerThrottle(InputAction.CallbackContext context)
    {
        _leftCrawlerThrottle = context.ReadValue<float>();
    }

    private void LeftCrawlerReverse(InputAction.CallbackContext context)
    {
        _leftCrawlerReverse = !_leftCrawlerReverse;
    }

    private void RightCrawlerThrottle(InputAction.CallbackContext context)
    {
        _rightCrawlerThrottle = context.ReadValue<float>();
    }

    private void RightCrawlerReverse(InputAction.CallbackContext context)
    {
        _rightCrawlerReverse = !_rightCrawlerReverse;
    }

    private void Body(InputAction.CallbackContext context)
    {
        base._controlTarget.GetModule("Body").input.unityInput = context.ReadValue<float>()*30.0f;
    }

    private void Boom(InputAction.CallbackContext context)
    {
        base._controlTarget.GetModule("Boom").input.unityInput = context.ReadValue<float>() * 30.0f;
    }

    private void Arm(InputAction.CallbackContext context)
    {
        base._controlTarget.GetModule("Arm").input.unityInput = context.ReadValue<float>() * 30.0f;
    }

    private void Bucket(InputAction.CallbackContext context)
    {
        base._controlTarget.GetModule("Bucket").input.unityInput = context.ReadValue<float>() * -30.0f;
    }
}
