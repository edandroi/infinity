using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AudioManager : MonoBehaviour
{
    private AudioSource _audioSource;

    private AudioSource _effects;
    
    private static AudioManager instance;

    public UnityEvent _startMusic;
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

    public bool isPlaying = false;
    private bool turnOnVol = false;
    void Start()
    {
        _audioSource.clip = Resources.Load<AudioClip>("infinity-music-1");
        Debug.Log(_audioSource.clip);
        _audioSource.loop = true;
        _audioSource.volume = 0;
        
        _startMusic.AddListener(startMusic);
    }
    
    void Update()
    {
        if (turnOnVol)
        {
            if (_audioSource.volume < .9f)
            {
                _audioSource.volume = Mathf.Lerp(_audioSource.volume, .6f, .3f * Time.deltaTime);
            }
            else
            {
                turnOnVol = false;
            }

        }
    }
    
    void startMusic()
    {
        _audioSource.Play();
        isPlaying = true;
        turnOnVol = true;
    }
}
