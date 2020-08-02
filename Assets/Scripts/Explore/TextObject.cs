using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Random = UnityEngine.Random;

public class TextObject : MonoBehaviour, IPointerEnterHandler
{
    public TextMeshProUGUI textObj;
    private ExploreManager _exploreManager;

    float w;
    private float h;
    private Vector3 screenSize;
    public UnityEvent textChanged_Event;

    public RectTransform _rect;

    private GameObject particleObj;
    private ParticleSystem particles;
    void Start()
    {
        textObj = GetComponent<TextMeshProUGUI>();
        _exploreManager = FindObjectOfType<ExploreManager>();
        particles = FindObjectOfType<ParticleSystem>();
        particleObj = particles.gameObject;
        particles.playOnAwake = false;
        
        
        _rect = GetComponent<RectTransform>();
        w = Screen.width;
        h = Screen.height;
        
        screenSize = Camera.main.ScreenToWorldPoint(new Vector3(w, h, 0));
        
        textChanged_Event.AddListener(ChangeText);

        // for particles to spawn in the correct position, we need to set the position of the text at the start
        newPos = Camera.main.ScreenToWorldPoint(new Vector2(_rect.position.x, _rect.position.y));
        newPos = new Vector3(newPos.x, newPos.y, 90);
        
        textObj.SetText(_exploreManager.textNow);
    }

    private void Update()
    {
        if (playParticles)
        {
            ParticleShow();
        }
    }


    private Vector3 newPos;
    void ChangeText()
    {
        Vector3 formerPos = transform.position;
        CalculateNewScreenPos();

        // if new position is too close to the old one, change again
        if (Mathf.Abs(newPos.x - formerPos.x) > 4f || Mathf.Abs(newPos.y - formerPos.y) > 4f)
        {
            // we tell the manager to pick a new text
            textObj.SetText(_exploreManager.textNow);
            _rect.position = Camera.main.WorldToScreenPoint(newPos);
        }
        else
        {
            CalculateNewScreenPos();
        }

    }

    void CalculateNewScreenPos()
    {
        newPos = new Vector3(Random.Range(-screenSize.x, screenSize.x) * .8f,
            Random.Range(-screenSize.y, screenSize.y) * .8f);

        if (newPos.x < 0)
        {
            newPos.x = Mathf.Clamp(newPos.x, -3, -screenSize.x * .8f);
        }
        else
        {
            newPos.x = Mathf.Clamp(newPos.x, 3, screenSize.x * .8f);
        }

        if (newPos.y < 0)
        {
            newPos.y = Mathf.Clamp(newPos.y, -2, -screenSize.y * .8f);
        }
        else
        {
            newPos.y = Mathf.Clamp(newPos.y, 2, screenSize.x * .8f);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!Services.GameManager.nextScene)
        {
            playParticles = true;
            _exploreManager.changeText = true;   
        }
    }

    private bool playParticles = false;
    void ParticleShow()
    {
        particleObj.transform.position = newPos;
        particles.Play();
        playParticles = false;
    }
}
