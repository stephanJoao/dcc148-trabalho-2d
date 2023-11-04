using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private GameObject pauseScreenObject;
    private GameObject scoreTextObject;
    private GameObject initialTextObject;
    private GameObject player;

    [SerializeField] public TMP_Text scoreText;
    [SerializeField] List<TextMeshProUGUI> credits;
    private float playerScore;

    [SerializeField] List<Light> gameLights;
    private float distanceToPlayer;

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
        player = GameObject.FindWithTag("Player");
        GetLights();

    }

    public void GetLights()
    {
        gameLights = FindObjectsOfType<Light>().ToList();
    }
    private void LightsHandler()
    {
        foreach (Light light in gameLights)
        {
            distanceToPlayer = Vector3.Distance(light.transform.position, player.transform.position);
            if (distanceToPlayer <= 100f)
            {
                light.gameObject.SetActive(true);
            }
            else
            {
                light.gameObject.SetActive(false);
            }

        }
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
            pauseScreenObject.SetActive(false);
            scoreTextObject.SetActive(true);
            initialTextObject.SetActive(false);
            CreditsHandler();
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
        LightsHandler();
    }

    private void CreditsHandler()
    {
        StartCoroutine(NameAnimationCoroutine());
    }

    IEnumerator NameAnimationCoroutine()
    {
        yield return new WaitForSeconds(3);

        foreach (var name in credits)
        {
            name.DOFade(1f, 5f);

            yield return new WaitForSeconds(5);
            
            name.DOFade(0f, 3f);

            yield return new WaitForSeconds(5);
        }
    }
}
