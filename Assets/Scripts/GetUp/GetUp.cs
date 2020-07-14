﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEditor.SceneManagement;
using UnityEngine;

public class GetUp : MonoBehaviour
{
    public Sprite[] sprites;
    private SpriteRenderer _spriteRenderer;

    private Collider2D col;

    private Player _player;

    private Vector3 screenSize;
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.sprite = sprites[0];
        _player = FindObjectOfType<Player>();
        col = GetComponent<Collider2D>();
        
        screenSize = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
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
//        MousePos();

        if (spriteNum == sprites.Length - 1) // if we reach the final sprite
        {
            Services.GameManager.nextScene = true;
        }
    }

    public int spriteNum = 0;

    private Vector3 m_Size;
    private Bounds _bounds;
    public void ChangeSprite()
    {
        spriteNum++;
        _spriteRenderer.sprite = sprites[spriteNum];
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("now");
        if (other.gameObject.CompareTag("Player"))
        ChangeSprite();
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
