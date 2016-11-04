using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class PlayerController : MonoBehaviour {

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
            //MuteAudio
            if (hit.transform.tag == "ButtonMute" && Input.GetKeyDown(KeyCode.JoystickButton0))
            {
                AudioMute.singleton.AudioToggle();
            }
            //Book
            if (hit.transform.tag == "Book")
            {
                //Call Function To Open Book
                Debug.Log("BOOK!");
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
