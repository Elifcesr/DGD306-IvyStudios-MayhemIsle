using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int health;
    public int maxHealth = 10;

    public SpriteRenderer playerSr;
    public PlayerMovement playerMovement;

    void Start()
    {
        string currentScene = SceneManager.GetActiveScene().name;

        // E�er Level3 de�ilse, �nceki sa�l�k de�erini y�kle
        if (currentScene != "Level3")
        {
            if (PlayerPrefs.HasKey("PlayerHealth"))
            {
                health = PlayerPrefs.GetInt("PlayerHealth");
            }
            else
            {
                health = maxHealth;
            }

            // G�ncel sa�l�k de�erini kaydet
            PlayerPrefs.SetInt("PlayerHealth", health);
            PlayerPrefs.Save();
        }
        else
        {
            // Level3'te sa�l��� her zaman full ba�lat
            health = maxHealth;
        }
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        health = Mathf.Clamp(health, 0, maxHealth);

        if (health <= 0)
        {
            playerSr.enabled = false;
            playerMovement.enabled = false;
            playerMovement.stopMovement = true;
            GameManager.instance.PlayerDied();
        }

        // Sadece Level3 d���nda can kaydet
        if (SceneManager.GetActiveScene().name != "Level3")
        {
            PlayerPrefs.SetInt("PlayerHealth", health);
            PlayerPrefs.Save();
        }
    }
}
