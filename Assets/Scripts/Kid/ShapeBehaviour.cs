using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Random = UnityEngine.Random;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class ShapeBehaviour : MonoBehaviour
{
    public GameObject square;
    public GameObject polygon;
    public GameObject triangle;
    public GameObject hexagon;

    public GameObject[] shapes;

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
        else
        {
            Vector3 screenSize = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height -.5f, 0));
            if (screenSize.y > screenSize.x)
            {
                transform.localScale = Vector3.one * screenSize.x * .35f;
                transform.position = Vector3.zero;
            }
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
            generate = true;
        }
    }

    private bool generate = false;
    private float remainingTime = .4f;
    void GenerateShapes()
    {
        remainingTime -= Time.deltaTime;

        if (remainingTime <= 0)
        {
            for (int i = 0; i < 2; i++)
            {
                _shapeManager.GenerateShapes(gameObject);
            }
            
            _shapeManager.RemoveShape(gameObject);
            Destroy(gameObject);
        }
    }
}
