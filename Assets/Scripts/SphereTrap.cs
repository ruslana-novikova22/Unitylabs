using UnityEngine;

public class RotatingTrap : MonoBehaviour
{
    public float rotationSpeed = 100f; // �������� ���������
    public float moveRadius = 3f; // ����� ���� �� ����
    public float moveSpeed = 2f; // �������� ���� �� ����

    private Vector3 centerPosition;

    void Start()
    {
        centerPosition = transform.position; // �������� ��������� ������� �����
    }

    void Update()
    {
        // ��������� ����� ������� �� �� (�� �� Y)
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);

        // ��� �� ����
        float x = centerPosition.x + Mathf.Cos(Time.time * moveSpeed) * moveRadius;
        float z = centerPosition.z + Mathf.Sin(Time.time * moveSpeed) * moveRadius;
        transform.position = new Vector3(x, transform.position.y, z); // ��������� �������
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("��'��� ������ � ������: " + other.gameObject.name);

        if (other.CompareTag("Player"))
        {
            Debug.Log("������� �������� � �������� ������!");
            GlobalStorage.Instance.TakeDamage(); // ��������� �����
        }
    }
}
