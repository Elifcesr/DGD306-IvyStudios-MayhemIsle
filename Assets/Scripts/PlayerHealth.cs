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
        health = maxHealth;
    }

    public void TakeDamage(int amount)  //amount = how much damage the player takes
    {
        health -= amount;
        if(health <= 0)
        {
            playerSr.enabled = false;
            playerMovement.enabled = false;
        }
    }
}
