using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZweigImage : MonoBehaviour
{
    private Image imageObj;

    public bool zweigDisappear = false;
    void Start()
    {
        imageObj = GetComponent<Image>();
    }

    void Update()
    {
        if (zweigDisappear)
        {
            if (imageObj.color.a > 0)
            {
                imageObj.color = new Color(1, 1, 1, Mathf.Lerp(imageObj.color.a, 0, 1f * Time.deltaTime));
            }
        }
    }
}
