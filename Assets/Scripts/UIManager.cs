using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public GameObject gameOverScreen;
    public GameObject levelEndScreen;
    public Button continueButton;
    public Button menuButton;

    public string mainMenuName = "MainMenu";
    public string loadSceneName;

    private void Awake()
    {
        instance = this;
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }

    public void Exit()
    {
        SceneManager.LoadScene(mainMenuName);
        Time.timeScale = 1f;
    }

    public void Continue()
    {
        // Level yüklemeyi baþlatýr
        LevelSceneLoad(); 
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

        SceneManager.LoadScene(loadSceneName);
    }
}
