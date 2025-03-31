using UnityEngine;

public class Trap : MonoBehaviour
{
    public float speed = 2f; // �������� ����
    public float distance = 3f; // �������� ����
    public Vector3 moveDirection = Vector3.right; // ������ ���� (�� ������������� ����-������)

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
        Debug.Log("Trap.cs ����������!");
    }

    void Update()
    {
        // ��� ������ �� ���������
        float movement = Mathf.Sin(Time.time * speed) * distance;
        transform.position = startPosition + moveDirection * movement;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("��'��� ������ � ������: " + other.gameObject.name);

        if (other.CompareTag("Player"))
        {
            Debug.Log("������� �������� � ������!");
            GlobalStorage.Instance.TakeDamage();
        }
    }

    public void ResetTrap()
    {
        gameObject.SetActive(true);
    }
}
