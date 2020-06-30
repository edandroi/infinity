using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteAnimation : MonoBehaviour
{
    public float aniTime = 0.1f;

    float aniTimer;
    
    private Image _image;
    
    void Start()
    {
        _image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        Animation();
    }
    
    public Sprite[] sprites;
    private int i = 0;
    void Animation()
    {
        aniTimer -= Time.deltaTime;

        if (aniTimer < 0)
        {
            i++;       
            if (i > sprites.Length-1)
            {
                i = 0;
            }             
            aniTimer = aniTime;
        }
        
        _image.sprite = sprites[i];
    }
}
