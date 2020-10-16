using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentFinisher : MonoBehaviour
{
    public bool FinishAgents;
    public bool HasFinished;
    void Update()
    {
        if (transform.parent.GetComponent<LayerFinisher>().HasFinished)
        {
            if (transform.Find("Juanito 01") != null)
            {
                transform.Find("Juanito 01").GetComponent<DNA>().Fitness();
            }
            if (transform.Find("Juanito 02") != null)
            {
                transform.Find("Juanito 02").GetComponent<DNA>().Fitness();
            }

        }
        if (transform.childCount == 0) { HasFinished = true; }
    }
}
