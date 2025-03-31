using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GlobalStorage.Instance.CollectCoin(); // Виклик методу
            Destroy(gameObject); // Знищуємо монету після збору
        }
    }
}
