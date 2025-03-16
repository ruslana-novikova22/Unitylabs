using UnityEngine;

public class Pendulum : MonoBehaviour
{
    public float swingAngle = 45f;
    public float speed = 2f;

    void Update()
    {
        float angle = Mathf.Sin(Time.time * speed) * swingAngle;
        transform.rotation = Quaternion.Euler(angle, 0, 0);
    }
}