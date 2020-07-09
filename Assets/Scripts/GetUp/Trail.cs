using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trail : MonoBehaviour
{
    private ParticleSystem _particle;
    
    void Start()
    {
        _particle = GetComponent<ParticleSystem>();
        _particle.enableEmission = false;
    }

    private float priorPos;
    private float currentPos;

    private float xPre;
    private float xNow;
    void Update()
    {
        priorPos = currentPos;
        xPre = xNow;
        transform.position = Services.Player.transform.position + new Vector3(0, -.5f, 0);
        currentPos = transform.position.y;
        xNow = transform.position.x;
        
        if (currentPos > priorPos)
        {
            _particle.enableEmission = true; 
        }
        else
        {
            _particle.enableEmission = false;
        }

        
    }
    
    
}
