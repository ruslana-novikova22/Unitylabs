using UnityEngine;

public class MovingTrap : MonoBehaviour
{
    public Vector3 pointA;
    public Vector3 pointB;
    public float speed = 2f;

    private Vector3 direction;
    private bool movingToB = true;

    void Start()
    {
        transform.position = pointA;
        direction = (pointB - pointA).normalized;
    }

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);

        if (movingToB && Vector3.Distance(transform.position, pointB) < 0.1f)
        {
            direction = (pointA - pointB).normalized;
            movingToB = false;
        }
        else if (!movingToB && Vector3.Distance(transform.position, pointA) < 0.1f)
        {
            direction = (pointB - pointA).normalized;
            movingToB = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Об'єкт увійшов у пастку: " + other.gameObject.name);

        if (other.CompareTag("Player"))
        {
            Debug.Log("Гравець потрапив у рухому пастку!");
            GlobalStorage.Instance.TakeDamage();
        }
    }
}
