using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropBox : MonoBehaviour
{
    public static bool callbacksOnDisable;
    public int MyArea;
    string ParentName;
    GameObject Parent;
    GameObject Other;
    Rigidbody rb;
    BoxCollider BoxColl;


    void Start()
    {
        if (name != "Sight" && name != "Mouth")
        {
            ParentName = (transform.parent.transform.parent.name);
            Parent = transform.parent.transform.parent.gameObject;
        }
        else
        {
            ParentName = transform.parent.name;
            Parent = transform.parent.gameObject;
        }
        Move ScriptMove = (Move)Parent.GetComponent(typeof(Move));
        DNA ScriptDNA = (DNA)Parent.GetComponent(typeof(DNA));
        MyArea = ScriptDNA.geneArea;

        if (ParentName == "Juanito 01")
        {
            Other = Parent.transform.parent.Find("Juanito 02").gameObject;
        }
        else if (ParentName == "Juanito 02")
        {
            Other = Parent.transform.parent.Find("Juanito 01").gameObject;
        }
    }
    
    private void OnTriggerStay(Collider other)
    {
        if (gameObject.transform.name == "Mouth" && (gameObject.transform.Find("Box")) != null)
        {
            if (gameObject.transform.Find("Box").tag == "Box")
            {
                if ((MyArea == 3 && other.transform.name == "3") || (MyArea == 2 && other.transform.name == "2") || (MyArea == 1 && other.transform.name == "1"))
                {
                    BoxDropper();
                }
            }
        }
    }
       
    private void OnTriggerExit(Collider other)
    {
        if (gameObject.transform.name == "Sight" && (gameObject.transform.parent.Find("Mouth").transform.Find("Box")) != null)
        {

            if (gameObject.transform.parent.Find("Mouth").transform.Find("Box").tag == "Box")
            {
                if (MyArea == 3 && other.transform.name == "3")
                {
                    AreaLost();
                }

                else if (MyArea == 2 && other.transform.name == "2")
                {
                    AreaLost();
                }

                else if (MyArea == 1 && other.transform.name == "1")
                {
                    AreaLost();
                }
            }
        }
    }



    private void BoxDropper()
    {
        Move ScriptMove = (Move)Parent.GetComponent(typeof(Move));
        DNA ScriptDNA = (DNA)Parent.GetComponent(typeof(DNA));

        //Area Reached

        ScriptMove.EndMove();
        ScriptMove.EndRotation();
        Destroy(transform.Find("Box").gameObject);

        if ((MyArea == 1 && Parent.name == "Juanito 01") || (MyArea == 3 && Parent.name == "Juanito 02"))
        {
            ScriptDNA.score++;
        }
        else if (MyArea == 2)
        {
            if (Other != null)
            {
                DNA ScriptDNA2 = (DNA)Other.GetComponent(typeof(DNA));
                ScriptDNA2.score += 0.5f;
            }
            ScriptDNA.score += 0.5f;
        }

        ///Box Dropped

        ScriptMove.StartLeftRotation();
        ScriptMove.EndMove();

        ///Reactivate Peripheral Vision

        Parent.transform.Find("Sight").Find("Sight Left").gameObject.SetActive(true);
        Parent.transform.Find("Sight").Find("Sight Right").gameObject.SetActive(true);


    }
       
    private void AreaLost()
    {
        Move ScriptMove = (Move)Parent.GetComponent(typeof(Move));
        ScriptMove.StartLeftRotation();
        ScriptMove.EndMove();
    }
}
