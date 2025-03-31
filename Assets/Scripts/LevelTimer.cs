using UnityEngine;

public class LevelTimer : MonoBehaviour
{
    private bool isGameOver = false; // Перевіряємо, чи гра вже завершена

    void Update()
    {
        // Якщо гра ще не завершена, зменшуємо час
        if (!isGameOver)
        {
            GlobalStorage.Instance.levelTime -= Time.deltaTime;

            if (GlobalStorage.Instance.levelTime <= 0)
            {
                Debug.Log("Гра завершена! Час вийшов!");
                isGameOver = true; // Оновлюємо статус гри, якщо час вичерпано
                // Можливо, ви хочете також викликати якусь функцію завершення гри
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Перевірка, чи зіткнувся об'єкт з тегом "Finish"
        if (other.CompareTag("Finish"))
        {
            Debug.Log("Виграв! Ти досяг фінішу!");
            isGameOver = true; // Зупиняємо таймер
            GlobalStorage.Instance.levelTime = 0; // Зупиняємо час
            // Можна додати ще одну функцію для завершення гри чи переходу на новий рівень
        }
    }
}
