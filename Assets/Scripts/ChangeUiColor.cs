using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ChangeUiColor : MonoBehaviour
{
    Color startColor;
    Color targetColor;

    enum uiObj
    {
        textMeshPro,
        Image
    }

    private uiObj thisObj;
    private TextMeshProUGUI textObj;
    private Image _image;
    void Start()
    {
        startColor = Camera.main.backgroundColor;
        targetColor = Color.white;
        textObj = GetComponent<TextMeshProUGUI>();

        _image = GetComponent<Image>();

        if (textObj != null)
        {
            thisObj = uiObj.textMeshPro;
            textObj.color = startColor;
        }else if (_image != null)
        {
            thisObj = uiObj.Image;
            _image.color = startColor;
        }


    }

    private float speed = 0;
    void Update()
    {
        if (thisObj == uiObj.textMeshPro)
        {
            if (textObj.color != targetColor)
            {
                textObj.color = Color.Lerp(textObj.color, targetColor, Mathf.Cos(speed)* Time.deltaTime);
                speed += .005f;
                speed = Mathf.Clamp(speed, 0, .4f);
            }
        }
        else if (thisObj == uiObj.Image)
        {
            if (_image.color != targetColor)
            {
                _image.color = Color.Lerp(_image.color, targetColor, Mathf.Cos(speed)*Time.deltaTime);
                speed += .005f;
                speed = Mathf.Clamp(speed, 0, .4f);
            }
        }


    }
}
