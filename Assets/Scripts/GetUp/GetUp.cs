using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class GetUp : MonoBehaviour
{
    public Sprite[] sprites;
    private SpriteRenderer _spriteRenderer;

    private Player _player;

    private Vector3 screenSize;
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.sprite = sprites[0];
        _player = FindObjectOfType<Player>();
        
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
//        Debug.Log(_player.transform.position.y);
        MousePos();
        Debug.Log(currentPos);
    }

    public int spriteNum = 0;
  
    public void ChangeSprite()
    {
        spriteNum++;
        _spriteRenderer.sprite = sprites[spriteNum];
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
            StartCoroutine(MidState(1f));
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
