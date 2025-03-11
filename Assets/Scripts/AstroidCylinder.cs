using UnityEngine;

public class AstroidPath : MonoBehaviour
{
    public float radius = 5f; 
    public float speed = 2f;  

    private float time = 0f;
    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position; 
    }

    void Update()
    {
        time += speed * Time.deltaTime;

        float x = radius * Mathf.Pow(Mathf.Cos(time), 3);
        float y = radius * Mathf.Pow(Mathf.Sin(time), 3);

        transform.position = startPosition + new Vector3(x, y, 0);
    }
}
