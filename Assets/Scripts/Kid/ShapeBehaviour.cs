using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ShapeBehaviour : MonoBehaviour
{
    public GameObject square;
    public GameObject polygon;
    public GameObject triangle;
    public GameObject hexagon;

    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(Random.Range(-1,1),Random.Range(-1,1))*Random.Range(3,10));
    }

    // Update is called once per frame
    void Update()
    {
        if (generate)
            GenerateShapes();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
//            GenerateShapes();
            generate = true;
        }
        else
        {
            Debug.Log("we touch each other");
        }
    }

    private bool generate = false;
    private float remainingTime = .5f;
    void GenerateShapes()
    {
        remainingTime -= Time.deltaTime;

        if (remainingTime <= 0)
        {
            for (int i = 0; i < 3; i++)
            {
                int num = Random.Range(0, 5);
            

                switch (num)
                {
                    case 0:
                        var Shape1 = Instantiate(square);
                        Shape1.transform.localScale = transform.localScale * .8f;
                        break;
                    case 1:
                        var Shape2 = Instantiate(triangle);
                        Shape2.transform.localScale = transform.localScale * .8f;
                        break;
                    case 2:
                        var Shape3 = Instantiate(hexagon);
                        Shape3.transform.localScale = transform.localScale * .8f;
                        break;
                    case 3:
                        var Shape4 = Instantiate(polygon);
                        Shape4.transform.localScale = transform.localScale * .8f;
                        break;
                }

            }
            Destroy(gameObject);
        }
    }
}
