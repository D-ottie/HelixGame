using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{
    public static bool gameOver;
    public static bool levelComplete;
    public static bool mute;
    public static bool isGameStarted;

    public static int score;
    public static int highScore;

    public static int currentLevelIndex;
    public static int numberOfPassedRings;

    public GameObject gameOverPanel;
    public GameObject levelCompletePanel;
    public GameObject gamePlayPanel;
    public GameObject startMenuPanel;

    public TextMeshProUGUI currentLevelText;
    public TextMeshProUGUI nextLevelText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    public Slider gameProgressSlider;
    public int randomAdShow;


    

    //Declare public variables first before game begins
    void Awake() 
    {
        currentLevelIndex = PlayerPrefs.GetInt("CurrentLevelIndex", 1);
    }

    //WE initialize the static variables that we want to change when we begin a new scene
    void Start()
    {
        Time.timeScale = 1;
        numberOfPassedRings = 0;
        isGameStarted = gameOver = levelComplete = false;
        highScoreText.text = "High Score\n" + PlayerPrefs.GetInt("HighScore", 0);
        gameOverPanel.SetActive(false);
        levelCompletePanel.SetActive(false);
        gamePlayPanel.SetActive(false);
        AdManager.instance.RequestInterstitial(); 
        randomAdShow = Random.Range(0,4);
    }

    // Update is called once per frame
    void Update()
    {
        // Update UI
        currentLevelText.text = currentLevelIndex.ToString();
        nextLevelText.text = (currentLevelIndex+1).ToString();

        int progress = numberOfPassedRings * 100 /FindObjectOfType<HelixManager>().numberOfRings;
        gameProgressSlider.value = progress;

        scoreText.text = score.ToString();

        #if UNITY_EDITOR

        if(Input.GetMouseButtonDown(0) && !isGameStarted)
        {
            if(EventSystem.current.IsPointerOverGameObject())
                return;

            isGameStarted = true;
            startMenuPanel.SetActive(false);
            gamePlayPanel.SetActive(true);
        }
        #endif

        #if UNITY_ANDROID
        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && !isGameStarted)
        {
            
            if(EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
                return;

            isGameStarted = true;
            startMenuPanel.SetActive(false);
            gamePlayPanel.SetActive(true);
        }
        #endif

        if(gameOver)
        {
            GameOver();

            //Code Below Checks Whether the player has tapped on the screen, Fire1 works for both PC and phone

            // if(Input.GetButtonDown("Fire1"))
            // {
            //     SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            // }
        }
        if(levelComplete)
        {
            LevelComplete();

            // if(Input.GetButtonDown("Fire1"))
            // {
            //     SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            // }
        }

        if(score > PlayerPrefs.GetInt("HighScore" , 0))
        {
            PlayerPrefs.SetInt("HighScore" , score);
        }
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //PlayerPrefs.SetInt("CurrentLevelIndex", currentLevelIndex + 1);
    }
    public void LoadNextScene()
    {
        PlayerPrefs.SetInt("CurrentLevelIndex", currentLevelIndex + 1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);// +1);
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        gameOverPanel.SetActive(true);
        score = 0;
        PlayerPrefs.SetInt("CurrentLevelIndex" , 1);

        if(randomAdShow == 3)
        {
            AdManager.instance.ShowInterstitial();
        }

    }

    public void LevelComplete()
    {
        //Time.timeScale = 0;
        levelCompletePanel.SetActive(true);
        if(randomAdShow == 3)
        {
            AdManager.instance.ShowInterstitial();
        }
    }


}
