using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Energy : MonoBehaviour
{
    public static Energy instance;
    public float energy;
    public float size;
    Renderer rend;

    public string type;
    public bool typeSelector;

    public void Awake()
    {
        rend = GetComponent<Renderer>();
        size = rend.bounds.size.magnitude;
        energy = size * 5000;
        if (typeSelector == true) { type = "plant"; }
        else { type = "animal"; } //false equals Animal, true equal Plant
    }

    void Start()
    {
        instance = this;
    }

    public void Update()
    {
        //size = rend.bounds.size.magnitude;
        if (energy <= 0) { Object.Destroy(gameObject); }

    }
}
