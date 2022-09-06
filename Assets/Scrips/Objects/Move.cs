using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public Transform from;
    public Transform to;

    private Vector3 _origin;
    private Vector3 _tar;

    private void Start()
    {
        _origin = from.position;
        _tar = to.position;
    }

    public void Target()
    {
        this.transform.position = Vector3.MoveTowards(_origin, _tar,Vector3.Distance(_origin,_tar));
    }
}
