using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoRoadMaker : MonoBehaviour
{
    public GameObject mainLine;
    public GameObject road;
    
    private MovementComponent _father;
    private float _speed;
    private Vector3 _deltaScale;
    private AttachedLine _attachedLine;
    private Vector3 _deltaPosition = new Vector3(-1, -1, -1);
    private MovementComponent.Direction _direction;

    private void Start()
    {
        mainLine.GetComponent<Rigidbody>().useGravity = false;
        _father = mainLine.GetComponent<MovementComponent>();
        _speed = _father.speed;
        _direction = _father.direction;
        GetDeltaScale();
        CreatNewLine();
    }

    private void Update()
    {
        Turn();
    }

    private void GetDeltaScale()//获取当前方向的增量
    {
        if (_direction == 0)
        {
            _deltaScale = new Vector3(_speed * Time.fixedDeltaTime, 0, 0);
        }
        else
        {
            _deltaScale = new Vector3(0, 0, _speed * Time.fixedDeltaTime);
        }
    }

    private void CreatNewLine()//生成一条附加线
    {
        _attachedLine = Instantiate(road, mainLine.transform.position + _deltaPosition,Quaternion.identity).GetComponent<AttachedLine>();
        _attachedLine.speed = _speed;
        _attachedLine.deltaScale = _deltaScale;
    }

    private void Turn()//转向
    {
        if (Input.GetButtonDown("Turn"))
        {
            _direction = (_direction == MovementComponent.Direction.X) ? MovementComponent.Direction.Z : MovementComponent.Direction.X;
            _attachedLine.HasStop = true;
            GetDeltaScale();
            CreatNewLine();
        }
    }
}
