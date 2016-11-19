using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PocaoDatabase : MonoBehaviour {

    public static PocaoDatabase singleton;
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
                    print("IGUAL");
                }
            }
            if (count == 3)
            {
                //return m_pocao.pocaoPrefab;
                print("FAZERPOCAO");
                return;
            } else
            {
                return;
            }
        }
        Debug.Log("FIM");
    }
}

[System.Serializable]
public class Pocao
{
    public string pocaoNome;
    public List<Ingrediente> pocaoIngredientes;
    public GameObject pocaoPrefab;
}
