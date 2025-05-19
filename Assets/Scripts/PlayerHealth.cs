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
        // Her zaman saðlýk maxHealth olarak baþlasýn
        health = maxHealth;

        // Eðer önceden kaydedilmiþ bir saðlýk varsa ve oyun devam ediyorsa onu yükle
        if (PlayerPrefs.HasKey("PlayerHealth"))
        {
            health = PlayerPrefs.GetInt("PlayerHealth");
        }

        // Güncel saðlýk deðeri kaydedilsin
        PlayerPrefs.SetInt("PlayerHealth", health);
        PlayerPrefs.Save();
    }


    public void TakeDamage(int amount)
    {
        health -= amount;
        health = Mathf.Clamp(health, 0, maxHealth);

        // Saðlýk sýfýra düþtüyse ölüm iþlemleri
        if (health <= 0)
        {
            playerSr.enabled = false;
            playerMovement.enabled = false;
            playerMovement.stopMovement = true;
            GameManager.instance.PlayerDied();
        }

        // Güncel caný kaydet
        PlayerPrefs.SetInt("PlayerHealth", health);
        PlayerPrefs.Save();
    }
}