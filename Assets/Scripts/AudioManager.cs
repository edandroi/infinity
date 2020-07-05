using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource _audioSource;

    private AudioSource _effects;
    
    private static AudioManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        
        _audioSource = gameObject.AddComponent<AudioSource>();
        _effects = gameObject.AddComponent<AudioSource>();
    }

    void Start()
    {
        _audioSource.clip = Resources.Load<AudioClip>("infinity_music-1");
        Debug.Log(_audioSource.clip);
//        _audioSource.Play();
        _audioSource.loop = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
