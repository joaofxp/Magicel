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

    void Awake()
    {
        singleton = this;
        mainCamera = GetComponent<Camera>();
        Cursor.visible = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.JoystickButton0))
        {
            Debug.Log("Key");
        }

        Ray ray = mainCamera.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit) && Input.GetKeyDown(KeyCode.JoystickButton4))
        {
            switch (hit.transform.tag)
            {
                case "ButtonMute":
                    AudioMute.singleton.AudioToggle();
                    break;
                case "BookOpen":
                    bookImageGameObject.SetActive(true);
                    BookOpen book = hit.transform.GetComponent<BookOpen>();
                    BookImage.singleton.AbrirLivro(book.bookSprite, book.bookTextIngredientes, book.bookTextPreparo);
                    break;
                case "BookClose":
                    bookImageGameObject.SetActive(false);
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
