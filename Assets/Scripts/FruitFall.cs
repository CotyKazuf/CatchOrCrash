using UnityEngine;

public class FruitFall : MonoBehaviour
{
    [SerializeField] private float fallSpeed = 5f;
    [SerializeField] private float destroyY = -4f;

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
}