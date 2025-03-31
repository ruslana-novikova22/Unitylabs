using UnityEngine;

public class Trap : MonoBehaviour
{
    public float speed = 2f; // Швидкість руху
    public float distance = 3f; // Дальність руху
    public Vector3 moveDirection = Vector3.right; // Напрям руху (за замовчуванням вліво-вправо)

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
        Debug.Log("Trap.cs запустився!");
    }

    void Update()
    {
        // Рух пастки за синусоїдою
        float movement = Mathf.Sin(Time.time * speed) * distance;
        transform.position = startPosition + moveDirection * movement;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Об'єкт увійшов у пастку: " + other.gameObject.name);

        if (other.CompareTag("Player"))
        {
            Debug.Log("Гравець потрапив у пастку!");
            GlobalStorage.Instance.TakeDamage();
        }
    }

    public void ResetTrap()
    {
        gameObject.SetActive(true);
    }
}
