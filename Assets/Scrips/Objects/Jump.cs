using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public Transform to;
    public MyTimer timer;
    public float deltaXorZ;

    private MovementComponent.Direction _dir;
    private AnimationCurve _anim;
    private GameObject _mainLine;
    private MovementComponent _mov;
    private Vector3 _origin;
    private Vector3 _tar;
    private float _time;
    private bool _startJump;

    private void Start()
    {
        _mainLine = GameObject.FindWithTag("Line");
        _mov = _mainLine.GetComponent<MovementComponent>();
        _time = deltaXorZ / _mov.speed;
        _anim = AnimationCurve.EaseInOut(0, 0, _time, 1);
    }

    private void FixedUpdate()
    {
        if(_startJump)
            _mainLine.transform.position = Vector3.Lerp(_origin,_tar,_anim.Evaluate(timer.time));
    }

    public void Target()
    {
        _origin = _mainLine.transform.position;
        if (_dir == MovementComponent.Direction.X)
        {
            _tar = new Vector3(to.position.x, to.position.y, _origin.z);
        }
        else
        {
            _tar = new Vector3(_origin.x, to.position.y, to.position.z);
        }
        timer.ResetTime();
        _startJump = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Line"))
        {
            _startJump = false;
        }
    }
}
