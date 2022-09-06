using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MyTimer : MonoBehaviour
{
    public float time = 0;

    private void FixedUpdate()
    {
        time += Time.fixedDeltaTime;
    }

    public void ResetTime()
    {
        time = 0;
    }
}
