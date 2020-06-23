using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var go1 = new GameObject { name = "Circle" };
        go1.DrawCircle(1, .02f);
    }

    // Update is called once per frame
    void Update()
    {
        var go1 = new GameObject { name = "Circle" };
        go1.DrawCircle(1, .02f);
    }
}
