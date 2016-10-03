using UnityEngine;
using System.Collections;

public class MoveToPoint : MonoBehaviour
{

    Camera camera;
    public static Transform playerPosition;
    public int WaitTime;
    bool coroutineIsRunning;
    public GameObject[] points;

    void Awake()
    {
        playerPosition = GetComponentInParent<Transform>();
    }

    void Start()
    {
        camera = GetComponent<Camera>();
        points = GameObject.FindGameObjectsWithTag("Teleport");
    }

    void FixedUpdate()
    {
        //transform.parent.position = hit.transform.position;
        Ray ray = camera.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.tag == "Teleport" && !coroutineIsRunning)
            {
                StartCoroutine(ChooseIngredient());
                //StartCoroutine(transform.GetComponentInChildren<LifeBar>().ShowLoader());

            }
            else if (hit.transform.tag == "Point")
            {
                //Debug.Log(hit.transform.tag);
                foreach (GameObject ingredient in points)
                {
                    ingredient.SetActive(false);
                }
            }
        }
    }

    void CheckIngredients()
    {
        int count = 0;
        foreach (GameObject ingredient in points)
        {
            if (ingredient.GetComponent<Renderer>().material.color == Color.green)
            {
                count++;
            }
        }
        Debug.Log(count);
        if (count == 3)
        {
            Debug.Log("SHOWBUTTON");
        }
    }

    IEnumerator ChooseIngredient()
    {
        coroutineIsRunning = true;
        //int countTimes = 0;

        for (int i = 0; i < WaitTime; i++)
        {
            Ray ray = camera.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.tag == "Teleport")
                {
                    hit.transform.GetComponent<Renderer>().material.color = Color.green;
                }
                CheckIngredients();
                yield return null;
            }
                //    if (hit.transform.tag == "Teleport")
                //    {
                //        countTimes++;
                //        Debug.Log(countTimes);
                //        yield return new WaitForSeconds(1);
                //    }
                //    else
                //    {
                //        coroutineIsRunning = false;
                //        yield break;
                //    }
                //}
                //if (countTimes == WaitTime)
                //{
                //transform.position = hit.transform.position;
                //foreach (GameObject point in points)
                //{
                //    point.SetActive(true);
                //}
                //foreach (GameObject point in points)
                //{
                //    if (transform.parent.position == point.transform.position)
                //    {
                //        point.SetActive(false);
                //    }
                //    else
                //    {
                //        point.SetActive(true);
                //    }
                //}
            //}
        }
        coroutineIsRunning = false;
    }
}
