using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light : MonoBehaviour
{
    public float timer = 1f;
    private float timerStore;
    private SpriteRenderer m_SpriteRenderer;
    private Color m_Color;
    void Start()
    {
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        m_Color = m_SpriteRenderer.color;
        timerStore = timer;
        originalScale = transform.localScale.x;
    }

    private float originalScale;
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer < 0)
        {
            float scaler = Random.Range(originalScale - 2f, originalScale );
            transform.localScale= new Vector3(scaler, scaler, 1);
//            m_Color.a = Random.Range(.5f, .8f);
//            m_SpriteRenderer.color = m_Color;
//            m_Color = m_SpriteRenderer.color;
            timer = timerStore;
        }
    }
}
