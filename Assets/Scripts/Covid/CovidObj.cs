using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CovidObj : MonoBehaviour
{
    private Covid _covidManager;
    void Start()
    {
        _covidManager = FindObjectOfType<Covid>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _covidManager.Touched();
        }
    }
}
