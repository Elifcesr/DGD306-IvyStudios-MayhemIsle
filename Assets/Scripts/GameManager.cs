using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool isGameOver = false;
    private int totalEnemies;
    public int currentLives = 10;

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

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        CountEnemies();
        isGameOver = false;
    }

    public void CountEnemies()
    {
        totalEnemies = GameObject.FindGameObjectsWithTag("Enemy").Length;
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
            SceneManager.LoadScene("GameOver");
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
        if (currentScene == "Level2")
        {
            SceneManager.LoadScene("Level2");
        }
        else if (currentScene == "Level3")
        {
            SceneManager.LoadScene("Credits");
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
