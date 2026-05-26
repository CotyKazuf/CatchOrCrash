using UnityEngine;

public class BasketController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float limitX = 8f;

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");

        Vector3 position = transform.position;

        position.x += horizontal * speed * Time.deltaTime;

        position.x = Mathf.Clamp(position.x, -limitX, limitX);

        transform.position = position;
    }

    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }
}