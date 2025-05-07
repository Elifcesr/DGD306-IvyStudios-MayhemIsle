using System.Collections;
using System.Collections.Generic;
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

    // Control variable for the pause operation.
    private bool canPause;

    public List<PlayerMovement> players = new List<PlayerMovement>();

    // The GameManager object is called when the scene is first loaded.
    private void Awake()
    {
        // Singleton kur
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        currentLives = PlayerPrefs.GetInt("CurrentLives", maxLives);
        Debug.Log("currentLives : " + currentLives);

        canPause = true;

        // Sahnedeki tüm oyuncularý bul
        GameObject[] playerObjects = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject go in playerObjects)
        {
            PlayerMovement pm = go.GetComponent<PlayerMovement>();
            if (pm != null)
            {
                players.Add(pm);
            }
        }
    }


    // Update works in per frame.
    // When Escape is pressed, the game can be paused or continued.
    // If the number of enemies is zero, it starts the EndLevelCo Coroutine to finish the level.
    void Update()
    {
        // When the Escape key is pressed, the game can be paused and resumed.
        if (Input.GetKeyDown(KeyCode.Escape) && canPause)
        {
            PauseUnpause();
        }

       //WaveManager
    }

    // Kills the player and updates the health count.
    // If there are lives left, the respawn process is carried out; otherwise, the game ends.
    public void KillPlayer(PlayerMovement player)
    {
        if (currentLives > 0)
        {
            // The spawn code is initiated.
            StartCoroutine(RespawnCo(player));
            currentLives--;

            //UI manager
        }
        else
        {
            // If there are no lives left, the lives are set to 0.
            currentLives = 0;
            StopAllPlayers();

            //UI manager

            //UI manager

 
           //level1 enemywave

            // MusicController
      
            // The pause operation is disabled.
            canPause = false;
        }
    }

    // Coroutine for the respawn process.
    // After waiting for a certain period (respawnTime), it respawns the player.
    public IEnumerator RespawnCo(PlayerMovement player)
    {
        // Waits as long as the respawn period.
        yield return new WaitForSeconds(respawnTime);
        PlayerHealth health = player.GetComponent<PlayerHealth>();
        if (health != null)
        {
            health.Respawn();
        }
        // WaveManager
    }

    //stop all players
    private void StopAllPlayers()
    {
        foreach (var player in players)
        {
            player.stopMovement = true;
        }
    }

    // It initiates the process of ending the level.
    // It shows the level completion screen and activates the "Continue" and "Main Menu" buttons after a few seconds.
    public IEnumerator EndLevelCo()
    {
        //UIManager

        StopAllPlayers();
        canPause = false;

        yield return new WaitForSeconds(1f);

        // UIManager
    }

    // The method that allows the game to be paused and resumed.
    public void PauseUnpause()
    {
        //UIManager
   
            //  MusicController

            // Pause screen UIManager
 
    }
}