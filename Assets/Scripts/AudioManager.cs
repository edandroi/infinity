﻿using System;
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
    
    // play when the 01Stars scene is completed
    public UnityEvent starsCompleted_Event;
    private AudioClip starsCompletedSfx;
    public AudioClip[] starRevealArray;
    private List<AudioClip> starsRevealList;
    public UnityEvent starReveal_Event;
    
    //02Pi
    public UnityEvent circles_Event;
    private AudioClip circlesSfx;
    
    // 03Kids sfx
    public AudioClip[] shapesSfxArray;
    private List<AudioClip> shapesSfxList;
    public UnityEvent shapesFx_Event;
    

    // 04Grief
    public UnityEvent starFall_Event;
    private AudioClip starFallSfx;
    
    //sound fx for virus scene
    public UnityEvent covid_Event;
    private AudioClip covidSfx1;
    private AudioClip covidSfx2;
    
    //06Explore sfx
    private AudioClip exploreSfx1;
    private AudioClip[] exploreSfxArray = new AudioClip[7];
    private List<AudioClip> exploreList;
    
    //09Ending sfx
    private AudioClip creditsFx;

    private AudioClip flap1;

    public UnityEvent run_Event;
    private AudioClip footstepSfx;
    private AudioClip runSfx;
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
        
        //01Stars scene sfx
        starsCompletedSfx = Resources.Load<AudioClip>("Sounds/zil2");
        starsCompleted_Event.AddListener(starsCompletedFX);
        
        starsRevealList = new List<AudioClip>();
        for (int i = 0; i < starRevealArray.Length; i++)
        {
            starsRevealList.Add(starRevealArray[i]);
        }
        starReveal_Event.AddListener(starsReveal);

        //02Pi scene sfx
        circlesSfx = Resources.Load<AudioClip>("Sounds/pop");
        circles_Event.AddListener(circlesFx);
        
        // 03Kids scene sfx
        shapesSfxList = new List<AudioClip>();
        for (int i = 0; i < shapesSfxArray.Length; i++)
        {
            shapesSfxList.Add(shapesSfxArray[i]);
        }
        shapesFx_Event.AddListener(shapesSfx);
        
        // 04Grief scene sound fx
        starFallSfx = null;
        starFall_Event.AddListener(starsFalling);
        
        //05Covid scene sound effects
        covidSfx1 = Resources.Load<AudioClip>("Sounds/timpaniLow");
//        covidSfx2 = Resources.Load<AudioClip>("Sounds/timpaniRoll");
        covid_Event.AddListener(covidFX);
        
        //06Explore Sfx
        exploreSfx1 = Resources.Load<AudioClip>("Sounds/xlo1");

        foreach (AudioClip audio in exploreSfxArray)
        {
            for (int i = 0; i < exploreSfxArray.Length; i++)
            {
                int num = i + 1;
                exploreSfxArray[i] = Resources.Load<AudioClip>("Sounds/xlo"+ num);
            }
        }

        exploreList = new List<AudioClip>();
        for (int i = 0; i < exploreSfxArray.Length; i++)
        {
            exploreList.Add(exploreSfxArray[i]);
        }
        
        //07GetUp
        footstepSfx =  Resources.Load<AudioClip>("Sounds/footstep1");
        runSfx = Resources.Load<AudioClip>("Sounds/run1");
        run_Event.AddListener(runFx);
        
        //08Ending sfx
        flap1 = Resources.Load<AudioClip>("Sounds/flap4");
        
        //09Credits sfx
        creditsFx = Resources.Load<AudioClip>("Sounds/cin2");
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

        // if we are on a scene and there is no music on the bg
        if (!isPlaying)
        {
            if (SceneManager.GetActiveScene().name != "00Title")
            {
                _startMusic.Invoke();
            }
        }

        // turn down the vol at the end
        if (end)
        {
            if (_audioSource.volume > 0)
            {
                _audioSource.volume = Mathf.Lerp(_audioSource.volume, -.5f, .9f * Time.deltaTime);
            }
        }
        
        if (SceneManager.GetActiveScene().name == "09Credits")
        {
            if (end)
            {
                _audioSource.clip = creditsFx;
                _audioSource.pitch = -.1f;
                _audioSource.loop = true;
                _audioSource.Play();
                end = false;
            }
            
            if (_audioSource.volume < .5f)
            {
                _audioSource.volume = Mathf.Lerp(_audioSource.volume, .4f, .05f * Time.deltaTime);
            }
        }
    }

    void startMusic()
    {
        _audioSource.Play();
        isPlaying = true;
        _audioSource.loop = true;
        turnOnVol = true;
    }

    public bool reload = false;
    public void shapesSfx()
    {
        if (shapesSfxList.Count == 0)
        {
            // if our list is empty, we add the same sounds again and use
            for (int s = 0; s < shapesSfxArray.Length; s++)
            {
                shapesSfxList.Add(shapesSfxArray[s]);
            }
        }

        int i = Random.Range(0, shapesSfxList.Count);
        _effects.volume = .5f;
        _effects.pitch = Random.Range(.8f, 1f);
        _effects.PlayOneShot(shapesSfxList[i]);
        shapesSfxList.Remove(shapesSfxList[i]);
    }
    
    
    public void circlesFx()
    {
        _effects.volume = .5f;
        _effects.pitch = Random.Range(.6f, .9f);
        _effects.PlayOneShot(circlesSfx);
    }

    public void covidFX()
    {
        _effects.volume = .9f;
        _effects.pitch = Random.Range(.82f, .92f);
        _effects.PlayOneShot(covidSfx1);
    }

    // for 04Grief scene, fx when stars are falling
    public void starsReveal()
    {
        if (starsRevealList.Count == 0)
        {
            // if our list is empty, we add the same sounds again and use
            for (int s = 0; s < starRevealArray.Length; s++)
            {
                starsRevealList.Add(starRevealArray[s]);
            }
        }

        int i = Random.Range(0, starsRevealList.Count);
        _effects.volume = .4f;
        _effects.PlayOneShot(starsRevealList[i]);
        starsRevealList.Remove(starsRevealList[i]);
    }

    // This is not in use anymore
    public void starsFalling()
    {
        _effects.volume = 1f;
        _effects.pitch = Random.Range(.85f, 1.1f);
        _effects.PlayOneShot(starFallSfx);
    }

    public void starsCompletedFX()
    {
        _effects.volume = .5f;
        _effects.PlayOneShot(starsCompletedSfx);
        _effects.loop = true;
    }

    private bool end = false;
    public void flapSfx()
    {
        end = true;
        _effects.volume = 1f;
        _effects.PlayOneShot(flap1);
    }

    public void footstepFx()
    {
        _effects.volume = .2f;
        _effects.PlayOneShot(footstepSfx);
    }
    
    public void runFx()
    {
        _effects.volume = .2f;
        _effects.PlayOneShot(runSfx);
    }

    public void exploreFx()
    {
        if (exploreList.Count == 0)
        {
            // if our list is empty, we add the same sounds again and use
            for (int s = 0; s < exploreSfxArray.Length; s++)
            {
                exploreList.Add(exploreSfxArray[s]);
            }
        }

        int i = Random.Range(0, exploreList.Count);
        _effects.volume = .4f;
        _effects.PlayOneShot(exploreList[i]);
        exploreList.Remove(exploreList[i]);
    }
}
