using UnityEngine;
using TMPro;

public class LevelTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText;

    private float elapsedTime = 0f;

    void Update()
    {
        elapsedTime += Time.deltaTime;
        timerText.text = "���: " + elapsedTime.ToString("F1") + " c";
    }

    public float GetTime()
    {
        return elapsedTime;
    }
}
