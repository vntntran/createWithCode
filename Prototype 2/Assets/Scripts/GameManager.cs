using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int score = 0;
    public int lives = 3;
    public Text scoreText;
    public Text livesText;
    public GameObject gameOverText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoreText.text = "Score: " + score;
        livesText.text = "HP: " + lives + "/3";
        gameOverText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addLives(int value)
    {
        lives += value;
        livesText.text = "HP: " + lives + "/3";

        if (lives <= 0)
        {
            Debug.Log("Game Over");
            lives = 0;
            livesText.text = "HP: 0/3";
            gameOverText.SetActive(true);
        }
        Debug.Log("Player Lives: " + lives);
    }

    public void addScore(int value)
    {
        score += value;
        scoreText.text = "Score: " + score * 100;
        Debug.Log("Player Score: " + score);
    }
}
