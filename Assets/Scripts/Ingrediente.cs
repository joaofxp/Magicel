using UnityEngine;
using System.Collections;

public class Ingrediente : MonoBehaviour {

    public static Ingrediente singleton;
    Renderer m_renderer;
    Color m_mainColor;
    bool m_selecionado;
    public bool m_detectado;
    Rigidbody m_rigidbody;
    public float ingredienteVelocidade = 50;

    void Awake()
    {
        singleton = this;
        m_renderer = GetComponent<Renderer>();
        m_mainColor = m_renderer.material.color;
        m_rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (Input.GetAxis("Vertical") != 0)
        {
            //m_rigidbody.AddForce(0, 0, Input.GetAxis("Vertical") * Time.deltaTime,ForceMode.VelocityChange);
            m_rigidbody.velocity = new Vector3(0, 0, Input.GetAxis("Vertical") * Time.deltaTime * ingredienteVelocidade);
        }

        
        if (m_detectado)
        {
            m_detectado = false;
        }
        else if(!m_detectado && Input.GetKeyDown(KeyCode.Space))
        {
            m_renderer.material.color = m_mainColor;
            transform.SetParent(null);
            m_rigidbody.useGravity = true;
            m_selecionado = false;
        }

        
    }

    public void IngredienteSelecionado()
    {
        if (!m_selecionado)
        {
            m_renderer.material.color = Color.green;
            transform.SetParent(Camera.main.transform);
            m_rigidbody.useGravity = false;
            m_selecionado = true;
        }
        else
        {
            m_renderer.material.color = m_mainColor;
            transform.SetParent(null);
            m_rigidbody.useGravity = true;
            m_selecionado = false;
        }
    }
}
