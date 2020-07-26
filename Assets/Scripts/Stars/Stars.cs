using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stars : MonoBehaviour
{
    private SpriteRenderer m_SpriteRenderer;
    private Light m_Light;

    private StarManager m_Manager;

    private bool isFound = false;
    
    void Start()
    {
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        m_SpriteRenderer.enabled = false;
        m_Light = GetComponent<Light>();
        m_Light.enabled = false;

        m_Manager = FindObjectOfType<StarManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (!isFound) 
            {
                    m_SpriteRenderer.enabled = true;
                    m_Light.enabled = true;
                    m_Manager.StarFound();
                    Services.AudioManager.starReveal_Event.Invoke();
                    isFound = true;
            }
        }
    }
}
