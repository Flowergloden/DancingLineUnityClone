using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    //所有通过该Trigger触发的函数统一命名Target()
    public GameObject tar;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Line"))
            tar.SendMessage("Target");
    }
}
