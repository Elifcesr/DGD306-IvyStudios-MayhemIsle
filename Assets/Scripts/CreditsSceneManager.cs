using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsSceneManager : MonoBehaviour
{
    // Loads Credits scene.
    public void LoadCreditsScene()
    {
        // Loads the scene named "Credits".
        SceneManager.LoadScene("Credits");
    }
}