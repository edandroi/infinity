using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public bool nextScene = false;
    void Start()
    {
        
    }
    
    void Update()
    {
        if (nextScene)
        {
            StartCoroutine(NextScene(3));
        }
    }
    
    IEnumerator NextScene(float seconds)
    {
        yield return new WaitForSecondsRealtime(seconds);
        SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex + 1);
        yield return nextScene = false;
    }
}
