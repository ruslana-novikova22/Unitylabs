using UnityEngine;

public class RotatingTrap : MonoBehaviour
{
    public float rotationSpeed = 100f; // Швидкість обертання
    public float moveRadius = 3f; // Радіус руху по колу
    public float moveSpeed = 2f; // Швидкість руху по колу

    private Vector3 centerPosition;

    void Start()
    {
        centerPosition = transform.position; // Зберігаємо початкову позицію сфери
    }

    void Update()
    {
        // Обертання сфери навколо її осі (по осі Y)
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);

        // Рух по колу
        float x = centerPosition.x + Mathf.Cos(Time.time * moveSpeed) * moveRadius;
        float z = centerPosition.z + Mathf.Sin(Time.time * moveSpeed) * moveRadius;
        transform.position = new Vector3(x, transform.position.y, z); // Оновлюємо позицію
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Об'єкт увійшов у пастку: " + other.gameObject.name);

        if (other.CompareTag("Player"))
        {
            Debug.Log("Гравець потрапив у обертову пастку!");
            GlobalStorage.Instance.TakeDamage(); // Зменшення життів
        }
    }
}
