using UnityEngine;

public class LevelTimer : MonoBehaviour
{
    private bool isGameOver = false; // ����������, �� ��� ��� ���������

    void Update()
    {
        // ���� ��� �� �� ���������, �������� ���
        if (!isGameOver)
        {
            GlobalStorage.Instance.levelTime -= Time.deltaTime;

            if (GlobalStorage.Instance.levelTime <= 0)
            {
                Debug.Log("��� ���������! ��� ������!");
                isGameOver = true; // ��������� ������ ���, ���� ��� ���������
                // �������, �� ������ ����� ��������� ����� ������� ���������� ���
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // ��������, �� �������� ��'��� � ����� "Finish"
        if (other.CompareTag("Finish"))
        {
            Debug.Log("������! �� ����� �����!");
            isGameOver = true; // ��������� ������
            GlobalStorage.Instance.levelTime = 0; // ��������� ���
            // ����� ������ �� ���� ������� ��� ���������� ��� �� �������� �� ����� �����
        }
    }
}
