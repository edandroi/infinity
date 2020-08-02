using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using  System.IO;

public class ExploreManager : MonoBehaviour
{
    private string[] exploreItems;
    public TextAsset text;

    public string textNow;

    private TextObject _displayText;

    private float remainingTime;
    private float changeTextTimer = .5f;

    private int counter = 0;
    public int target = 10;

    private List<string> allTextList;
    void Start()
    {
        _displayText = FindObjectOfType<TextObject>();
        CreateTextArray();
        remainingTime = changeTextTimer;
        
        allTextList = new List<string>();
        for (int i = 0; i < exploreItems.Length; i++)
        {
            allTextList.Add(exploreItems[i]);
        }
        PickText();
    }
    
    void Update()
    {
        if (counter < target)
        {
            if (changeText)
            {
                remainingTime -= Time.deltaTime;
                
                if (remainingTime <= 0)
                {
                    PickText();
                    _displayText.textChanged_Event.Invoke();
                    Services.AudioManager.exploreFx();
                    counter++;
                    remainingTime = changeTextTimer;
                    changeText = false;
                }
               
            }   
        }
        else if (counter == target)
        {
//            _displayText.textObj.text = "Explore";
            StartCoroutine(EndText());
            Services.GameManager.nextScene = true;
        }
    }

    IEnumerator EndText()
    {
        yield return new WaitForSeconds(.3f);
        PickText();
        _displayText.textObj.text = textNow;
    }

    void CreateTextArray()
    {
        string _text = text.text;
        exploreItems = _text.Split('\n');
    }

    public bool changeText = false;
    void PickText()
    {
        if (allTextList.Count == 0)
        {
            // if our list is empty, we add the same sounds again and use
            for (int t = 0; t < exploreItems.Length; t++)
            {
                allTextList.Add(exploreItems[t]);
            }
        }
        int i = Random.Range(0, exploreItems.Length);
        textNow = exploreItems[i];
        allTextList.Remove(allTextList[i]);
    }

}
