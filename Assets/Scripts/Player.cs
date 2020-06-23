using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private Collider2D col;
    
    Vector3 lastMouseCoordinate = Vector3.zero;
    
    void Start()
    {
        col = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        
    }

    void CheckMouseMove()
    {
        // First we find out how much it has moved, by comparing it with the stored coordinate.
        Vector3 mouseDelta = Input.mousePosition - lastMouseCoordinate;
 
        // Then we check if it has moved to the left.
        if(mouseDelta.x < 0) // Assuming a negative value is to the left.
            GetComponent<Animation>().Play("WhateverIWant");
        // Then we store our mousePosition so that we can check it again next frame.
        lastMouseCoordinate = Input.mousePosition;
    }
}
