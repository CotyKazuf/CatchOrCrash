using UnityEngine;

public class BasketCollector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        FruitFall fruit = other.GetComponent<FruitFall>();

        if (fruit != null)
        {
            fruit.OnCaught();
            Debug.Log("Fruta atrapada");
        }
    }
}