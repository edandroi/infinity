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
    
    void Start()
    {
//        var initialCovid = Instantiate(covidObj, Vector3.zero, Quaternion.identity);
//        covidPre = initialCovid.transform;
        _spriteRenderer = GetComponent<SpriteRenderer>();
        Vector3 screenSize = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

        int numOfColumn = (int)(screenSize.x*2 / _spriteRenderer.bounds.max.x);
        int numOfRow = (int)(screenSize.y*2 / _spriteRenderer.bounds.max.y);
        
        /*
        Debug.Log(_spriteRenderer.bounds.max.y);
        Debug.Log(_spriteRenderer.bounds.max.x);
        Debug.Log("rows"+numOfRow);
        Debug.Log("cols"+numOfColumn);
        */
        
        /*
        for (int i = 0; i < numOfRow; i++)
        {
            GameObject newCovid = Instantiate(covidObj);

            if (i == 0)
            {
                newCovid.transform.position = new Vector3(-screenSize.x, screenSize.y,0);
                Debug.Log(-screenSize.x);
            }
            else if (i>0)
            {
                newCovid.transform.position = new Vector3(-screenSize.x + _spriteRenderer.bounds.size.x*i*multiplier, screenSize.y, 0);
            }
        }
        */

        float yPos = screenSize.y;
        float xPos = screenSize.x;
        
        for (int c = 0; c <= Mathf.Abs(numOfColumn); c++)
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
            
            for (int i = 0; i < numOfRow; i++)
            {
                GameObject newCovid = Instantiate(covidObj);

                if (i == 0)
                {
                    newCovid.transform.position = new Vector3(-xPos, yPos,0);
                    Debug.Log(newCovid.transform.position);
                    Debug.Log(-screenSize.x);
                }
                else if (i>0)
                {
                    newCovid.transform.position = new Vector3(-xPos + _spriteRenderer.bounds.size.x*i*multiplier, yPos, 0);
                }
            }

            yPos = yPos - _spriteRenderer.bounds.size.y - .2f;
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
