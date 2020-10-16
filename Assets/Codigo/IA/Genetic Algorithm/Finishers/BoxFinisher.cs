using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxFinisher : MonoBehaviour
{
    public bool HasFinished;
    void Update()
    {
        if(transform.childCount == 0) { HasFinished = true; }
    }
}
