using UnityEngine;
using System.IO;
using Newtonsoft.Json;

public class GlobalStorage : MonoBehaviour
{
    private static GlobalStorage instance;
    public static GlobalStorage Instance
    {
        get
        {
            if (instance == null)
                instance = FindFirstObjectByType<GlobalStorage>(); // ����� �� ����� �����
            return instance;
        }
    }

    public int lives = 3;
    public int coinsCollected = 0;
    public float levelTime = 60f;

    [JsonIgnore] // ��������� ��'���� Unity
    public GameObject player;

    private string filePath => Path.Combine(Application.persistentDataPath, "save.json");

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // ������� �������� ��� ��� ����
        }
        else
        {
            Destroy(gameObject); // ����� ��������
        }
    }

    public void SaveData()
    {
        string json = JsonConvert.SerializeObject(this, Formatting.Indented);
        File.WriteAllText(filePath, json);
        Debug.Log("��� ���������: " + json);
    }

    public void CollectCoin()
    {
        coinsCollected++;
        Debug.Log("������ ������! ������ �����: " + coinsCollected);
    }

    public void TakeDamage()
    {
        lives--; // �������� ������� �����
        Debug.Log("ϳ��� ���������: " + lives);

        if (lives <= 0)
        {
            GameOver();
        }
    }

    public void LoadData()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            instance = JsonConvert.DeserializeObject<GlobalStorage>(json);
            Debug.Log("��� �����������: " + json);
        }
    }


    // ������ ����� GameOver
    public void GameOver()
    {
        // ����� ���������� ���
        Debug.Log("��� ���������! �������!");
    }
}
