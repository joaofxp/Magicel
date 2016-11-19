using UnityEngine;
using System.Collections;

public class IngredientesDatabase : MonoBehaviour {

    public static IngredientesDatabase singleton;
    public Ingrediente[] ingredientes;
    
    void Awake()
    {
        singleton = this;
    }
}

[System.Serializable]
public class Ingrediente
{
    public GameObject ingredientePrefab;
}
