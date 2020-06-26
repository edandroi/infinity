using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Darker : MonoBehaviour
{
    private Color targetColor;
    private Color _Color;

    private SkyManager _skyManager;
    private int numOfStars;

    public  UnityEvent darker_Event = new UnityEvent();
    public  UnityEvent noStars_Event = new UnityEvent();
    
    private SpriteRenderer _renderer;

    public float time;
    void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
        _Color = _renderer.color;
        targetColor = Camera.main.backgroundColor;

        darker_Event.AddListener(GetDarker);
        noStars_Event.AddListener(StarsGone);
        
        _skyManager = FindObjectOfType<SkyManager>();
        numOfStars = _skyManager.numOfTotalStars;
    }
    
    void Update()
    {
        Debug.Log(time);
    }

    private float multiplier = 1.5f;
    void GetDarker()
    {
        if (_renderer.color != targetColor)
        {
            _renderer.color = Color.Lerp(_renderer.color, targetColor, time*multiplier);
            multiplier += .1f;
        }
    }

    void StarsGone()
    {
        _renderer.color = targetColor;
    }
}
