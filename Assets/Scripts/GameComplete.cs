using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameComplete : MonoBehaviour
{
    // It is the variable that determines the time to be shown between messages.
    public float timeBetweenTexts;

    // It is the variable that controls whether the player can leave the stage.
    public bool canExit;

    // Name of the main menu scene (used when switching to another scene).
    public string mainMenuName = "MainMenu";

    public Text pressKey;

    // Start is called once before the first frame.
    void Start()
    {
        // Initializes Coroutine to sequentially display text indicating game completion.
        StartCoroutine(ShowTextCo());
    }

    // Update is called every frame.
    void Update()
    {
        // If it is possible to exit and any key was pressed
        if (canExit && Input.anyKeyDown)
        {
            // Switches to the main menu.
            SceneManager.LoadScene(mainMenuName);
        }
    }

    // This coroutine displays messages at regular intervals.
    public IEnumerator ShowTextCo()
    {
        // It waits for the first message to be displayed.
        yield return new WaitForSeconds(timeBetweenTexts);

        // It waits again for the second message to be displayed.
        yield return new WaitForSeconds(timeBetweenTexts);

        // Activates the second message.
        pressKey.gameObject.SetActive(true);

        // Sets canExit to true to enable exit.
        canExit = true;
    }
}