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
    void Start()
    {
        textObj = GetComponent<TextMeshProUGUI>();
        _exploreManager = FindObjectOfType<ExploreManager>();
//        Debug.Log(_exploreManager);
        
        _rect = GetComponent<RectTransform>();
        w = Screen.width;
        h = Screen.height;
        
        screenSize = Camera.main.ScreenToWorldPoint(new Vector3(w, h, 0));
        
        textChanged_Event.AddListener(ChangeText);
        
        ChangeText();
    }

    void ChangeText()
    {
        textObj.SetText(_exploreManager.textNow);
        _rect.position = Camera.main.WorldToScreenPoint(new Vector3(Random.Range(-screenSize.x, screenSize.x)*.8f, Random.Range(-screenSize.y, screenSize.y)*.8f));
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("over now");
        _exploreManager.changeText = true;
    }
}
