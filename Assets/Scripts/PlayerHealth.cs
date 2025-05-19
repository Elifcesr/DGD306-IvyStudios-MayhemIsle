using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health;
    public int maxHealth = 10;

    public SpriteRenderer playerSr;
    public PlayerMovement playerMovement;

    void Start()
    {
        // Her zaman sa�l�k maxHealth olarak ba�las�n
        health = maxHealth;

        // E�er �nceden kaydedilmi� bir sa�l�k varsa ve oyun devam ediyorsa onu y�kle
        if (PlayerPrefs.HasKey("PlayerHealth"))
        {
            health = PlayerPrefs.GetInt("PlayerHealth");
        }

        // G�ncel sa�l�k de�eri kaydedilsin
        PlayerPrefs.SetInt("PlayerHealth", health);
        PlayerPrefs.Save();
    }


    public void TakeDamage(int amount)
    {
        health -= amount;
        health = Mathf.Clamp(health, 0, maxHealth);

        // Sa�l�k s�f�ra d��t�yse �l�m i�lemleri
        if (health <= 0)
        {
            playerSr.enabled = false;
            playerMovement.enabled = false;
            playerMovement.stopMovement = true;
            GameManager.instance.PlayerDied();
        }

        // G�ncel can� kaydet
        PlayerPrefs.SetInt("PlayerHealth", health);
        PlayerPrefs.Save();
    }
}