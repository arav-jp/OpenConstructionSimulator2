using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Excavator : MonoBehaviour
{
    [SerializeField]
    private float _timeout;

    private float _time_start;

    private void Update()
    {
        float time_now = Time.time;
        if(time_now - _time_start > _timeout)
        {
            /* Delete VoxelMap */
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag != "Terrain") return;
        _time_start = Time.time;
        /* Create VoxelMap */
    }
}
