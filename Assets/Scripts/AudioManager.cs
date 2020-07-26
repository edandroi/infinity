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
    
    // play when the 01Stars scene is completed
    public UnityEvent starsCompleted_Event;
    private AudioClip starsCompletedSfx;
    
    //02Pi
    public UnityEvent circles_Event;
    private AudioClip circlesSfx;
    
    // 03Kids sfx
    public AudioClip[] shapesSfxArray;
    private List<AudioClip> shapesSfxList;
    public UnityEvent shapesFx_Event;
    

    // sound fx for the star fall scene
    public AudioClip[] starFallArray;
    private List<AudioClip> starFalls;
    public UnityEvent starFalling_Event;
    
    //sound fx for virus scene
    public UnityEvent covid_Event;
    private AudioClip covidSfx1;
    private AudioClip covidSfx2;

    private AudioClip flap1;


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
//        starsCompleted_Event.AddListener(starsCompletedFX);

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
        starFalls = new List<AudioClip>();
        for (int i = 0; i < starFallArray.Length; i++)
        {
            starFalls.Add(starFallArray[i]);
        }
        starFalling_Event.AddListener(starsFallingFX);
        
        //05Covid scene sound effects
        covidSfx1 = Resources.Load<AudioClip>("Sounds/timpaniLow");
//        covidSfx2 = Resources.Load<AudioClip>("Sounds/timpaniRoll");
        covid_Event.AddListener(covidFX);
        
        
        //08Ending sfx
        flap1 = covidSfx1 = Resources.Load<AudioClip>("Sounds/flap3");
        
    }
    
    void Update()
    {
//        Debug.Log("shpaes list "+shapesSfxList.Count);
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

        if (end)
        {
            if (_audioSource.volume > 0)
            {
                _audioSource.volume = Mathf.Lerp(_audioSource.volume, -.5f, .9f * Time.deltaTime);
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
        _effects.volume = .6f;
        _effects.pitch = Random.Range(.8f, 1f);
        _effects.PlayOneShot(shapesSfxList[i]);
        shapesSfxList.Remove(shapesSfxList[i]);
    }
    
    
    public void circlesFx()
    {
        _effects.volume = .7f;
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
    public void starsFallingFX()
    {
        if (starFalls.Count == 0)
        {
            // if our list is empty, we add the same sounds again and use
            for (int s = 0; s < starFallArray.Length; s++)
            {
                starFalls.Add(starFallArray[s]);
            }
        }

        int i = Random.Range(0, starFalls.Count);
        _effects.volume = .4f;
        _effects.PlayOneShot(starFalls[i]);
        starFalls.Remove(starFalls[i]);
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
}
