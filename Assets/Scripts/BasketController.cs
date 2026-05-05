using UnityEngine;

public class BasketController : MonoBehaviour
{
    [SerializeField] private float speed = 8f;
    [SerializeField] private float minX = -8f;
    [SerializeField] private float maxX = 8f;

    private void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");

        Vector3 position = transform.position;

        position.x += horizontalInput * speed * Time.deltaTime;

        position.x = Mathf.Clamp(position.x, minX, maxX);

        transform.position = position;
    }
}