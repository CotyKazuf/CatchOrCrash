using UnityEngine;

public class LifeSystem : MonoBehaviour
{
    [SerializeField] private GameObject heart1;
    [SerializeField] private GameObject heart2;
    [SerializeField] private GameObject heart3;

    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private FruitSpawner fruitSpawner;

    private ScoreSystem scoreSystem;

    private int lives = 3;

    private void Start()
    {
        gameOverPanel.SetActive(false);
        Time.timeScale = 1f;

        scoreSystem = FindObjectOfType<ScoreSystem>();
    }

    public void LoseLife()
    {
        lives--;

        UpdateHearts();

        if (lives <= 0)
        {
            GameOver();
        }
    }

    public void GainLife()
    {
        if (lives < 3)
        {
            lives++;

            UpdateHearts();
        }
    }

    public int GetLives()
    {
        return lives;
    }

    private void UpdateHearts()
    {
        heart1.SetActive(lives >= 1);
        heart2.SetActive(lives >= 2);
        heart3.SetActive(lives >= 3);
    }

    public void TriggerGameOver()
    {
        GameOver();
    }

    private void GameOver()
    {
        gameOverPanel.SetActive(true);

        if (scoreSystem != null)
        {
            scoreSystem.ShowFinalScore();
        }

        if (fruitSpawner != null)
        {
            fruitSpawner.enabled = false;
        }

        Time.timeScale = 0f;

        Debug.Log("Game Over");
    }
}