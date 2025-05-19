using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
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