using UnityEngine;

public class BasketCollector : MonoBehaviour
{
    private ScoreSystem scoreSystem;

    private void Start()
    {
        scoreSystem = FindObjectOfType<ScoreSystem>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        FruitFall fruit = other.GetComponent<FruitFall>();

        if (fruit != null)
        {
            fruit.OnCaught();

            if (scoreSystem != null)
            {
                scoreSystem.AddScore();
            }

            Debug.Log("Fruta atrapada");
        }
    }
}