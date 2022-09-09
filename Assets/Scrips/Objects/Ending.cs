using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ending : MonoBehaviour
{
    private GameObject _mainLine;
    private MovementComponent _mov;

    private void Start()
    {
        _mainLine = GameObject.FindWithTag("Line");
        _mov = _mainLine.GetComponent<MovementComponent>();
    }

    public void Target()
    {
        _mov.StopLine();
        _mov.CreatNewLine();
        _mov.AttachedLine.transform.rotation = Quaternion.Euler(0, 45, 0);
        Destroy(_mainLine);
        GameMode.Win();
    }
}
