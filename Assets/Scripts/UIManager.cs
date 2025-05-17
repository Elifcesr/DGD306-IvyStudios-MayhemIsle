using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public GameObject gameOverScreen;
    public GameObject levelEndScreen;

    public string mainMenuName = "MainMenu";
    public string loadSceneName;

    private void Awake()
    {
        instance = this;
    }

    public void LevelSceneLoad()
    {
        Time.timeScale = 1f;

        if (string.IsNullOrEmpty(loadSceneName))
        {
            return;
        }

        Debug.Log("Loading scene: " + loadSceneName);
        SceneManager.LoadScene(loadSceneName);
    }
}
