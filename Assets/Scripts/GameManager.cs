using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

// GameManager controls the overall management of the game, including lives, levels, and game state.
public class GameManager : MonoBehaviour
{
    // The Singleton example provides access to the single GameManager object in the game.
    public static GameManager instance;

    // The player's maximum health is set to a default value of 3.
    public int maxLives = 3;

    // The player's current number of lives has a default value of 3.
    public int currentLives = 3;

    // The player's respawn time has a default value of 2.
    public float respawnTime = 2f;

    // Checks whether the level has ended or not.
    public bool levelEnding;

    // If the game is over, it will be true; as long as it is not over, it will be false.
    public bool isGameOver = false;

    // The expected duration for the level to end is the default value of 5.
    public float waitForLevelEnd = 5f;

    // Total number of enemies in the level.
    public int totalEnemies = 15;

    // Remaining enemies left to defeat.
    private int remainingEnemies;

    // The GameManager object is called when the scene is first loaded.
    // Creates a singleton instance.
    private void Awake()
    {
        instance = this;
    }

    // Start is called when the game starts.
    // It retrieves the player's current health from PlayerPrefs, using the default health value if no value is recorded.
    void Start()
    {
        currentLives = PlayerPrefs.GetInt("CurrentLives", currentLives);
        Debug.Log("currentLives : " + currentLives);

        // Sets the number of remaining enemies.
        remainingEnemies = totalEnemies;
    }

    // Update works every frame.
    void Update()
    {
        // Pause logic removed completely.
    }

    // Kills the player and updates the health count.
    // If there are lives left, the respawn process is carried out; otherwise, the game ends.
    public void KillPlayer()
    {
        if (currentLives > 0)
        {
            // The spawn code is initiated.
            StartCoroutine(RespawnCo());
            currentLives--;
        }
        else
        {
            // If there are no lives left, the lives are set to 0.
            currentLives = 0;
            // The game end code is executed.
            UIManager.instance.gameOverScreen.SetActive(true);
            // The GameOver music plays.
            MusicController.instance.PlayGameOver();
            // The game is now over.
            isGameOver = true;
        }
    }

    // Coroutine for the respawn process.
    // After waiting for a certain period (respawnTime), it respawns the player.
    public IEnumerator RespawnCo()
    {
        // Waits as long as the respawn period.
        yield return new WaitForSeconds(respawnTime);

        // Call your respawn logic here.
        // Example: Instantiate(playerPrefab, respawnPoint.position, Quaternion.identity);
    }

    // When a single enemy is killed, this is called to track progress.
    // If all enemies are defeated, the level ends.
    public void EnemyKilled()
    {
        remainingEnemies--;

        if (remainingEnemies <= 0 && !isGameOver)
        {
            // Starts the end-level sequence if all enemies are gone.
            StartCoroutine(EndLevelCo());
        }
    }

    // It initiates the process of ending the level.
    // It shows the level completion screen and activates the "Continue" and "Main Menu" buttons after a few seconds.
    public IEnumerator EndLevelCo()
    {
        // It activates the level completion screen.
        UIManager.instance.levelEndScreen.SetActive(true);

        // Waits for 1 second.
        yield return new WaitForSeconds(1f);

        // It activates the Continue and Main Menu buttons.
        UIManager.instance.continueButton.gameObject.SetActive(true);
        UIManager.instance.menuButton.gameObject.SetActive(true);
    }
}
