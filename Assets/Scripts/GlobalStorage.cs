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
                instance = FindFirstObjectByType<GlobalStorage>();
            return instance;
        }
    }

    public int lives;                     // ʳ������ �����
    public int coinsCollected;            // ʳ������ ������� �����
    public float levelTime;               // ��� �� �����
    public int collisions;                // ʳ������ �������
    public int currentScore;

    [JsonIgnore]
    public GameObject player;

    [JsonIgnore]
    public Transform playerTransform;

    [JsonIgnore]
    public Rigidbody playerRb;

    private string filePath => Path.Combine(Application.persistentDataPath, "save.json");

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            ResetGameData(); // �������� � ���������� �������
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void OnLevelComplete()
    {
        SaveData();
        Debug.Log("г���� ���������! ��� ��������.");
    }

    public void SaveData()
    {
        var dataToSave = new
        {
            lives,
            coinsCollected,
            levelTime,
            collisions,
            currentScore
        };

        string json = JsonConvert.SerializeObject(dataToSave, Formatting.Indented);
        File.WriteAllText(filePath, json);
        Debug.Log("��� ���������: " + json);
        Debug.Log("���� �� JSON: " + filePath);
    }

    private void ResetGameData()
    {
        lives = 3;
        coinsCollected = 0;
        levelTime = 60f;
        collisions = 0;
        currentScore = 0;
    }

    void OnApplicationQuit()
    {
        SaveData();
    }

    public void CollectCoin()
    {
        coinsCollected++;
        currentScore++;
        Debug.Log("������ ������! ������ �����: " + coinsCollected);
    }

    public void TakeDamage()
    {
        lives--;
        collisions++;
        Debug.Log("ϳ��� ���������: " + lives);
        if (lives <= 0)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        SaveData();
        Debug.Log("��� ���������! �������!");
    }
}
