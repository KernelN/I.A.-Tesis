using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Population : MonoBehaviour
{
    public List<GameObject> layer = new List<GameObject>();
    public List<GameObject> population = new List<GameObject>();
    List<GameObject> fittest = new List<GameObject>();
    public int populationSize = 100;
    public int Gen;
    int GenFinish;
    float timer;
    public GameObject LayerPrefab;
    GameObject go;
    GameObject Agent01;
    GameObject Agent02;
    GameObject Parent;
    GameObject Partner;




    void Awake()
    {
        Gen = 1;
        for (int i = 0; i < populationSize; i++)
        {
            Vector3 v3 = new Vector3(0, 0, i*2);
            go = Instantiate(LayerPrefab, v3, Quaternion.identity);
            Agent01 = go.transform.Find("Agents").Find("Juanito 01").gameObject;
            Agent02 = go.transform.Find("Agents").Find("Juanito 02").gameObject;
            Agent01.GetComponent<DNA>().FirstGen();
            Agent02.GetComponent<DNA>().FirstGen();
            layer.Add(go);
            population.Add(Agent01);
            population.Add(Agent02);
        }
    }

    void Update()
    {
        timer += Time.deltaTime;

        for (int i = 0; i < populationSize; i++)
        {
            if (layer[i].GetComponent<LayerFinisher>().HasFinished)
            {
                GenFinish++;
            }
        }
        if (populationSize <= GenFinish || timer > 30f)
        {
            timer = 0f;
            GetFittest();
            NextGen();
        }
        GenFinish = 0;

    }

    void GetFittest()
    {
        int index = 0;
        float maxFitness = float.MinValue;
        float fitness = 0;
        for (int i = 0; i < population.Count; i++)
        {
            if (population[i] != null)
            {
                DNA ScriptDNA = (DNA)population[i].GetComponent(typeof(DNA));
                ScriptDNA.Fitness();
                fitness = ScriptDNA.score;
                if (fitness > maxFitness)
                {
                    maxFitness = fitness;
                    fittest.Add(population[i]);
                    index++;
                }
            }
            else
            {
                population.Remove(population[i]);
                i = -1;
            }
        }
        index = 0;
        for (int i = fittest.Count - 1; i > -1; i--)
        {
            fittest[index] = fittest[i];
            index++;
            population.Remove(fittest[i]);
        }

    }

    void Mate()
    {
        for (int i = 0; i < 2; i++)
        {
            float random = Random.Range(0.0f, 1.0f);

            if (i == 0)
            {
                if (random <= 0.125f)
                {
                    GetParent2();
                }
                else if (random > 0.125f && random <= 0.5f)
                {
                    GetParent1();
                }
                else if (random > 0.5f)
                {
                    GetParent0();
                }
            }
            else if (i == 1)
            {
                if (random <= 0.125f)
                {
                    GetPartner2();
                }
                else if (random > 0.125f && random <= 0.5f)
                {
                    GetPartner1();
                }
                else if (random > 0.5f)
                {
                    GetPartner0();
                }
            }
        }

    }

    void NextGen()
    {
        Gen++;

        for (int i = 0; i < populationSize; i++)
        {
            Destroy(layer[i]);
        }
        population.Clear();
        layer.Clear();

        for (int i = 0; i < populationSize; i++)
        {
            Vector3 v3 = new Vector3(0, 0, i * 2);
            go = Instantiate(LayerPrefab, v3, Quaternion.identity);
            Agent01 = go.transform.Find("Agents").Find("Juanito 01").gameObject;
            Agent02 = go.transform.Find("Agents").Find("Juanito 02").gameObject;
            for (int j = 0; j < 2; j++)
            {
                if (j == 0)
                {
                    Mate();
                    Agent01.GetComponent<DNA>().Son(Parent, Partner);
                }
                else if (j == 1)
                {
                    Mate();
                    Agent02.GetComponent<DNA>().Son(Parent, Partner);
                }
            }
            layer.Add(go);            
            population.Add(Agent01);
            population.Add(Agent02);
        }        
    }

    void GetParent0()
    {
        if (fittest[0] != null)
        {
            Parent = fittest[0];
        }
    }

    void GetParent1()
    {
        if (fittest[1] != null)
        {
            Parent = fittest[1];
        }
        else if (fittest[0] != null)
        {
            Parent = fittest[0];
        }
    }

    void GetParent2()
    {
        if (fittest[2] != null)
        {
            Parent = fittest[2];
        }
        else if (fittest[1] != null)
        {
            Parent = fittest[1];
        }
        else if (fittest[0] != null)
        {
            Parent = fittest[0];
        }
    }

    void GetPartner0()
    {
        if (fittest[0] != null)
        {
            Partner = fittest[0];
        }
    }

    void GetPartner1()
    {
        if (fittest[1] != null)
        {
            Partner = fittest[1];
        }
        else if (fittest[0] != null)
        {
            Partner = fittest[0];
        }
    }

    void GetPartner2()
    {
        if (fittest[2] != null)
        {
            Partner = fittest[2];
        }
        else if (fittest[1] != null)
        {
            Partner = fittest[1];
        }
        else if (fittest[0] != null)
        {
            Partner = fittest[0];
        }
    }

}

