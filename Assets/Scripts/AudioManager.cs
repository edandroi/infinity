using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    private AudioSource _audioSource;
    private AudioSource _effects;
    private static AudioManager instance;

    public UnityEvent _startMusic;

    // sound fx for the star fall scene
    public AudioClip[] starFallFX;
    private List<AudioClip> starFalls;
    public UnityEvent starFalling_Event;
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
        _audioSource.loop = true;
        _audioSource.volume = 0;
        
        // for the bg music to start later
        _startMusic.AddListener(startMusic);

        starFalls = new List<AudioClip>();
        for (int i = 0; i < starFallFX.Length; i++)
        {
            starFalls.Add(starFallFX[i]);
        }
        
        starFalling_Event.AddListener(starsFallingFX);
    }
    
    void Update()
    {
        // turn on music at the start
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

    
    // for 04Grief scene, fx when stars are falling
    void starsFallingFX()
    {
        if (starFalls.Count == 0)
        {
            // if our list is empty, we add the same sounds again and use
            for (int s = 0; s < starFallFX.Length; s++)
            {
                starFalls.Add(starFallFX[s]);
            }
        }

        int i = Random.Range(0, starFalls.Count);
        _effects.volume = .7f;
        _effects.PlayOneShot(starFalls[i]);
        starFalls.Remove(starFalls[i]);
    }
}
