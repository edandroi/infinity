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

public class TextObject : MonoBehaviour, IPointerEnterHandler
{
    private TextMeshProUGUI textObj;
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

        newPos = transform.position;
        
        ChangeText();
    }

    private Vector3 newPos;
    void ChangeText()
    {
        Vector3 particlePos = newPos;
        particleObj.transform.position = newPos;
        textObj.SetText(_exploreManager.textNow);
        newPos = new Vector3(Random.Range(-screenSize.x, screenSize.x) * .8f,
            Random.Range(-screenSize.y, screenSize.y) * .8f);
        _rect.position = Camera.main.WorldToScreenPoint(newPos);
        ParticleShow();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _exploreManager.changeText = true;
    }

    void ParticleShow()
    {
        particles.Play();
    }
}
