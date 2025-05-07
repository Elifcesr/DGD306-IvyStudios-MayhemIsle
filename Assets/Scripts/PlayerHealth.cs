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
            health = 0;
            playerSr.enabled = false;
            playerMovement.enabled = false;
            playerMovement.stopMovement = true; //stop movement
        }
    }
    public void Respawn()
    {
        health = maxHealth;
        playerSr.enabled = true;
        playerMovement.enabled = true;
        playerMovement.stopMovement = false; // start movement
        transform.position = Vector3.zero; 
    }
}
