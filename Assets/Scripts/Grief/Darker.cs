using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Darker : MonoBehaviour
{
    private Color32 targetColor;
    private Color32 _Color;

    private SpriteRenderer _renderer;
    void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
        _Color = _renderer.color;
        targetColor = Camera.main.backgroundColor;
    }
    
    void Update()
    {
        
    }
}
