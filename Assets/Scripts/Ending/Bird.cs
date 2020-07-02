using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    private Animator _animator;
    void Start()
    {
        _animator = GetComponent<Animator>();
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
        }
    }
}
