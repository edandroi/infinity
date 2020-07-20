using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public bool nextScene = false;
    
    public static GameManager instance;

    public bool introDone = false;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    void Update()
    {
        if (nextScene)
        {
            StartCoroutine(NextScene(2.4f));
        }
    }
    
    IEnumerator NextScene(float seconds)
    {
        yield return new WaitForSecondsRealtime(seconds);
        SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex + 1);
        yield return nextScene = false;
    }
}
