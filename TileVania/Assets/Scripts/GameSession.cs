using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSession : MonoBehaviour
{

    [SerializeField] int playerLives = 3;
    [SerializeField] int score = 0;

    [SerializeField] Text playerLivesText;
    [SerializeField] Text playerScoreText;


    private void Awake()
    {
        int numberOfGameSessions = FindObjectsOfType<GameSession>().Length;
        if (numberOfGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        playerLivesText.text = playerLives.ToString();
        playerScoreText.text = score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public  void AddToScore(int adds)
    {
        score+= adds;
        playerScoreText.text = score.ToString();
    }


    public void ProcessPlayerDeath()
    {
        if (playerLives > 1)
        {
            TakeLife();
        }
        else
        {
            ResetGamesession();
        }
    }

    private void ResetGamesession()
    {
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }

    public void TakeLife()
    {
        playerLives--;
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
        playerLivesText.text = playerLives.ToString();
    }

}

