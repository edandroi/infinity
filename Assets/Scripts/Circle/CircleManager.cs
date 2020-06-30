using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class CircleManager : MonoBehaviour
{
    public GameObject circleObj;

    private List<GameObject> circles;

    private Player _Player;
    void Start()
    {
        circles = new List<GameObject>();
        _Player = FindObjectOfType<Player>();
    }
    
    void Update()
    {
        if (_Player.mouseMoving())
        {
            GenerateCircle();
        }

        if (circles.Count >= 30)
        {
            GameManager.instance.nextScene = true;
        }
    }

    public float timer = 100f;
    private float remainingTime;
    void GenerateCircle()
    {
        remainingTime -= Time.deltaTime;

        if (remainingTime <= 0)
        {
            for (int i = 0; i < circles.Count; i++)
            {
//                circles[i].transform.position += new Vector3(0, 0, -.1f);
                circles[i].GetComponent<SpriteRenderer>().sortingOrder -= 1;
                circles[i].transform.localScale *= Random.Range(1.1f , 1.5f);
            }

            var newCircle = Instantiate(circleObj, new Vector3(0, 0, 0), Quaternion.identity);
            Color _Color = new Color(
                Random.Range(0f, 1f), 
                Random.Range(0f, 1f), 
                Random.Range(0f, 1f)
            );
            newCircle.GetComponent<SpriteRenderer>().color = _Color;
            circles.Add(newCircle);
            newCircle.transform.parent = gameObject.transform;
            remainingTime = timer;
        }
    }
}
