using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class PlayerController : MonoBehaviour {

    //Acionar o botão de mutar audio ao olhar e clicar
    //Gero um raycast
    //Aperto o botão
    //Chama a função ou clica o botão

    //Componentes
    public Camera mainCamera;

    void Awake()
    {
        mainCamera = GetComponent<Camera>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.JoystickButton0))
        {
            Debug.Log("Key");
        }

        Ray ray = mainCamera.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.tag == "ButtonMute" && Input.GetKeyDown(KeyCode.JoystickButton0))
            {
                //AudioListener.volume = 0;
                AudioMute.singleton.AudioToggle();
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
    }
}
