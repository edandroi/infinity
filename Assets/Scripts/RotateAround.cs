using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RotateAround : MonoBehaviour
{
    float rotationLeft= 360;
    float rotationsSpeed;

    private void Start()
    {
        rotationsSpeed = Random.Range(1.5f, 2.5f);
    }

    float multiplier = 1;
    public bool faster = false;
    void Update()
    {
        if (faster)
        {
            Debug.Log("faster now");
            multiplier = 90f;
            faster = false;
        }
        
        float rotation=rotationsSpeed*Time.deltaTime * multiplier;
        if (rotationLeft > rotation)
        {
            rotationLeft-=rotation;
        }
        else
        {
            rotation=rotationLeft;
            rotationLeft=0;
        }
        transform.Rotate(0,0,rotation);

        if (multiplier > 1)
        {
            multiplier -= .5f;
        }
    }
}

