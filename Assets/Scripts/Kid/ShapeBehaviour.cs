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

    public string initial = "no";

    private ShapeManager _shapeManager;

    private Rigidbody2D rb;
    void Start()
    {
        _shapeManager = FindObjectOfType<ShapeManager>();
        if (initial == "no")
        {
            rb = GetComponent<Rigidbody2D>();
            rb.drag = 2;

            int i = Random.Range(0, 4);
            float force = 3f;

            switch (i)
            {
                case 0: 
                    rb.AddForce(new Vector2(.1f,0)*force, ForceMode2D.Impulse);
                    break;
                case 1: 
                    rb.AddForce(new Vector2(.1f* -1,0)*force, ForceMode2D.Impulse);
                    break;
                case 2: 
                    rb.AddForce(new Vector2(0,0.1f)*force, ForceMode2D.Impulse);
                    break;
                case 3: 
                    rb.AddForce(new Vector2(0,.1f * -1)*force, ForceMode2D.Impulse);
                    break;
            }

            StartCoroutine(ChangeDrag(.3f)); 
        }
        
        _shapeManager.AddShape(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (generate)
            GenerateShapes();
    }
    
    IEnumerator ChangeDrag(float seconds)
    {
        yield return new WaitForSecondsRealtime(seconds);
        rb.drag = .3f;
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
    private float remainingTime = .4f;
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
                        var Shape1 = Instantiate(square, transform.position, Quaternion.identity);
                        Shape1.transform.localScale = transform.localScale * .9f;
                        break;
                    case 1:
                        var Shape2 = Instantiate(triangle, transform.position, Quaternion.identity);
                        Shape2.transform.localScale = transform.localScale * .9f;
                        break;
                    case 2:
                        var Shape3 = Instantiate(hexagon, transform.position, Quaternion.identity);
                        Shape3.transform.localScale = transform.localScale * .9f;
                        break;
                    case 3:
                        var Shape4 = Instantiate(polygon, transform.position, Quaternion.identity);
                        Shape4.transform.localScale = transform.localScale * .9f;
                        break;
                }

            }
            _shapeManager.RemoveShape(gameObject);
            Destroy(gameObject);
        }
    }
}
