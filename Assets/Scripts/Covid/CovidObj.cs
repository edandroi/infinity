using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CovidObj : MonoBehaviour
{
    private Covid _covidManager;
    private RotateAround _rotate;
    void Start()
    {
        _covidManager = FindObjectOfType<Covid>();
        _rotate = GetComponent<RotateAround>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _covidManager.Touched();
            Services.AudioManager.covid_Event.Invoke();
            _rotate.faster = true;
        }
    }
}
