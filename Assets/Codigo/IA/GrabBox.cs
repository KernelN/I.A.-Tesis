using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabBox : MonoBehaviour
{
    string ParentName;
    GameObject Parent;

    void Awake()
    {
        ParentName = transform.parent.name;
        Parent = transform.parent.gameObject;
        Move ScriptMove = (Move)Parent.GetComponent(typeof(Move));
    }

    private void OnTriggerEnter(Collider other)
    {
        Move ScriptMove = (Move)Parent.GetComponent(typeof(Move));
        DNA ScriptDNA = (DNA)Parent.GetComponent(typeof(DNA));

        if (other.gameObject.tag == "Box" && (Parent.transform.Find("Mouth").transform.childCount == 0) && ScriptDNA.geneAgressive == false)
        {
            other.transform.SetParent(transform);
            other.attachedRigidbody.isKinematic = true;
            other.isTrigger = true;
            ScriptMove.StartLeftRotation();
            ScriptMove.EndMove();

        }
    }
}
