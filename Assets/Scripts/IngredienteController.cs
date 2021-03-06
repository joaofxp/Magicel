﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class IngredienteController : MonoBehaviour
{

    public static IngredienteController singleton;
    Renderer m_renderer;
    Color m_mainColor;
    bool m_selecionado;
    public bool m_detectado;
    Rigidbody m_rigidbody;
    public float ingredienteVelocidade = 50;
    Quaternion rotation;
    Vector3 posInicial;
    bool travarRotacao;

    void Awake()
    {
        singleton = this;
        m_renderer = GetComponent<Renderer>();
        m_mainColor = m_renderer.material.color;
        m_rigidbody = GetComponent<Rigidbody>();
        rotation = transform.rotation;
        posInicial = transform.position;
        travarRotacao = false;
    }

    void FixedUpdate()
    {
        if (Input.GetAxisRaw("Vertical") != 0 && m_selecionado)
        {
            //m_rigidbody.velocity = new Vector3(0, 0, Input.GetAxis("Vertical") * Time.deltaTime * ingredienteVelocidade);
            //transform.position = transform.position + Camera.main.transform.forward * Time.deltaTime * Input.GetAxis("Vertical");
            m_rigidbody.position = transform.position + Camera.main.transform.forward * Time.deltaTime * Input.GetAxis("Vertical");
        }
    }

    void LateUpdate()
    {
        if (m_detectado)
        {
            print(m_rigidbody.velocity);
            Invoke("DesativarDeteccao", 1);
        }
        else if (m_selecionado && Input.GetButtonDown("Submit"))
        {
            SelecaoDesativar();
        }

        if (travarRotacao)
        {
            transform.rotation = rotation;
            m_rigidbody.velocity = Vector3.zero;
        }
    }

    public void IngredienteSelecionado()
    {
        if (!m_selecionado)
        {
            SelecaoAtivar();
        }
        else
        {
            SelecaoDesativar();
        }
    }

    public void DesativarDeteccao()
    {
        m_detectado = false;
    }

    public void SelecaoAtivar()
    {
        travarRotacao = true;
        m_renderer.material.color = Color.green;
        transform.SetParent(Camera.main.transform);
        m_rigidbody.useGravity = false;
        m_rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
        m_selecionado = true;
    }

    public void SelecaoDesativar()
    {
        travarRotacao = false;
        m_renderer.material.color = m_mainColor;
        transform.SetParent(null);
        m_rigidbody.useGravity = true;
        m_rigidbody.constraints = RigidbodyConstraints.None;
        m_selecionado = false;
        Destroy(transform.GetChild(0).gameObject);
    }

    //COROUTINES
    public IEnumerator IngredienteNoCaldeirao()
    {
        if (transform.parent != null)
        {
            SelecaoDesativar();
        }
        ParticleSystemExtension.SetEmissionRate(CaldeiraoScript.singleton.GetComponent<ParticleSystem>(), ParticleSystemExtension.GetEmissionRate(CaldeiraoScript.singleton.GetComponent<ParticleSystem>()) + 20f);
        yield return new WaitForSeconds(2);
        Renderer m_renderer = GetComponent<Renderer>();
        while (m_renderer.material.color.a >= 0)
        {
            m_renderer.material.color -= new Color(0, 0, 0, 0.25f);
            yield return new WaitForSeconds(0.25f * Time.deltaTime);
        }
        transform.rotation = rotation;
        transform.position = posInicial;
        yield return new WaitForSeconds(1);
        while (m_renderer.material.color.a <= 1)
        {
            m_renderer.material.color += new Color(0, 0, 0, 0.1f);
            yield return new WaitForSeconds(0.5f * Time.deltaTime);
        }
        //m_renderer.material.color += new Color(0, 0, 0, 1);
        yield return null;
    }
}
