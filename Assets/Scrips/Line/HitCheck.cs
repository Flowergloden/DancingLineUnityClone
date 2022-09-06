using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitCheck : MonoBehaviour
{
    public MovementComponent mov;//获取_AttachedLine
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Wall"))
        {
            Lost();
        }
    }

    private void Lost()
    {
        mov.StopLine();
        Time.timeScale = 0;
        Debug.Log("lost");
    }
}
