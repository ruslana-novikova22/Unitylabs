using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LoginManager : MonoBehaviour
{
    public TMP_InputField loginInput;
    public GameObject loginPanel;

    public string nextSceneName = "MainScene"; 

    private void Start()
    {
        Time.timeScale = 0f; 
        loginPanel.SetActive(true); 
    }

    public void StartGame()
    {
        string login = loginInput.text.Trim();

        if (!string.IsNullOrEmpty(login))
        {
            PlayerPrefs.SetString("PlayerLogin", login);
            PlayerPrefs.Save();

            Time.timeScale = 1f; 
            loginPanel.SetActive(false);
        }
        else
        {
            Debug.LogWarning("Ћог≥н не введено!");
        }
    }
}
