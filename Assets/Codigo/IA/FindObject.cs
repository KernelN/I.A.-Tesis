using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindObject : MonoBehaviour
{
    public int MyArea;
    string ParentName;
    GameObject Parent;

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
        DNA ScriptDNA = (DNA)Parent.GetComponent(typeof(DNA));
        MyArea = ScriptDNA.geneArea;
        Move ScriptMove = (Move)Parent.GetComponent(typeof(Move));
        ScriptMove.StartLeftRotation();
    }

    private void OnTriggerStay(Collider other)
    {
        DNA ScriptDNA = (DNA)Parent.GetComponent(typeof(DNA));
        Move ScriptMove = (Move)Parent.GetComponent(typeof(Move));


        if (ScriptDNA.geneAgressive == true)
        {
            if (other.gameObject.tag == "Agent" && (Parent.transform.Find("Mouth").transform.childCount == 0))
            {
                TargetFound();
            }
        }

        else if (ScriptDNA.geneAgressive == false)
        {
            if (other.gameObject.tag == "Box" && (Parent.transform.Find("Mouth").transform.childCount == 0))
            {
                TargetFound();
            }

            else if (Parent.transform.Find("Mouth").childCount != 0)
            {
                if (MyArea == 3 && other.transform.name == "3")
                {
                    TargetFound();
                }

                else if (MyArea == 2 && other.transform.name == "2")
                {
                    TargetFound();
                }

                else if (MyArea == 1 && other.transform.name == "1")
                {
                    TargetFound();
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        DNA ScriptDNA = (DNA)Parent.GetComponent(typeof(DNA));
        Move ScriptMove = (Move)Parent.GetComponent(typeof(Move));


        if (ScriptDNA.geneAgressive == true)
        {
            if (other.gameObject.tag == "Agent" && (Parent.transform.Find("Mouth").transform.childCount == 0))
            {
                TargetFound();
            }
        }

        else if (ScriptDNA.geneAgressive == false)
        {
            if (other.gameObject.tag == "Box" && (Parent.transform.Find("Mouth").transform.childCount == 0))
            {
                TargetFound();
            }

            else if (Parent.transform.Find("Mouth").childCount != 0)
            {
                if (MyArea == 3 && other.transform.name == "3")
                {
                    TargetFound();
                }

                else if (MyArea == 2 && other.transform.name == "2")
                {
                    TargetFound();
                }

                else if (MyArea == 1 && other.transform.name == "1")
                {
                    TargetFound();
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        DNA ScriptDNA = (DNA)Parent.GetComponent(typeof(DNA));


        if (ScriptDNA.geneAgressive == true)
        {
            if (other.gameObject.tag == "Agent" && gameObject.transform.name == "Sight" && (Parent.transform.Find("Mouth").transform.childCount == 0))
            {
                TargetLost();
            }
        }

        else if (other.gameObject.tag == "Box" && gameObject.transform.name == "Sight")
        {
            TargetLost();
        }
    }
       

    void TargetLost()
    {
        Move ScriptMove = (Move)Parent.GetComponent(typeof(Move));
        ScriptMove.EndMove();
        ScriptMove.StartLeftRotation();
        gameObject.transform.Find("Sight Left").gameObject.SetActive(true);
        gameObject.transform.Find("Sight Right").gameObject.SetActive(true);
    }

    void TargetLock()
    {
        gameObject.transform.Find("Sight Left").gameObject.SetActive(false);
        gameObject.transform.Find("Sight Right").gameObject.SetActive(false);
    }
    
    void TargetFound()
    {
        Move ScriptMove = (Move)Parent.GetComponent(typeof(Move));

        if (gameObject.transform.name == "Sight Left")
        {
            ScriptMove.EndMove();
            ScriptMove.StartLeftRotation();
        }

        else if (gameObject.transform.name == "Sight Right")
        {
            ScriptMove.EndMove();
            ScriptMove.StartRightRotation();
        }

        else
        {
            ScriptMove.EndRotation();
            ScriptMove.StartMove();
            gameObject.transform.Find("Sight Left").gameObject.SetActive(false);
            gameObject.transform.Find("Sight Right").gameObject.SetActive(false);
        }
    }
}
