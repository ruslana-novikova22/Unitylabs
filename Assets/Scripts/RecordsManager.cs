using UnityEngine;
using TMPro;
using System.Collections.Generic;
using System.Linq;

public class RecordsManager : MonoBehaviour
{
    public GameObject recordsPanel;
    public TextMeshProUGUI recordsText;

    private const int maxRecords = 10;

    void Start()
    {
        recordsPanel.SetActive(false); 
    }

    public void ShowRecords()
    {
        List<float> records = new List<float>();

        for (int i = 0; i < maxRecords; i++)
        {
            float time = PlayerPrefs.GetFloat("Record_" + i, -1f);
            if (time > 0)
                records.Add(time);
        }

        records = records.OrderBy(t => t).ToList();

        string result = "<b>Рекорди:</b>\n";
        for (int i = 0; i < records.Count; i++)
        {
            result += $"{i + 1}. {records[i]:F1} сек\n";
        }

        recordsText.text = result;
        recordsPanel.SetActive(true);
    }

    public void HideRecords()
    {
        recordsPanel.SetActive(false);
    }

    public static void SaveRecord(float time)
    {
        List<float> records = new List<float>();

        for (int i = 0; i < maxRecords; i++)
        {
            float savedTime = PlayerPrefs.GetFloat("Record_" + i, -1f);
            if (savedTime > 0)
                records.Add(savedTime);
        }

        records.Add(time);
        records = records.OrderBy(t => t).Take(maxRecords).ToList();

        for (int i = 0; i < records.Count; i++)
        {
            PlayerPrefs.SetFloat("Record_" + i, records[i]);
        }

        PlayerPrefs.Save();
    }
}
