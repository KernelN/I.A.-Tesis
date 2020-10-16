using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class DNA : MonoBehaviour
{
    float timer;
    public float score;
    public int geneArea;
    public bool Ego;
    public bool geneAgressive;
    bool Checked;

    public void FirstGen()
    {
            geneAgressive = (Random.value > 0.5f);
            geneArea = Random.Range(1, 3);
        if (name == "Juanito 01" && geneArea == 1)
        {
            Ego = true;
        }
        else if (name == "Juanito 02" && geneArea == 2)
        {
            Ego = true;
        }
    }
            
    public void Son (GameObject parent, GameObject partner, float mutationRate = 0.01f)
    {

        float mutationChance = Random.Range(0.0f, 1.0f);

        if (mutationChance <= mutationRate)
        {
            if (Random.value > 0.5f)
            {
                geneAgressive = (Random.value > 0.5f);

                if (Random.value > 0.5f)
                {
                    Ego = parent.GetComponent<DNA>().Ego;
                }
                else
                {
                    Ego = partner.GetComponent<DNA>().Ego;
                }
            }
            else            
            {
                Ego = Random.Range(0, 1) < 1;

                if (Random.value > 0.5f)
                {
                    geneAgressive = parent.GetComponent<DNA>().geneAgressive;
                }
                else
                {
                    geneAgressive = partner.GetComponent<DNA>().geneAgressive;
                }
            }
        }
        else
        {
            int chance = Random.Range(0, 3);
            if (chance == 0)
            {
                geneAgressive = parent.GetComponent<DNA>().geneAgressive;
                Ego = parent.GetComponent<DNA>().Ego;
            }
            else if (chance == 1)
            {
                geneAgressive = partner.GetComponent<DNA>().geneAgressive;
                Ego = partner.GetComponent<DNA>().Ego;
            }
            else if (chance == 2)
            {
                geneAgressive = partner.GetComponent<DNA>().geneAgressive;
                Ego = parent.GetComponent<DNA>().Ego;
            }
            else if (chance == 3)
            {
                geneAgressive = parent.GetComponent<DNA>().geneAgressive;
                Ego = parent.GetComponent<DNA>().Ego;
            }
        }

        if (Ego && name == "Juanito 01")
        {
            geneArea = 1;
        }
        else if (Ego && name == "Juanito 02")
        {
            geneArea = 3;
        }
        else
        {
            geneArea = 2;
        }
    }

    public void Fitness()
    {
        if (!Checked)
        {
            score /= timer;
            score *= 10;
            Mathf.Pow(2, score);
        }
        Checked = true;
    }

    private void Update()
    {
         timer += Time.deltaTime;
    }
}





