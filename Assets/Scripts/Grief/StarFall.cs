using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class StarFall : MonoBehaviour
{
    private Rigidbody2D rb;

    public GameObject person;

    private Darker _darker;
    private SkyManager _skyManager;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;

        Collider2D col1 = GetComponent<Collider2D>();
        Collider2D col2 = person.GetComponent<Collider2D>();
        
        Debug.Log(col2);

        if (col1.IsTouching(col2))
        {
            Debug.Log("touching now");
            Vector3 screenSize = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
            Vector3 spawnPos = new Vector3(Random.Range(-screenSize.x, screenSize.x) * .9f,
                Random.Range(-screenSize.y * .7f, screenSize.y) * .9f, 0);
            transform.position = spawnPos;
        }

        _skyManager = FindObjectOfType<SkyManager>();

        // the image that gets darker as we lose stars
        _darker = FindObjectOfType<Darker>();
    }


    private bool touched = false;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!touched)
        {
            if (other.gameObject.name == "NoZone")
            {
                Vector3 screenSize = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
                Vector3 spawnPos = new Vector3(Random.Range(-screenSize.x, screenSize.x) * .9f,
                    Random.Range(-screenSize.y * .7f, screenSize.y) * .9f, 0);
                transform.position = spawnPos;
            }
            // drop stars as you touch them
            if (other.gameObject.CompareTag("Player"))
            {
                rb.gravityScale = 1;
                _darker.darker_Event.Invoke();
                _skyManager.FallenStars(gameObject);
                touched = true;
            }
        }

    }
}
