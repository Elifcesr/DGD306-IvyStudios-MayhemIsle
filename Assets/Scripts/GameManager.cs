using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool isGameOver = false;
    private int totalEnemies;
    public int currentLives = 10;

    private bool hasRedirected = false; // Sonsuz döngüyü önler.
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            // Eğer oyun MainMenu dışında açıldıysa, otomatik MainMenu sahnesine yönlendirir.
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

            GameObject gameOverUI = GameObject.Find("GameOverScreen");
            if (gameOverUI != null)
            {
                gameOverUI.SetActive(true);
            }
            else
            {
                Debug.LogWarning("GameOverScreen objesi bulunamadı!");
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
