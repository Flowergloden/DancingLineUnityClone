using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachedLine : MonoBehaviour
{
    public Transform tr;
    public float speed;
    public bool HasStop;

    [HideInInspector]public Vector3 deltaScale;
    private void FixedUpdate()
    {
        if(!HasStop)
            tr.localScale += deltaScale;
    }
}
