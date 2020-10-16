using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eat : MonoBehaviour
{
    Rigidbody rb;
    float BodySize;
    float BodyOrgiginalEnergy;
    float BodyNewEnergy;
    string BodyName;

    private void Start()
    {
        BodyOrgiginalEnergy = GetComponentInParent<Energy>().energy;
        BodySize = GetComponentInParent<Energy>().size;
        BodyName = transform.parent.name;
    }

    public void Update()
    {
        GetComponentInParent<Energy>().energy += BodyNewEnergy;
        BodyNewEnergy = 0;
    }


    private void OnTriggerEnter(Collider other)
    {
        Move ScriptMove = (Move)transform.parent.gameObject.GetComponent(typeof(Move));
        DNA ScriptDNA = (DNA)transform.parent.gameObject.GetComponent(typeof(DNA));

        if (other.gameObject.tag == "Agent" && ScriptDNA.geneAgressive == true)
        {
            if (other.GetComponent<Energy>().type == "plant")
            {
                other.GetComponent<Energy>().energy -= BodyOrgiginalEnergy / 900;
                BodyNewEnergy += BodyOrgiginalEnergy / 1000;
            }

            else
            {
             //   BodyNewEnergy += other.GetComponent<Energy>().energy;
                other.GetComponent<Energy>().energy = 0;
                ScriptMove.EndMove();
                ScriptMove.StartLeftRotation();
                ScriptDNA.geneAgressive = false;
            }

        }

    }
}
