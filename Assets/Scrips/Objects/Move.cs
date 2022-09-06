using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public Transform from;
    public Transform to;
    public AnimationCurve anim;
    public MyTimer timer;

    private Vector3 _origin;
    private Vector3 _tar;
    private bool _startMove = false;

    private void Start()
    {
        _origin = from.position;
        _tar = to.position;
    }

    private void FixedUpdate()
    {
        if(_startMove)
            this.transform.position = Vector3.Lerp(_origin,_tar,anim.Evaluate(timer.time));
    }

    public void Target()
    {
        timer.ResetTime();
        _startMove = true;
    }
}
