using UnityEngine;
using System.Collections;

public class CaldeiraoScript : MonoBehaviour
{

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Ingrediente")
        {
            StartCoroutine(collision.transform.GetComponent<Ingrediente>().IngredienteNoCaldeirao());
        }
    }
}
