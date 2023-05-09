using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoilManager : MonoBehaviour
{
    #region Inspector
    [SerializeField]
    private GameObject _soilObj;
    [SerializeField]
    private int _soilNum;
    [SerializeField]
    private float _soilSize_min;
    #endregion

    #region Parameters
    private Soil[] _soils;
    private Transform _transform;
    #endregion

    #region Properties
    public float soilSize_min { get => _soilSize_min; }
    #endregion

    private void Awake()
    {
        _transform = transform;
        _soils = new Soil[_soilNum];
    }

    private void Start()
    {
        for(int i = 0; i < _soilNum; i++)
        {
            var soil_obj = Instantiate(_soilObj);
            soil_obj.transform.parent = _transform;
            _soils[i] = soil_obj.GetComponent<Soil>();
            _soils[i].Init(this);
            _soils[i].Inactivate();
        }
    }

    public void Spawn(Vector3 position, float volume)
    {
        foreach(Soil soil in _soils)
        {
            if (soil.IsActivated()) continue;
            soil.Activate(position, volume);
            break;
        }
    }
}
