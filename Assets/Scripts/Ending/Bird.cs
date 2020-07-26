using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    private Animator _animator;
    private SpriteRenderer _renderer;
    void Start()
    {
        _animator = GetComponent<Animator>();
        _renderer = GetComponent<SpriteRenderer>();
        
        Vector3 screenSize = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

        if (screenSize.x < screenSize.y)
        {
            transform.localScale = Vector3.one * screenSize.x / screenSize.y * .4f;
            transform.position = new Vector3(- screenSize.x + _renderer.sprite.bounds.extents.x * .3f, -screenSize.y+  _renderer.sprite.bounds.extents.y * .5f, 0);
        }
    }
    
    void Update()
    {
        if (_animator.GetCurrentAnimatorStateInfo(0).IsName("end"))
        {
            Services.GameManager.nextScene = true;
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _animator.SetBool("isFlying", true);
            Services.AudioManager.flapSfx();
        }
    }
}
