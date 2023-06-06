using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoilManager : MonoBehaviour
{
    #region Inspector
    [SerializeField]
    private Zone _particleZone;
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

    private bool _inited = false;
    VoxelSystem.VoxelTerrain _vt;
    #endregion

    #region Properties
    public float soilSize_min { get => _soilSize_min; }
    #endregion

    private void Awake()
    {
        _transform = transform;
        _soils = new Soil[_soilNum];

        _inited = false;
    }

    private void Start()
    {
        for(int i = 0; i < _soilNum; i++)
        {
            var soil_obj = Instantiate(_soilObj);
            soil_obj.transform.parent = _transform;
            _soils[i] = soil_obj.GetComponent<Soil>();
            _soils[i].Init(this, _particleZone);
            _soils[i].Inactivate();
            if (_vt) _soils[i].SetVoxelTerrain(_vt);
        }

        _inited = true;
    }

    public void Spawn(Vector3 position, float volume, float density)
    {
        foreach(Soil soil in _soils)
        {
            if (soil.IsActivated()) continue;
            soil.Activate(position, volume, density);
            break;
        }
    }


    public void SetVoxelTerrain(VoxelSystem.VoxelTerrain voxelTerrain)
    {
        _vt = voxelTerrain;
        if (!_inited) return;
        foreach(Soil soil in _soils)
        {
            soil.SetVoxelTerrain(voxelTerrain);
        }
    }

    public void Inactivate()
    {
        foreach (Soil soil in _soils)
        {
            if(!_particleZone.IsPointInZone(soil.transform.position))
                soil.Inactivate();
        }
    }
}
