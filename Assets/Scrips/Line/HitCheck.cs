using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitCheck : MonoBehaviour
{
    public MovementComponent mov;//获取_AttachedLine
    public Rigidbody rb;//获取MainLine的rigidbody
    private void OnCollisionEnter(Collision collision)//碰撞
    {
        if (collision.collider.CompareTag("Wall"))
            Lost();
    }

    private void Update()//掉落
    {
        if(rb.velocity.y < -20)
            Lost();
    }

    private void Lost()
    {
        mov.StopLine();
        GameMode.Lost();
    }
}
