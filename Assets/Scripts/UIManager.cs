using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public GameObject gameOverScreen;
    public GameObject levelEndScreen;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ShowGameOver()
    {
        if (gameOverScreen != null)
            gameOverScreen.SetActive(true);
    }

    public void ShowLevelComplete()
    {
        if (levelEndScreen != null)
            levelEndScreen.SetActive(true);
    }

    public void HideAllScreens()
    {
        if (gameOverScreen != null)
            gameOverScreen.SetActive(false);

        if (levelEndScreen != null)
            levelEndScreen.SetActive(false);
    }
}
