using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BookImage : MonoBehaviour {

    public static BookImage singleton;
    public Image bookSprite;
    public Text bookTextIngredientes;
    public Text bookTextPreparo;

	void Awake () {
        singleton = this;
	}

    //Função para abrir livro passando sprite,texto1,texto2
    public void AbrirLivro(Sprite bookImage, string textIngredientes, string textPreparo)
    {
        bookSprite.sprite = bookImage;
        bookTextIngredientes.text = textIngredientes;
        bookTextPreparo.text = textPreparo;
    }
}
