using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private float playerScore;
    
    // Start is called before the first frame update
    void Start()
    {         
        if (instance == null)
        {
            instance = this; // this refers to the current instance of the class
        }
        else
        {
            Destroy(gameObject);
        }

        playerScore = 0;
    }

    public float GetPlayerScore()
    {
        return playerScore;
    }
    public void AddScore(float score)
    {
        playerScore += score;
        playerScore = Mathf.Clamp(playerScore, 0, Mathf.Infinity);
    }

    public void Update()
    {
        // if player presses space, start game
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartGame();
        }
        // if player presses escape, pause game
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(Time.timeScale == 0)
                Time.timeScale = 1;
            else
                Time.timeScale = 0;        
        }
    }

    void StartGame()
    {
        SceneManager.LoadScene("Game");
    }
}
