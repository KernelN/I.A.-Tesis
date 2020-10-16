using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quit : MonoBehaviour
{
    public GameObject Gracias;

    // Update is called once per frame
    void Update()
    {
     if (Input.GetKey("escape")) { Application.Quit(); }  
     if (Input.GetKey("space")) { Gracias.SetActive(true); ; }   

    }
}
