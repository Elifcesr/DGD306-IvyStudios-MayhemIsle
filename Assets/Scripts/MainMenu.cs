using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    public float moveSpeed = 5f;  // Movement speed
    public float minX = -4f;     // Minimum X limit
    public float maxX = 4f;      // Maximum X limit
    public GameObject menuObject; // Object to be moved

    private void Start()
    {
        PlayerPrefs.GetString("LevelName", "Level1");
        Debug.Log("Level Name : " + PlayerPrefs.GetString("LevelName", "Level1"));
    }

    private void Update()
    {
        // Adds horizontal movement (left and right).
        float moveX = Input.GetAxis("Horizontal"); // A/D 

        // Current position of the object
        Vector3 currentPos = menuObject.transform.position;

        // Calculates the new position.
        currentPos.x += moveX * moveSpeed * Time.deltaTime;

        // Applies X limits.
        currentPos.x = Mathf.Clamp(currentPos.x, minX, maxX);

        // Moves the object to the new position.
        menuObject.transform.position = currentPos;
    }

    public void playGame()
    {
        // It is called to start the game.
        SceneManager.LoadScene(PlayerPrefs.GetString("LevelName", "Level1"));
    }

    public void mainMenu()
    {
        // Loads the scene called "Main Menu".
        SceneManager.LoadScene("Main Menu");
    }

    public void creditsMenu()
    {
        // Loads the scene called "Credits Menu".
        SceneManager.LoadScene("Credits Menu");
    }

    public void ExitGame()
    {
        // Called to close the game.
        Application.Quit();
    }
}