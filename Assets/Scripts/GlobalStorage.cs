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

    public int lives;                     // Кількість життів
    public int coinsCollected;            // Кількість зібраних монет
    public float levelTime;               // Час на рівень
    public int collisions;                // Кількість зіткнень
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
            ResetGameData(); // Починаємо з початкових значень
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void OnLevelComplete()
    {
        SaveData();
        Debug.Log("Рівень завершено! Дані оновлено.");
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
        Debug.Log("Дані збережено: " + json);
        Debug.Log("Шлях до JSON: " + filePath);
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
        Debug.Log("Монета зібрана! Всього монет: " + coinsCollected);
    }

    public void TakeDamage()
    {
        lives--;
        collisions++;
        Debug.Log("Після зменшення: " + lives);
        if (lives <= 0)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        SaveData();
        Debug.Log("Гра завершена! Програв!");
    }
}
