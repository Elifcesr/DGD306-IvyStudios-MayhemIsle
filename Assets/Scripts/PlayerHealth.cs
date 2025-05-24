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

        if (currentScene != "Level3")
        {
            if (PlayerPrefs.HasKey("PlayerHealth"))
            {
                int savedHealth = PlayerPrefs.GetInt("PlayerHealth");

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

      
        if (SceneManager.GetActiveScene().name != "Level3")
        {
            PlayerPrefs.SetInt("PlayerHealth", health);
            PlayerPrefs.Save();
        }
    }
}
