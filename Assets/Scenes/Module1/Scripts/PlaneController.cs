using UnityEngine;

public class PlaneController : MonoBehaviour
{
    public float speed = 10f;      
    public float turnSpeed = 50f;
    void Update()
    {
        // Ðóõ âïåðåä
        transform.position += transform.forward * speed * Time.deltaTime;

        // Ïîâîðîòè ë³òàêà
        if (Input.GetKey(KeyCode.W))
            transform.Rotate(Vector3.right * turnSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.S))
            transform.Rotate(Vector3.left * turnSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.A))
            transform.Rotate(Vector3.up * -turnSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.D))
            transform.Rotate(Vector3.up * turnSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.Q))
            transform.Rotate(Vector3.forward * turnSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.E))
            transform.Rotate(Vector3.back * turnSpeed * Time.deltaTime);
    }
}
