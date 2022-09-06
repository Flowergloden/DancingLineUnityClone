using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public Transform to;
    
    private GameObject _mainLine;
    private Rigidbody _rb;
    private MovementComponent _mov;
    private Vector3 _origin;
    private Vector3 _tar;
    private float _distance;
    private float _time;
    private Vector3 _velocity;
    private bool _startJump;

    private void Start()
    {
        _mainLine = GameObject.FindWithTag("Line");
        _rb = _mainLine.GetComponent<Rigidbody>();
        _mov = _mainLine.GetComponent<MovementComponent>();
    }
    
    public void Target()
    {
        _origin = _mainLine.transform.position;
        _tar = new Vector3(_origin.x, to.position.y,_origin.z);
        GetDistance();
        _time = _distance / (_mov.speed * Time.fixedDeltaTime);
        _mainLine.transform.position = Vector3.SmoothDamp(_origin, _tar,ref _velocity, _time);
    }

    private void GetDistance()//获取当前方向的增量
    {
        MovementComponent.Direction direction = _mov.direction;
        if (direction == 0)
        {
            _distance= Mathf.Abs(_tar.x - _origin.x);
        }
        else
        {
            _distance = Mathf.Abs(_tar.z - _origin.z);
        }
    }
}
