using UnityEngine;
using System.Collections;

public class Teste : MonoBehaviour {

    //Shader mainShader;
    //Shader outlineShader;
    
    void Awake()
    {
        //mainShader = GetComponent<Renderer>().material.shader;
        //outlineShader = Shader.Find("Custom/NewImageEffectShader");
    }
    // Update is called once per frame
	void Update () {
        //GetComponent<Rigidbody>().AddForce(new Vector3(Input.GetAxis("Horizontal") * Time.deltaTime, 0, Input.GetAxis("Vertical") * Time.deltaTime),ForceMode.Impulse);
        //if(Input.GetAxisRaw("Fire2") == 0)
        //{
        //    GetComponent<Rigidbody>().AddForce(0,Input.GetAxisRaw("Fire1") * Time.deltaTime * 5,0,ForceMode.Impulse);
        //    //GetComponent<Renderer>().material.shader = mainShader;
        //}
        //else
        //{
        //    //GetComponent<Renderer>().material.shader = outlineShader;
        //    GetComponent<Rigidbody>().AddForce(0,Input.GetAxisRaw("Fire2") * Time.deltaTime * -5,0,ForceMode.Impulse);
        //}
	}
}
