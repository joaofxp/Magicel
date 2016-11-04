using UnityEngine;
using System.Collections;

public class Teste : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        //transform.Rotate(new Vector3 (Input.GetAxis("Vertical") * 100 * Time.deltaTime,0,0));
        GetComponent<Rigidbody>().AddForce(new Vector3(Input.GetAxis("Horizontal") * Time.deltaTime, Input.GetAxisRaw("Fire1") * Time.deltaTime * -3, Input.GetAxis("Vertical") * Time.deltaTime), ForceMode.Impulse);
        if (Input.GetAxisRaw("Fire1") != 0)
        {
            Debug.Log("VERTICAL");
        }
        if (Input.GetKeyDown(KeyCode.JoystickButton5))
        {
            print("Keyx");
        }
	}
}
