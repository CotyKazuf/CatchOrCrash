using UnityEngine;

public class FruitFall : MonoBehaviour
{
    [SerializeField] private float fallSpeed = 5f;
    [SerializeField] private float destroyY = -4f;
    [SerializeField] private float caughtDestroyY = -2.5f;

    private bool isCaught = false;

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
            Destroy(gameObject);
        }
    }

    public void OnCaught()
    {
        isCaught = true;
    }
}