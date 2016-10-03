using UnityEngine;
using System.Collections;

public class LifeBar : MonoBehaviour {

    public static float Cutoff;

    public void FixedUpdate()
    {
        transform.LookAt(MoveToPoint.playerPosition);
    }

    public IEnumerator ShowLoader()
    {
        yield return new WaitForSeconds(1);
        Cutoff = GetComponent<Renderer>().material.GetFloat("_Cutoff");
        float f = 1;
        do
        {
            f -= 0.015f;
            GetComponent<Renderer>().material.SetFloat("_Cutoff", f);
            yield return new WaitForFixedUpdate();
            Cutoff = GetComponent<Renderer>().material.GetFloat("_Cutoff");
        } while (Cutoff > 0.015f);
        GetComponent<Renderer>().material.SetFloat("_Cutoff", 0.0005f);
        yield return new WaitForSeconds (0.5f);
        GetComponent<Renderer>().material.SetFloat("_Cutoff", 1);
        yield return null;
    }
}
