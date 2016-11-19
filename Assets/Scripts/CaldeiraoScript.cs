using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class CaldeiraoScript : MonoBehaviour
{
    private int listaIngredientesLimite;
    public Pocao pocao;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Ingrediente")
        {
            StartCoroutine(collision.transform.GetComponent<IngredienteController>().IngredienteNoCaldeirao());
            IngredienteAdicionarLista(collision.transform.gameObject);
        }
    }

    void IngredienteAdicionarLista(GameObject prefab)
    {        
        if (pocao.pocaoIngredientes.Count  < 3)
        {
            Ingrediente ingredienteNovo = new Ingrediente();
            ingredienteNovo.ingredientePrefab = prefab;
            pocao.pocaoIngredientes.Add(ingredienteNovo);

            if (pocao.pocaoIngredientes.Count == 3)
            {
                PocaoDatabase.singleton.PocaoChecar(pocao);
                pocao.pocaoIngredientes.Clear();
                //CHECAR SE RETORNAR NULO OU NAO OU VER SE FAZ UM PREFAB PRA QUANDO DER FALHA
            }
        }
    }

    void IngredienteFazerPocao()
    {
        /*PocaoVermelha
        1 Erva Vermelha
        1 Álcool
        1 Rubi

        Adicione o Alcool
        Adiciona a Erva
        Adiciona o Rubi

        Implementar mexer depois

        */

    }
}
