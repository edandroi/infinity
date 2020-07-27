using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using Random = UnityEngine.Random;

public class GetUp : MonoBehaviour
{
    public Sprite[] sprites;
    private SpriteRenderer _spriteRenderer;

    private Collider2D col;

    private Player _player;

    private Vector3 screenSize;

    private bool mobile = false;
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.sprite = sprites[0];
        _player = FindObjectOfType<Player>();
        col = GetComponent<Collider2D>();
        
        screenSize = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

        // mobil render icin poziyonu degistiricem
        if (Screen.height > Screen.width)
        {
            mobile = true;
            transform.position = new Vector3(screenSize.x/2, -screenSize.y + _spriteRenderer.bounds.size.y/2, 0 );
            transform.localScale *= .7f;
        }
    }

    enum movePos
    {
        bottom,
        up,
        mid,
    }

    private movePos currentPos;
    movePos prePos;

    void Update()
    {
        if (spriteNum == sprites.Length - 1 ) // if we reach the final sprite
        {
            Services.GameManager.nextScene = true;
        }
        
        Debug.Log("next scene is "+Services.GameManager.nextScene);
    }

    public int spriteNum = 0;

    private Vector3 m_Size;
    private Bounds _bounds;
    public void ChangeSprite()
    {
        if (!Services.GameManager.nextScene)
        {
            spriteNum++;
            _spriteRenderer.sprite = sprites[spriteNum];
        }
    }

    public void MoveXPos()
    {
        if (!Services.GameManager.nextScene)
        {
            Vector3 newPos = new Vector3(Random.Range(-transform.position.x - 2f, -transform.position.x + 2f), transform.position.y, 0);
            transform.position = newPos;
        }
    }

    IEnumerator NewPos(float seconds)
    {
        yield return new WaitForSecondsRealtime(seconds);
        ChangeSprite();
        MoveXPos();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (spriteNum < sprites.Length && spriteNum != sprites.Length-1) ;
            {
                StartCoroutine(NewPos(.5f)); 
            }
        }
    }

    private bool started = false;
    void MousePos()
    {
        prePos = currentPos;

        if (_player.transform.position.y < -screenSize.y + 1.5f)
        {
            currentPos = movePos.bottom;
        }else if (_player.transform.position.y > screenSize.y - 1.5f)
        {
            currentPos = movePos.up;
        }
        else
        {
            StartCoroutine(MidState(1.5f));
        }  
        
        if (started)
        {
            if (prePos == movePos.bottom)
            {
                if (currentPos == movePos.up)
                {
                    if (spriteNum < sprites.Length)
                        ChangeSprite();
                }
            }
        }
        else
        {
            if (currentPos == movePos.bottom)
                StartCoroutine(Starting(.5f));
        }
    }
    
    IEnumerator MidState(float seconds)
    {
        yield return new WaitForSecondsRealtime(seconds);
        currentPos = movePos.mid;
    }
    
    IEnumerator Starting(float seconds)
    {
        yield return new WaitForSecondsRealtime(seconds);
        started = true;
    }
}
