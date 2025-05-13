using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackButton : MonoBehaviour
{
    // Loads the main menu scene.
    public void LoadMainMenuScene()
    {
        // Loads the scene called "Main Menu".
        SceneManager.LoadScene("MainMenu");
    }
}