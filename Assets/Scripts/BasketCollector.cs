using UnityEngine;

public class BasketCollector : MonoBehaviour
{
    private ScoreSystem scoreSystem;
    private AudioManager audioManager;

    private void Start()
    {
        scoreSystem = FindObjectOfType<ScoreSystem>();
        audioManager = FindObjectOfType<AudioManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        FruitFall fruit = collision.GetComponent<FruitFall>();

        if (fruit != null)
        {
            fruit.OnCaught();

            if (scoreSystem != null)
            {
                scoreSystem.AddScore();
            }

            if (audioManager != null)
            {
                audioManager.PlayFruitCaught();
            }
        }
    }
}