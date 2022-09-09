using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump_direct : MonoBehaviour
{
    public float jumpForce;
    private Rigidbody _rb;

    private void Start()
    {
        _rb = GameObject.FindWithTag("Line").GetComponent<Rigidbody>();
    }

    public void Target()
    {
        _rb.velocity += Vector3.up * jumpForce;
    }
}
