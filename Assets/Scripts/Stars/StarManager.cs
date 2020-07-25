using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarManager : MonoBehaviour
{
    public int numOfTotalStars = 30;

    private int starsFound = 0;

    public GameObject starObj;
    
    void Start()
    {
        GenerateStars();
    }

    private bool finalStar = false;
    void Update()
    {
        if (starsFound >= numOfTotalStars)
        {
            if (!finalStar)
            {
                Services.AudioManager.starsCompleted_Event.Invoke();
                finalStar = true;
            }

            Services.GameManager.nextScene = true;
        }
    }

    public void StarFound()
    {
        starsFound++;
    }

    void GenerateStars()
    {
        for (int i = 0; i <= numOfTotalStars; i++)
        {
            Vector3 screenSize = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
            Vector3 spawnPos = new Vector3(Random.Range(-screenSize.x, screenSize.x)* .85f, 
                Random.Range(-screenSize.y, screenSize.y)*.85f, 0);
            Instantiate(starObj, spawnPos,Quaternion.identity);
        }
    }
}
