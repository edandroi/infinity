﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using  System.IO;

public class ExploreManager : MonoBehaviour
{
    private string[] exploreItems;
    public TextAsset text;

    public string textNow;

    private TextObject _displayText;

    private float remainingTime;
    public float changeTextTimer;
    void Start()
    {
        _displayText = FindObjectOfType<TextObject>();
        CreateTextArray();
        Debug.Log(exploreItems.Length);
        remainingTime = changeTextTimer;
    }
    
    void Update()
    {
        if (Services.Player.mouseMoving())
        {
            remainingTime -= Time.deltaTime;
            if (remainingTime <= 0)
            {
                changeText = true;
                remainingTime = changeTextTimer;
            }
        }

        if (changeText)
        {
            PickText();
            _displayText.textChanged_Event.Invoke();
            changeText = false;
        }
    }

    void CreateTextArray()
    {
        string _text = text.text;
        exploreItems = _text.Split('\n');
    }

    public bool changeText = false;
    void PickText()
    {
        int i = Random.Range(0, exploreItems.Length);
        textNow = exploreItems[i];
    }

}
