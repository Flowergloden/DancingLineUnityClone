using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MyTimer : MonoBehaviour
{
    private float _time = 0;

    public float time
    {
        get
        {
            return _time;
        }
    }

    private void FixedUpdate()
    {
        _time += Time.fixedDeltaTime;
    }

    public void ResetTime()
    {
        _time = 0;
    }
}
