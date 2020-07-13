using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class AppearAniUi : MonoBehaviour
{
    private TextMeshProUGUI textObj;
    private Image imageObj;

    // 0 is text
    // 1 is image
    private int uiType = 0;
    void Start()
    {
        textObj = GetComponent<TextMeshProUGUI>();
        imageObj = GetComponent<Image>();
        
        if (textObj != null) // text
        {
            uiType = 0;
            textObj.color = new Color(255, 255, 255, 0);
        }
        else
        {
            if (imageObj != null) // image
            {
                uiType = 1;
                imageObj.color = new Color(255, 255, 255, 0);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (uiType == 0)
        {
            AppearText();
        }
        else if (uiType == 1)
        {
            AppearImage();
        }
    }
    
    void AppearText()
    {
        if (textObj.color.a < 252)
        {
            textObj.color = new Color(1, 1, 1, Mathf.Lerp(textObj.color.a, 1, .1f * Time.deltaTime));
        }
    }
    
    void AppearImage()
    {
        if (imageObj.color.a < 252)
        {
            imageObj.color = new Color(1, 1, 1, Mathf.Lerp(imageObj.color.a, 1, .1f * Time.deltaTime));
        }
    }
}
