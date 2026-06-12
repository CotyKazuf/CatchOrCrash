using UnityEngine;

public class BombFall : MonoBehaviour
{
    [SerializeField] private float fallSpeed = 5f;
    [SerializeField] private float destroyY = -4f;

    private LifeSystem lifeSystem;
    private AudioManager audioManager;

    private bool lose = false;

    private void Start()
    {
        lifeSystem = FindObjectOfType<LifeSystem>();
        audioManager = FindObjectOfType<AudioManager>();
    }

    private void Update()
    {
        if (lose) return;
        Vector3 position = transform.position;

        position.y -= fallSpeed * Time.deltaTime;

        transform.position = position;

        if (transform.position.y <= destroyY)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        BasketCollector basket = collision.GetComponent<BasketCollector>();

        if (basket != null)
        {
            if (audioManager != null)
            {
                audioManager.PlayBomb();
            }

            if (lifeSystem != null)
            {
                Invoke(nameof(TriggerLose), 0.1f);
            }
        }
    }

    private void TriggerLose()
    {
        Debug.Log("lose");
        lifeSystem.TriggerGameOver();

        Destroy(gameObject);
    }
}