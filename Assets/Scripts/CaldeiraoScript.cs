using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CaldeiraoScript : MonoBehaviour
{
    public List<GameObject> listaIngredientes;
    private int listaIngredientesLimite;

    void Awake()
    {
        listaIngredientes.Clear();
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Ingrediente")
        {
            StartCoroutine(collision.transform.GetComponent<Ingrediente>().IngredienteNoCaldeirao());
            IngredienteAdicionarLista(collision.transform.gameObject);
        }
    }

    void IngredienteAdicionarLista(GameObject ingredienteNovo)
    {        
        if (listaIngredientes.Count < 3)
        {
            listaIngredientes.Add(ingredienteNovo);
        } else
        {
            print("FAZERPOCAO");
        }
    }
}
