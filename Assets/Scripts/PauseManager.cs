using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject mainMenuPanel;
    [SerializeField] private GameObject pauseButton;

    private void Start()
    {
        pausePanel.SetActive(false);
    }

    public void Pause()
    {
        pausePanel.SetActive(true);

        if (pauseButton != null)
        {
            pauseButton.SetActive(false);
        }

        Time.timeScale = 0f;
    }

    public void Resume()
    {
        pausePanel.SetActive(false);

        if (pauseButton != null)
        {
            pauseButton.SetActive(true);
        }

        Time.timeScale = 1f;
    }

    public void Exit()
    {
        // Restaurar el tiempo antes de recargar la escena
        Time.timeScale = 1f;

        // Reiniciar completamente el juego y volver al menú inicial
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}