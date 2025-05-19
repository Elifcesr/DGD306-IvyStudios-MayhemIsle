using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 3;
    public int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth; //starts the game with full health
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int amount) //amount: an integer for how much damage to take
    {
        currentHealth -= amount; // enemy's currentHealth goes down by the amount of damage that is dealt.
        if(currentHealth <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        GameManager.instance.EnemyKilled();

        Destroy(gameObject);
    }
}