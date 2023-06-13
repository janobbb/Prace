using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public bool bulletExist;

    public int score;
    public int minus = -10;
    public int plus = 100;

    private PlayerLives lives;

    public TMP_Text scoreText;
    public TMP_Text livesText;
    public TMP_Text highScore;

    public GameObject[] enemies;

    public int enemiesCount;
    public int endScore;
    float timer = 0;
    public GameObject enemiesPrefab;
    public Transform spawnPos;

    public List<int> gameScores;
   
    private void Start()
    {
        enemiesCount = enemies.Length;
        bulletExist = false;
        score = 0;
        if (PlayerPrefs.HasKey("SavedHighScore"))
        {
            highScore.text = "Hi-Score: " + PlayerPrefs.GetInt("SavedHighScore").ToString();
        }
        else
        {
            highScore.text = "Hi-Score: " + 0.ToString();
        }
        lives = FindObjectOfType<PlayerLives>();
    }
    public void UpdateScore(int points)
    {
        score += points;
        scoreText.text = "Score: " + score;
    }

    private void Update()
    {
        livesText.text = "Lives: " + lives.lives;
        if( lives.lives <= 0)
        {
            endScore = score;
            HighScoreUpdate();
            timer += 1 * Time.deltaTime;
            if(timer >= 2)
            {
                EndGame();    
            } 
        }

        if(enemiesCount <= 0)
        {
            SpawnEnemy();
        }
    }

    private void EndGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void HighScoreUpdate()
    {
        if(PlayerPrefs.HasKey("SavedHighScore"))
        {
            if(endScore > PlayerPrefs.GetInt("SavedHighScore"))
            {
                PlayerPrefs.SetInt("SavedHighScore", endScore);
            }
            else if(endScore < PlayerPrefs.GetInt("SavedHighScore"))
            {
                PlayerPrefs.SetInt("SecondScore", endScore);
            }
        }
        else
        {
            PlayerPrefs.SetInt("SavedHighScore", endScore);
        }
        highScore.text = "Hi-Score: " + PlayerPrefs.GetInt("SavedHighScore").ToString();
    }

    public void SpawnEnemy()
    {
        minus = -10;
        plus = 100;
        Instantiate(enemiesPrefab, spawnPos.position, Quaternion.identity);
        enemiesCount = enemies.Length;
    }
   // public void SaveList()
   // {
       // int counter = 1;
      //  gameScores.Add(PlayerPrefs.GetInt("SavedHighScore"));
      //  PlayerPrefs.SetInt("Wynik"+counter, endScore);
      //  Debug.Log(counter);
      //  counter++;
   // }
}
