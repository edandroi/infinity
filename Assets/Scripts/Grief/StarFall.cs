using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarFall : MonoBehaviour
{
    private Rigidbody2D rb;

    private Darker _darker;
    private SkyManager _skyManager;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;

        _skyManager = FindObjectOfType<SkyManager>();
        
        // the image that gets darker as we lose stars
        _darker = FindObjectOfType<Darker>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private bool touched = false;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!touched)
        {
            // drop stars as you touch them
            if (other.gameObject.CompareTag("Player"))
            {
                rb.gravityScale = 1;
                _darker.darker_Event.Invoke();
                _skyManager.FallenStars(gameObject);
            }

            touched = true;
        }

    }
}
