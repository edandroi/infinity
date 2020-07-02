using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.LWRP;
using UnityEngine.Rendering.Universal;

public class Reveal : MonoBehaviour
{
    private Bloom _bloom;
    void Start()
    {
        _bloom = GetComponent<Bloom>();
        _bloom.threshold =new MinFloatParameter(.1f, .1f, false);
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
