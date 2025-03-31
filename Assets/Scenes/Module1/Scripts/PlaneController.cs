using UnityEngine;

public class PlaneController : MonoBehaviour
{
    public float speed = 10f;      // Швидкість руху вперед
    public float turnSpeed = 50f;  // Швидкість поворотів

    void Update()
    {
        // Рух вперед
        transform.position += transform.forward * speed * Time.deltaTime;

        // Повороти літака
        if (Input.GetKey(KeyCode.W))
            transform.Rotate(Vector3.right * turnSpeed * Time.deltaTime); // Нахил вниз
        if (Input.GetKey(KeyCode.S))
            transform.Rotate(Vector3.left * turnSpeed * Time.deltaTime); // Нахил вгору
        if (Input.GetKey(KeyCode.A))
            transform.Rotate(Vector3.up * -turnSpeed * Time.deltaTime); // Поворот вліво
        if (Input.GetKey(KeyCode.D))
            transform.Rotate(Vector3.up * turnSpeed * Time.deltaTime); // Поворот вправо
        if (Input.GetKey(KeyCode.Q))
            transform.Rotate(Vector3.forward * turnSpeed * Time.deltaTime); // Крен вліво
        if (Input.GetKey(KeyCode.E))
            transform.Rotate(Vector3.back * turnSpeed * Time.deltaTime); // Крен вправо
    }
}
