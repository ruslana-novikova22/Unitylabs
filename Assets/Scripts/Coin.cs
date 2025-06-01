using UnityEngine;

public class Coin : MonoBehaviour
{
    public Color coinColor = Color.yellow;     // Колір монети
    public float rotationSpeed = 90f;          // Швидкість обертання

    private void Start()
    {
        Renderer rend = GetComponent<Renderer>();
        if (rend != null)
        {
            rend.material.color = coinColor;
        }
    }

    private void Update()
    {
        // Обертання монети навколо вертикальної осі
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Знайти менеджер і повідомити про збір монети
            CoinManager manager = FindObjectOfType<CoinManager>();
            if (manager != null)
            {
                manager.CollectCoin();
            }

            Destroy(gameObject); // Знищити монету
        }
    }
}
