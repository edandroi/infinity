using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.LWRP;
using UnityEngine.Rendering.Universal;

public class Reveal : MonoBehaviour
{
    private Bloom _bloom;

    private Volume vol;

   // private float val;
    void Start()
    {
        vol = GetComponent<Volume>();

        vol.weight = 1;
    }
    
    void Update()
    {
        if (vol.weight > .15f)
        {
            vol.weight = Mathf.Lerp(vol.weight, .15f,  Mathf.Sin(vol.weight) * Time.deltaTime );
        }
    }
}
