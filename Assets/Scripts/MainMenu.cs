using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject mainMenuPanel;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private FruitSpawner fruitSpawner;

    private void Start()
    {
        mainMenuPanel.SetActive(true);

        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }

        if (fruitSpawner != null)
        {
            fruitSpawner.enabled = false;
        }

        Time.timeScale = 0f;
    }

    public void StartGame()
    {
        mainMenuPanel.SetActive(false);

        if (fruitSpawner != null)
        {
            fruitSpawner.enabled = true;
        }

        Time.timeScale = 1f;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}