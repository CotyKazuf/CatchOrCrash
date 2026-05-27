using System.Collections;
using UnityEngine;

public class FruitSpawner : MonoBehaviour
{
    [SerializeField] private GameObject fruitPrefab;
    [SerializeField] private GameObject bombPrefab;
    [SerializeField] private GameObject lifePrefab;

    [SerializeField] private float spawnInterval = 2f;

    [SerializeField] private float minX = -8f;
    [SerializeField] private float maxX = 8f;
    [SerializeField] private float spawnY = 5f;

    [SerializeField] private float bombChance = 0.2f;
    [SerializeField] private float lifeChance = 0.08f;

    [SerializeField] private LifeSystem lifeSystem;

    [Header("Progressive Difficulty")]
    [SerializeField] private float currentFallSpeed = 5f;
    [SerializeField] private float maxFallSpeed = 10f;

    [SerializeField] private float minSpawnInterval = 0.7f;

    [SerializeField] private float difficultyIncreaseTime = 10f;
    [SerializeField] private float fallSpeedIncrease = 0.5f;
    [SerializeField] private float spawnIntervalDecrease = 0.2f;

    [Header("Basket Difficulty")]
    [SerializeField] private BasketController basketController;

    [SerializeField] private float currentBasketSpeed = 5f;
    [SerializeField] private float maxBasketSpeed = 9f;
    [SerializeField] private float basketSpeedIncrease = 0.3f;

    private void Start()
    {
        StartCoroutine(SpawnObjects());
        StartCoroutine(IncreaseDifficulty());

        if (basketController != null)
        {
            basketController.SetSpeed(currentBasketSpeed);
        }
    }

    private IEnumerator SpawnObjects()
    {
        while (true)
        {
            float randomX = Random.Range(minX, maxX);

            Vector3 spawnPosition = new Vector3(randomX, spawnY, 0f);

            float randomValue = Random.Range(0f, 1f);

            bool canSpawnLife = false;

            if (lifeSystem != null)
            {
                canSpawnLife = lifeSystem.GetLives() < 3;
            }

            if (canSpawnLife && randomValue < lifeChance)
            {
                Instantiate(lifePrefab, spawnPosition, Quaternion.identity);
            }
            else if (randomValue < bombChance)
            {
                Instantiate(bombPrefab, spawnPosition, Quaternion.identity);
            }
            else
            {
                GameObject fruit = Instantiate(fruitPrefab, spawnPosition, Quaternion.identity);

                FruitFall fruitFall = fruit.GetComponent<FruitFall>();

                if (fruitFall != null)
                {
                    fruitFall.SetSpeed(currentFallSpeed);
                }
            }

            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private IEnumerator IncreaseDifficulty()
    {
        while (true)
        {
            yield return new WaitForSeconds(difficultyIncreaseTime);

            currentFallSpeed += fallSpeedIncrease;
            spawnInterval -= spawnIntervalDecrease;

            currentFallSpeed = Mathf.Min(currentFallSpeed, maxFallSpeed);
            spawnInterval = Mathf.Max(spawnInterval, minSpawnInterval);

            currentBasketSpeed += basketSpeedIncrease;
            currentBasketSpeed = Mathf.Min(currentBasketSpeed, maxBasketSpeed);

            if (basketController != null)
            {
                basketController.SetSpeed(currentBasketSpeed);
            }
        }
    }
}