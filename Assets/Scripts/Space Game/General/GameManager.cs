using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEditor;

public class GameManager : MonoBehaviour
{
    #region Component
    public List<GameObject> enemyPrefabs;
    //public List<GameObject> healthPrefabs;
    public static GameManager Instance { get; private set; }

    [Header("UI")]
    public TextMeshProUGUI healthCountText;
    public TextMeshProUGUI scoreUpdateText;
    public TextMeshProUGUI highestScoreText;
    public GameObject gameOverPanel;
    public GameObject gamePausedPanel;

    [Header("Game Point")]
    private int healthLeft = 3;
    private int scoreCount = 0;

    [HideInInspector] 
    public bool isGameActive = true;
    private bool isGamePaused;

    /*private float enemySpawnRate = 1.5f;
    private float healthSpawnRate = 5f;*/
    #endregion

    #region Monobehaviour func
    private void Awake() // make sure set awake or else can update isGameActive to true
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            StartGame();
        }
        else
        {
            Destroy(gameObject);
        }

    }

    public void StartGame()
    {
        isGameActive = true;
        StartCoroutine(SpawnEnemy());
        //StartCoroutine(SpawnHealth());
        HealthCount(healthLeft);

        // Get highest score when start game (showed in game over panel)
        highestScoreText.text = PlayerPrefs
            .GetInt("Highest Score Text", 0)
            .ToString(); 
    }
    private void Update()
    {
        GameInput();
    }
    #endregion

    #region Game Flow
    void GameInput()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ChangePaused();
        }
    }

    private void GameOver()
    {
        isGameActive = false;
        gameOverPanel.gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    void ChangePaused()
    {
        if (isGameActive)
        {
            if (!isGamePaused)
            {
                isGamePaused = true;
                gamePausedPanel.SetActive(true);
                Time.timeScale = 0;
            }

            else
            {
                isGamePaused = false;
                gamePausedPanel.SetActive(false);
                Time.timeScale = 1;
            }
        }
        
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1; // make sure when Paused Game and restart game working
    }

    public void QuitGame()
    {
        EditorApplication.isPlaying = false;
    }
    #endregion

    #region Point Count
    public void ScoreCount(int scoreToRecord)
    {
        scoreCount += scoreToRecord;
        scoreUpdateText.text = scoreCount.ToString();

        // check that we have beaten high score yet and make sure it never decrease high score
        if (scoreCount > PlayerPrefs.GetInt("Highest Score Text", 0))
        {
            PlayerPrefs.SetInt("Highest Score Text", scoreCount);
            highestScoreText.text = PlayerPrefs
                .GetInt("Highest Score Text", 0)
                .ToString(); // update high score 

            Debug.Log("is recorded Highest score");
        }

    }
    //Is set up in hierachy
    public void DeleteHighScore()
    {
        PlayerPrefs.DeleteKey("Highest Score Text");
        highestScoreText.text = PlayerPrefs.GetInt("Highest Score Text", 0).ToString();
    }

    public void HealthCount(int healthToChange)
    {
        if (isGameActive)
        {
            int maxHealth = 3;
            healthLeft = Mathf.Clamp(healthLeft + healthToChange, 0, maxHealth);  
            healthCountText.text = "X" + healthLeft;
            if (healthLeft == 0)
            {
                GameOver();
            }
        }
       
    }
    #endregion

    IEnumerator SpawnEnemy()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(3);
            int enemyIndex = Random.Range(0, enemyPrefabs.Count);
            Instantiate(enemyPrefabs[enemyIndex]);
        }
    }

}
