using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        _InitializeServices();
    }

    void _InitializeServices()
    {
        Services.GameController = this;	
		
        // Game Manager
        Services.GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        
        // Audio Manager
        var audioManagerGameObject = new GameObject("AudioManager");
        Services.AudioManager = audioManagerGameObject.AddComponent<AudioManager>();
    }
}
