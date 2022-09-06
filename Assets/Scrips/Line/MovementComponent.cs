using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using Object = System.Object;

public class MovementComponent : MonoBehaviour
{
    public enum Direction
    {
        X = 0,
        Z = 1
    }
    public Transform tr;
    public GameObject line;
    public Rigidbody rb;
    [Space]
    public Direction direction;

    public float speed;

    [HideInInspector]public Vector3 deltaScale;

    private AttachedLine _attachedLine;
    private bool _falling = false;
    private void Start()
    {
        GetDeltaScale();
        CreatNewLine();
    }

    private void FixedUpdate()
    {
        tr.position += deltaScale;//位移
    }

    private void Update()
    {
        Turn();
        StopByChance();
    }

    private void GetDeltaScale()//获取当前方向的增量
    {
        if (direction == 0)
        {
            deltaScale = new Vector3(speed * Time.fixedDeltaTime, 0, 0);
        }
        else
        {
            deltaScale = new Vector3(0, 0, speed * Time.fixedDeltaTime);
        }
    }

    private void CreatNewLine()//生成一条附加线
    {
        _attachedLine = Instantiate(line, tr.position,Quaternion.identity).GetComponent<AttachedLine>();
        _attachedLine.speed = speed;
        _attachedLine.deltaScale = deltaScale;
    }

    private void Turn()//转向
    {
        if (Input.GetButtonDown("Turn"))
        {
            _attachedLine.HasStop = true;
            direction = (direction == Direction.X) ? Direction.Z : Direction.X;
            GetDeltaScale();
            CreatNewLine();
        }
    }
    
    private void StopByChance()//处理悬空情况
    {
        if(Mathf.Abs(rb.velocity.y) > 0.1)
        {
            _falling = true;
            _attachedLine.HasStop = true;
        }
        else if(_falling)
        {
            CreatNewLine();
            _falling = false;
        }
    }

    public void StopLine()
    {
        _attachedLine.HasStop = true;
        deltaScale = Vector3.zero;
    }
}
