using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PocaoDatabase : MonoBehaviour {

    public static PocaoDatabase singleton;
    public Transform pocaoSpawn;
    public Pocao[] pocoes;

    void Awake()
    {
        singleton = this;
    }

    //Verificar se os ingredientes da lista de ingredientes é possivel fazer alguma poção
    public void PocaoFazer(Pocao pocao)
    {
        foreach (Pocao m_pocao in pocoes)
        {
            //Se a sequencia dos 3 ingredientes for igual a sequencia do outro, fazer esta poção
            int count = 0;
            for (int i = 0; i < m_pocao.pocaoIngredientes.Count; i++)
            {
                if (m_pocao.pocaoIngredientes [i].ingredientePrefab.name == pocao.pocaoIngredientes[i].ingredientePrefab.name)
                {
                    count++;
                    //print("IGUAL");
                }
            }
            if (count == 3)
            {
                Instantiate(m_pocao.pocaoPrefab, pocaoSpawn.position, m_pocao.pocaoPrefab.transform.rotation);                
                //m_pocao.pocaoPrefab;
                print("FAZERPOCAO");
                return;
            } else
            {
                return;
            }
        }
        ParticleSystemExtension.SetEmissionRate(CaldeiraoScript.singleton.GetComponent<ParticleSystem>(), 5);
    }
}

public static class ParticleSystemExtension
{
    public static void EnableEmission(this ParticleSystem particleSystem, bool enabled)
    {
        var emission = particleSystem.emission;
        emission.enabled = enabled;
    }

    public static float GetEmissionRate(this ParticleSystem particleSystem)
    {
        return particleSystem.emission.rate.constantMax;
    }

    public static void SetEmissionRate(this ParticleSystem particleSystem, float emissionRate)
    {
        var emission = particleSystem.emission;
        var rate = emission.rate;
        rate.constantMax = emissionRate;
        emission.rate = rate;
    }
}

[System.Serializable]
public class Pocao
{
    public string pocaoNome;
    public List<Ingrediente> pocaoIngredientes;
    public GameObject pocaoPrefab;
}
