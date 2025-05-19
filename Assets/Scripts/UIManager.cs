using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [Header("Screens")]
    public GameObject gameOverScreen;
    public GameObject levelEndScreen;

    [Header("Buttons")]
    public Button continueButton;
    public Button menuButton;

    [Header("Health")]
    public HealthDisplay healthDisplay; // Kalp UI’sini güncelleyen script
    public PlayerHealth playerHealth;   // Gerçek saðlýk deðerlerinin kaynaðý

    [Header("Scene Names")]
    public string mainMenuName = "MainMenu";
    public string loadSceneName;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        if (healthDisplay != null && playerHealth != null)
        {
            healthDisplay.playerHealth = playerHealth;
        }
    }

    public void ShowGameOver()
    {
        Time.timeScale = 0f;
        gameOverScreen.SetActive(true);
    }

    public void ShowLevelEnd()
    {
        Time.timeScale = 0f;
        levelEndScreen.SetActive(true);
    }

    public void Continue()
    {
        Time.timeScale = 1f;
        gameOverScreen.SetActive(false);
        levelEndScreen.SetActive(false);
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Exit()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(mainMenuName);
    }

    public void LevelSceneLoad()
    {
        if (PlayerPrefs.GetString("LevelName") == "Level3")
        {
            PlayerPrefs.SetString("LevelName", "Level3");
        }
        else
        {
            PlayerPrefs.SetString("LevelName", loadSceneName);
        }

        Time.timeScale = 1f;
        SceneManager.LoadScene(loadSceneName);
    }
}
