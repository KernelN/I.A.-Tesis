using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerFinisher : MonoBehaviour
{
    public bool HasFinished;
    AgentFinisher ScriptAgent;
    BoxFinisher ScriptBox;
    void Update()
    {
        ScriptAgent = transform.Find("Agents").GetComponent<AgentFinisher>();
        ScriptBox = transform.Find("Boxes").GetComponent<BoxFinisher>();
        if (ScriptAgent.HasFinished == true || ScriptBox.HasFinished == true)
        {
            HasFinished = true;
        }
    }
}
