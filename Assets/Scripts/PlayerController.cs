using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System;

public class PlayerController : MonoBehaviour {

    public static PlayerController singleton;
    public Camera mainCamera;
    public GameObject bookImageGameObject;
    public TextMesh infoText;
    public GameObject laserSelecionadoPrefab;

    void Awake()
    {
        singleton = this;
        mainCamera = GetComponent<Camera>();
    }

    void Update()
    {
        Ray ray = mainCamera.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit,100, 1 << 8) && Input.GetKeyDown(KeyCode.Space))
        {
            switch (hit.transform.tag)
            {
                case "Play":
                    hit.transform.gameObject.SetActive(false);
                    break;
                case "ButtonMute":
                    AudioMute.singleton.AudioToggle();
                    break;
                case "ButtonExit":
                    Application.Quit();
                    break;
                case "BookOpen":
                    bookImageGameObject.SetActive(true);
                    BookOpen book = hit.transform.GetComponent<BookOpen>();
                    BookImage.singleton.AbrirLivro(book.bookSprite, book.bookTextIngredientes.text, book.bookTextPreparo.text);
                    break;
                case "BookClose":
                    bookImageGameObject.SetActive(false);
                    break;
                case "Ingrediente":
                    hit.transform.GetComponent<IngredienteController>().IngredienteSelecionado();
                    if (hit.transform.childCount == 0)
                    {
                        GameObject laserSelecionado = Instantiate(laserSelecionadoPrefab, hit.transform, false) as GameObject;
                        Quaternion target = new Quaternion();
                        target.SetLookRotation(Vector3.down);
                        laserSelecionado.transform.rotation = target;
                    }
                    break;
                default:
                    break;
            }
        }

        if (Physics.Raycast(ray, out hit, 100, 1 << 8))
        {
            switch (hit.transform.tag)
            {
                case "Play":
                    
                    break;
                case "ButtonMute":
                    
                    break;
                case "ButtonExit":
                    
                    break;
                case "BookOpen":

                    break;
                case "BookClose":
                    
                    break;
                case "Ingrediente":
                    hit.transform.GetComponent<IngredienteController>().m_detectado = true;
                    break;
                default:
                    break;
            }
        }

        foreach (KeyCode kcode in Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKeyDown(kcode))
            {
                infoText.text = "KeyCode."+kcode.ToString();
            }
        }
    }
}
