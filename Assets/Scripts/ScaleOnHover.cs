using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleOnHover : MonoBehaviour
{
    private Vector3 originalScale;
    private float scaleFactor = 1.3f;
    bool scaleBack = false;
    void Start()
    {
        originalScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (scaleBack)
        {
            ScaleBack(.25f);

            if (transform.localScale == originalScale)
            {
                scaleBack = false;
            }
        }
    }
    
    
    void ScaleObj(float scaler, float speed)
    {
        Vector3 targetScale = new Vector3(scaler, scaler, 0);
        if (transform.localScale != targetScale)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, targetScale, speed);
        }
    }

    void ScaleBack(float speed)
    {
        Vector3 targetScale = originalScale;
        if (transform.localScale != targetScale)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, targetScale, speed);
        }
    }
    
    
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ScaleObj(scaleFactor, .15f);
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            scaleBack = true;
        }  
    }
}
