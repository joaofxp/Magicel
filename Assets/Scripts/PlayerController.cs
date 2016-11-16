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
        if (Physics.Raycast(ray, out hit) && Input.GetKeyDown(KeyCode.Space))
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
                    hit.transform.GetComponent<Ingrediente>().IngredienteSelecionado();
                    GameObject laserSelecionado = Instantiate(laserSelecionadoPrefab, Vector3.zero, Quaternion.LookRotation(new Vector3 (0,-1,0))) as GameObject;
                    laserSelecionado.transform.SetParent(hit.transform,false);
                    break;
                default:
                    break;
            }
        }

        if (Physics.Raycast(ray, out hit))
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
                    hit.transform.GetComponent<Ingrediente>().m_detectado = true;
                    break;
                default:
                    break;
            }
        }

        //if (Physics.Raycast(ray, out hit))
        //{
        //if (hit.transform.tag == "Teleport" && !coroutineIsRunning)
        //{
        //    StartCoroutine(ChooseIngredient());
        //    StartCoroutine(transform.GetComponentInChildren<LifeBar>().ShowLoader());

        //}
        //else if (hit.transform.tag == "Point")
        //{
        //    Debug.Log(hit.transform.tag);
        //    foreach (GameObject ingredient in points)
        //    {
        //        ingredient.SetActive(false);
        //    }
        //    potionButton.SetActive(false);
        //    potionComplete.SetActive(true);
        //    potionText.text = "1/1";
        //    potionSell.SetActive(true);
        //}
        //else if (hit.transform.tag == "Sell")
        //{
        //    potionComplete.SetActive(false);
        //    endText.SetActive(true);
        //}
        //}
        foreach (KeyCode kcode in Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKeyDown(kcode))
            {
                infoText.text = "KeyCode."+kcode.ToString();
            }
        }
    }
}
