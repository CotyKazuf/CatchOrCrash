using UnityEngine;

public class BombFall : MonoBehaviour
{
    [SerializeField] private float fallSpeed = 5f;
    [SerializeField] private float destroyY = -4f;

    private LifeSystem lifeSystem;

    private void Start()
    {
        lifeSystem = FindObjectOfType<LifeSystem>();
    }

    private void Update()
    {
        Vector3 position = transform.position;

        position.y -= fallSpeed * Time.deltaTime;

        transform.position = position;

        if (transform.position.y <= destroyY)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Basket"))
        {
            if (lifeSystem != null)
            {
                lifeSystem.TriggerGameOver();
            }

            Destroy(gameObject);
        }
    }
}