using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [Header("Screens")]
    public GameObject gameOverScreen;

    [Header("Buttons")]
    public Button restartButton;
    public Button mainMenuButton;

    [Header("Health")]
    public HealthDisplay healthDisplay; // Kalp UI’sini güncelleyen script
    public PlayerHealth playerHealth;   // Gerçek saðlýk deðerlerinin kaynaðý

    [Header("Scene Names")]
    public string mainMenuSceneName = "MainMenu";
    public string firstLevelSceneName = "Level1";

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

        if (restartButton != null)
            restartButton.onClick.AddListener(RestartGame);

        if (mainMenuButton != null)
            mainMenuButton.onClick.AddListener(GoToMainMenu);
    }

    public void ShowGameOver()
    {
        Time.timeScale = 0f;
        gameOverScreen.SetActive(true);
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(firstLevelSceneName);
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(mainMenuSceneName);
    }
}
