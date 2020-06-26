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
        Services.GameManager =this.gameObject.GetComponent<GameManager>();

        // Game Manager
        Services.Player = GameObject.FindWithTag("Player").GetComponent<Player>();
        
        // Audio Manager
        var audioManagerGameObject = new GameObject("AudioManager");
        Services.AudioManager = audioManagerGameObject.AddComponent<AudioManager>();
    }
}
