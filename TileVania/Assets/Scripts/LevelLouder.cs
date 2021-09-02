using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLouder : MonoBehaviour
{

    [SerializeField] float levelLoadDelay = 5f;
    
    
    int currentLevelIndex;




    private void Start()
    {
        currentLevelIndex = SceneManager.GetActiveScene().buildIndex;
    }

    public void LoadNextLevel()
    {
        StartCoroutine (LoadLevel());        
    }

    IEnumerator LoadLevel()
    {
        Time.timeScale = 0.4f;
        yield return new WaitForSecondsRealtime(levelLoadDelay);
        Time.timeScale = 1f;
        SceneManager.LoadScene(currentLevelIndex + 1);
    }
}
