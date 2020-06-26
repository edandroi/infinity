using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using Vector2 = UnityEngine.Vector2;

public class TextObject : MonoBehaviour
{
    private TextMeshPro textObj;
    private string displayText;
    private ExploreManager _exploreManager;

    float w;
    private float h;
    public UnityEvent textChanged_Event;

    private Rect _rect;
    void Start()
    {
        textObj = GetComponent<TextMeshPro>();
        displayText = textObj.text;
        _exploreManager = FindObjectOfType<ExploreManager>();
        Debug.Log(_exploreManager);
        
        _rect = GetComponent<Rect>();
        w = Screen.width;
        h = Screen.height;
        
        textChanged_Event.AddListener(ChangeText);
    }

    // Update is called once per frame
    void Update()
    {
        displayText = _exploreManager.textNow;
    }

    void ChangeText()
    {
        displayText = _exploreManager.textNow;
        _rect.position = new Vector2(Random.Range(-w, w)*.9f, Random.Range(-h, h)*.9f);
    }
}
