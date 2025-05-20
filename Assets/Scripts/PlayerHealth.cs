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
                int savedHealth = PlayerPrefs.GetInt("PlayerHealth");

                // E�er kay�tl� sa�l�k de�eri 0 ise, maxHealth ile ba�la
                if (savedHealth <= 0)
                {
                    health = maxHealth;
                }
                else
                {
                    health = savedHealth;
                }
            }
            else
            {
                health = maxHealth;
            }

            PlayerPrefs.SetInt("PlayerHealth", health);
            PlayerPrefs.Save();
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
