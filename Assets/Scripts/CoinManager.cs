using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public GameObject levelCompleteText;

    private int totalCoins;
    private int collectedCoins = 0;

    void Start()
    {
        totalCoins = GameObject.FindGameObjectsWithTag("Coin").Length;

        if (levelCompleteText != null)
            levelCompleteText.SetActive(false);
    }

    public void CollectCoin()
    {
        collectedCoins++;

        if (collectedCoins >= totalCoins)
        {
            if (levelCompleteText != null)
                levelCompleteText.SetActive(true);

            Time.timeScale = 0f; 
        }

        if (collectedCoins >= totalCoins)
        {
            levelCompleteText.SetActive(true);
            Time.timeScale = 0f;

            float currentTime = Time.timeSinceLevelLoad;
            RecordsManager.SaveRecord(currentTime);

            Debug.Log("Рівень завершено за " + currentTime + " сек");
        }
    }
}
