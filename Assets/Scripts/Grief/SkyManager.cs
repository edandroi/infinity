using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SkyManager : MonoBehaviour
{
    public int numOfTotalStars = 10;

    private int starsFound = 0;

    public GameObject starObj;

    private List<GameObject> fallenStars;

    private Darker _darker;
    
    void Start()
    {
        GenerateStars();
        fallenStars = new List<GameObject>();

        _darker = FindObjectOfType<Darker>();
        _darker.time = 1 / (float)(numOfTotalStars);
    }

    private void Update()
    {
//        Debug.Log("fallen stars num = "+fallenStars.Count);
//        Debug.Log("num of generated stars "+numOfTotalStars);
        if (fallenStars.Count == numOfTotalStars)
        {
            _darker.noStars_Event.Invoke();
            Services.GameManager.nextScene = true;
        }
    }

    void GenerateStars()
    {
        for (int i = 0; i < numOfTotalStars; i++)
        {
            Vector3 screenSize = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
            Vector3 spawnPos = new Vector3(Random.Range(-screenSize.x, screenSize.x)* .9f, 
                Random.Range(-screenSize.y*.7f, screenSize.y)*.9f, 0);
            Instantiate(starObj, spawnPos,Quaternion.identity);
        }
    }

    public void FallenStars(GameObject obj)
    {
        fallenStars.Add(obj);
    }
}
