using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool isGameOver = false;
    public int currentLives = 10;

    private int totalEnemies;
    private bool hasRedirected = false;

    private Dictionary<string, int> levelEnemyCount = new Dictionary<string, int>()
    {
        { "Level1", 15 },
        { "Level2", 4 },
        { "Level3", 4 }
    };

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            string currentScene = SceneManager.GetActiveScene().name;
            if (currentScene != "MainMenu" && !hasRedirected)
            {
                hasRedirected = true;
                SceneManager.LoadScene("MainMenu");
            }
        }
        else
        {
            Destroy(gameObject);
        }

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        CountEnemies();
        isGameOver = false;
    }

    public void CountEnemies()
    {
        string currentScene = SceneManager.GetActiveScene().name;

        if (levelEnemyCount.ContainsKey(currentScene))
        {
            totalEnemies = levelEnemyCount[currentScene];
        }
        else
        {
            // Eğer belirtilmemişse sahnedeki düşmanları say.
            totalEnemies = GameObject.FindGameObjectsWithTag("Enemy").Length;
        }
    }

    public void EnemyKilled()
    {
        totalEnemies--;

        if (totalEnemies <= 0 && !isGameOver)
        {
            StartCoroutine(NextLevelCo());
        }
    }

    public void PlayerDied()
    {
        if (!isGameOver)
        {
            isGameOver = true;

            if (UIManager.instance != null)
            {
                UIManager.instance.ShowGameOver();
            }
            else
            {
                Debug.LogWarning("UIManager instance bulunamadı!");
            }
        }
    }

    IEnumerator NextLevelCo()
    {
        yield return new WaitForSeconds(1f);

        string currentScene = SceneManager.GetActiveScene().name;

        if (currentScene == "MainMenu")
        {
            SceneManager.LoadScene("Level1");
        }
        else if (currentScene == "Level1")
        {
            SceneManager.LoadScene("Level2");
        }
        else if (currentScene == "Level2")
        {
            SceneManager.LoadScene("Level3");
        }
        else if (currentScene == "Level3")
        {
            SceneManager.LoadScene("GameComplete");
        }
        else if (currentScene == "Credits")
        {
            SceneManager.LoadScene("GameComplete");
        }
    }

    public IEnumerator EndLevelCo()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("GameComplete");
    }
}
