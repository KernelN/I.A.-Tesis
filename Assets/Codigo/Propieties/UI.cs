using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Text Generacion;
    public Text Ego;
    public Text Agresivo;
    public Text Capas;
    public Text Agentes;
    int i;
    int Poblacion;
    int CapasActivas;
    int Gen;
    int GenAltruista;
    int GenEgoista;
    int GenAgresivo;
    int GenPacifico;

    private void Update()
    {
        Population ScriptPopulation = GameObject.Find("Controller").GetComponent<Population>();
        Gen = ScriptPopulation.Gen;
        GetAgents();
        Layers();
        Agentes.text = "Agentes Vivos: " + Poblacion + "/" + ScriptPopulation.population.Count;
        Capas.text = "Capas Finalizadas: " + CapasActivas + "/" + ScriptPopulation.layer.Count;
        if (i < Gen)
        {
            CapasActivas = 0;
            Poblacion = 0;
            GenAltruista = 0;
            GenEgoista = 0;
            GenAgresivo = 0;
            GenPacifico = 0;

            Generacion.text = "Generacion: " + ScriptPopulation.Gen;
            GetAgressive();
            GetEgo();
            i++;
        }
    }

    void GetEgo()
    {
        Population ScriptPopulation = GameObject.Find("Controller").GetComponent<Population>();
        for (int i = 0; i < ScriptPopulation.population.Count; i++)
        {
            DNA ScriptDNA = ScriptPopulation.population[i].GetComponent<DNA>();
            if (ScriptDNA.Ego)
            {
                GenEgoista++;
            }
            else if (!ScriptDNA.Ego)
            {
                GenAltruista++;
            }
        }
        if (GenEgoista < GenAltruista) { Ego.text = "Gen Altruista"; }
        else if (GenAltruista < GenEgoista) { Ego.text = "Gen Egoista"; }
        else { Ego.text = "Defininendo..."; }

    }

    void GetAgressive()
    {
        Population ScriptPopulation = GameObject.Find("Controller").GetComponent<Population>();
        for (int i = 0; i < ScriptPopulation.population.Count; i++)
        {
            DNA ScriptDNA = ScriptPopulation.population[i].GetComponent<DNA>();
            if (ScriptDNA.geneAgressive)
            {
                GenAgresivo++;
            }
            else if (!ScriptDNA.geneAgressive)
            {
                GenPacifico++;
            }
        }
        if (GenAgresivo < GenPacifico) { Agresivo.text = "Gen Pacifista"; }
        else if (GenAgresivo > GenPacifico) { Agresivo.text = "Gen Agresivo"; }
        else { Agresivo.text = "Defininendo..."; }

    }

    void GetAgents()
    {
        Population ScriptPopulation = GameObject.Find("Controller").GetComponent<Population>();
        int j = 0;
        for (int i = 0; i < ScriptPopulation.population.Count; i++)
        {
            if (ScriptPopulation.population[i] != null) { j++; }
        }
        if (j != Poblacion) { Poblacion = j; }
    }

    void Layers()
    {
        Population ScriptPopulation = GameObject.Find("Controller").GetComponent<Population>();
        int j = 0;
        for (int i = 0; i < ScriptPopulation.populationSize; i++)
        {
            if (ScriptPopulation.layer[i].GetComponent<LayerFinisher>().HasFinished) { j++; }
        }
        if (j!= CapasActivas) { CapasActivas = j; }
    }
}
