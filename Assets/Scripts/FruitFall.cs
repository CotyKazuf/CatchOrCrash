using UnityEngine;

public class FruitFall : MonoBehaviour
{
    [SerializeField] private float fallSpeed = 5f;
    [SerializeField] private float destroyY = -4f;
    [SerializeField] private float caughtDestroyY = -2.5f;

    private bool isCaught = false;
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

        if (isCaught && transform.position.y <= caughtDestroyY)
        {
            Destroy(gameObject);
        }
        else if (!isCaught && transform.position.y <= destroyY)
        {
            if (lifeSystem != null)
            {
                lifeSystem.LoseLife();
            }

            Destroy(gameObject);
        }
    }

    public void SetSpeed(float speed)
    {
        fallSpeed = speed;
    }

    public void OnCaught()
    {
        isCaught = true;
    }
}