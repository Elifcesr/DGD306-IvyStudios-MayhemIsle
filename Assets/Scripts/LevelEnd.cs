using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;

public class LevelEnd : MonoBehaviour
{
    // This class controls operations related to level termination.

    // Start is called once before the first frame.
    void Start()
    {
        // Victory music plays at the end of the level.
        MusicController.instance.PlayVictory();
    }

    // Update is called in every frame, but there is no action in this function.
    void Update()
    {

    }

    // Called when a 2D physical collision(trigger) occurs.
    // The "other" parameter represents the other collider where the collision occurred.
    private void OnTriggerEnter2D(Collider2D other)
    {
        // If the colliding object has the "Player" tag (collision occurred with the player)
        if (other.tag == "Player")
        {
            // Starts the coroutine that manages the end of the level via GameManager.
            StartCoroutine(GameManager.instance.EndLevelCo());
        }
    }
}
