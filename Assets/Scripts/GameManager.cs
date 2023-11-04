using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private GameObject pauseScreenObject;
    private GameObject scoreTextObject;
    private GameObject initialTextObject;
    [SerializeField] public TMP_Text scoreText;

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
        Time.timeScale = 0;
        pauseScreenObject = GameObject.FindGameObjectWithTag("PauseScreenObject");
        scoreTextObject = GameObject.FindGameObjectWithTag("ScoreTextObject");
        initialTextObject = GameObject.FindGameObjectWithTag("InitialTextObject");
        scoreTextObject.SetActive(false);
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
            pauseScreenObject.SetActive(false);
            scoreTextObject.SetActive(true);
            initialTextObject.SetActive(false);
            Time.timeScale = 1;
        }
        // if player presses escape, pause game
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 0)
            {
                Time.timeScale = 1;
                pauseScreenObject.SetActive(false);
            }            
            else
            {
                Time.timeScale = 0;
                pauseScreenObject.SetActive(true);
            }
        }
        // score text with 2 decimal places
        scoreText.text = playerScore.ToString("F2");
    }

    void StartGame()
    {
        SceneManager.LoadScene("Game");
    }
}
