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
                instance = FindFirstObjectByType<GlobalStorage>(); // Заміна на новий метод
            return instance;
        }
    }

    public int lives = 3;
    public int coinsCollected = 0;
    public float levelTime = 60f;

    [JsonIgnore] // Виключаємо об'єкти Unity
    public GameObject player;

    private string filePath => Path.Combine(Application.persistentDataPath, "save.json");

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Запобігає знищенню при зміні сцен
        }
        else
        {
            Destroy(gameObject); // Знищує дублікати
        }
    }

    public void SaveData()
    {
        string json = JsonConvert.SerializeObject(this, Formatting.Indented);
        File.WriteAllText(filePath, json);
        Debug.Log("Дані збережено: " + json);
    }

    public void CollectCoin()
    {
        coinsCollected++;
        Debug.Log("Монета зібрана! Всього монет: " + coinsCollected);
    }

    public void TakeDamage()
    {
        lives--; // Зменшуємо кількість життів
        Debug.Log("Після зменшення: " + lives);

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
            Debug.Log("Дані завантажено: " + json);
        }
    }


    // Додаємо метод GameOver
    public void GameOver()
    {
        // Логіка завершення гри
        Debug.Log("Гра завершена! Програв!");
    }
}
