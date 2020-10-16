using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grow : MonoBehaviour
{
    float BodySize;
    float BodySizeforVector3;
    float BodyEnergy;
    float BodyNewEnergy;
    bool IsAPlant;

    void Start()
    {
        IsAPlant = "plant" == gameObject.GetComponent<Energy>().type;
        BodyEnergy = gameObject.GetComponent<Energy>().energy;
        BodyNewEnergy = BodyEnergy;

    }

    // Update is called once per frame
    void Update()
    {
        if (IsAPlant)
        {
            BodySize = BodyNewEnergy / BodyEnergy;
            BodySizeforVector3 = BodySize / 3;
            gameObject.transform.localScale = new Vector3(BodySizeforVector3, BodySizeforVector3, BodySizeforVector3);

            BodyNewEnergy = gameObject.GetComponent<Energy>().energy;
            BodyNewEnergy++;
            gameObject.GetComponent<Energy>().energy = BodyNewEnergy;
        }
    }
}
