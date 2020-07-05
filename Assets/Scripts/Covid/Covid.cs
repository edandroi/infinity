using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Covid : MonoBehaviour
{
    public GameObject covidObj;

    private SpriteRenderer _spriteRenderer;

    private bool generated = false;
    private Transform covidPre;

    private float multiplier = 1.2f;

    private int touchedObj = 0;
    public int numOfTargetInteraction = 8;
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        Vector3 screenSize = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

        int numOfColumn = (int)(screenSize.y*2 / _spriteRenderer.bounds.max.x);
        int numOfRow = (int)(screenSize.x*2 / _spriteRenderer.bounds.max.y);

        Debug.Log("screensize x is "+ screenSize.x*2);
        Debug.Log(numOfRow);
        
        float yPos = screenSize.y;
        float xPos = screenSize.x;
        
        for (int c = 0; c <= Mathf.Abs(numOfColumn)+1; c++)
        {
            // shift every 2 rows
            float thisRow = c % 2;
            if (thisRow == 0)
            {
                xPos = screenSize.x;
            }
            else
            {
                xPos = screenSize.x + 1.5f;
            }
            
            for (int i = 0; i < Mathf.Abs(numOfRow); i++)
            {
                GameObject newCovid = Instantiate(covidObj);

                if (i == 0)
                {
                    newCovid.transform.position = new Vector3(-xPos, yPos,0);
                }
                else if (i>0)
                {
                    newCovid.transform.position = new Vector3(-xPos + _spriteRenderer.bounds.size.x*i*multiplier, yPos, 0);
                }
            }

            yPos = yPos - _spriteRenderer.bounds.size.y - .2f;
            
        }
    }

    
    void Update()
    {
        if (touchedObj == numOfTargetInteraction)
        {
            Services.GameManager.nextScene = true;
        }
    }

    // count the num of interactions
    public void Touched()
    {
        touchedObj++;
    }
}
