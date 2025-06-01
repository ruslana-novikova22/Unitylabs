using UnityEngine;

public class Coin : MonoBehaviour
{
    public Color coinColor = Color.yellow;     // ���� ������
    public float rotationSpeed = 90f;          // �������� ���������

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
        // ��������� ������ ������� ����������� ��
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // ������ �������� � ��������� ��� ��� ������
            CoinManager manager = FindObjectOfType<CoinManager>();
            if (manager != null)
            {
                manager.CollectCoin();
            }

            Destroy(gameObject); // ������� ������
        }
    }
}
