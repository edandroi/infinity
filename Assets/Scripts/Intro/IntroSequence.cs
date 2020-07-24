using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using TMPro;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class IntroSequence : MonoBehaviour
{
    private TextMeshProUGUI textObj;

    public string[] introText;

    private int textNow = 0;

    private ZweigImage zweigs;
    void Start()
    {
        textObj = GetComponent<TextMeshProUGUI>();
        textObj.text = introText[textNow];
        textObj.color = new Color(255, 255, 255, 0);

        timeRemaining = timer;

        zweigs = FindObjectOfType<ZweigImage>();

        Appear();
    }
    
    public float timer = 5f;
    private float timeRemaining;

    private bool moveTxt = false;
    private void FixedUpdate()
    {
        if (timeRemaining <= 0)
        {
            disappear = true;
            Disappear();
        }
        
        if(disappear)
            Disappear();
        
        if (!disappear)
            Appear();
    }

    void Update()
    {
        timeRemaining -= Time.deltaTime;
    }
    
    private float speed = 0;
    void Appear()
    {
        if (textObj.color.a < 1)
        {
            textObj.color = new Color(1, 1, 1, Mathf.Lerp(textObj.color.a, 1, .5f * Time.deltaTime));
        }
    }

    private bool disappear = false;
    public void Disappear()
    {
        if (disappear)
        {
            if (textObj.color.a > 0)
            {
                if (textNow == introText.Length - 1)
                {
                    zweigs.zweigDisappear = true;
                }
                textObj.color = new Color(1, 1, 1, Mathf.Lerp(textObj.color.a, -1, .99f * Time.deltaTime));

                if (zweigs.zweigDisappear)
                {
                    if (textObj.color.a < .1)
                    {
                        Services.GameManager.introDone = true;
                        Services.AudioManager._startMusic.Invoke();
                        Destroy(gameObject);
                    }
                }
            }
            else
            {
                if (textNow == introText.Length - 1)
                {
                    return;
                } 
                textNow++;
                    textObj.text = introText[textNow];
                    timeRemaining = timer;
                    disappear = false;
            }
        }
        
    }
}
