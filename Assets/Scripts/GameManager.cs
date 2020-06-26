using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public bool nextScene = false;
    
    public static GameManager instance;
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
//            Debug.Log("next scene called now");
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
