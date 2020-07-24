using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Rendering;
using UnityEngine.Rendering.LWRP;

public class RevealGlow : MonoBehaviour
{
    private Bloom _bloom;

    private Volume vol;

    // private float val;
    void Start()
    {
        vol = GetComponent<Volume>();

        vol.weight = 0f;
    }

    private float speed = 4f;
    void Update()
    {
        if (Services.GameManager.introDone)
        {
            if (vol.weight < 1f)
            {
                vol.weight = Mathf.Lerp(vol.weight, 1f,  Time.deltaTime * Mathf.Cos(vol.weight)* 10f);
//            speed *= .8f;
            }
        }
    }
}
