using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    // This lets the EnemyDamage script know where to find the PlayerHealth script in Unity
    public PlayerHealth playerHealth;
    public PlayerHealth playerHealth2;
    public int damage = 2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // This function is "called" (it runs) whenever something enters the enemy's collider.
    private void OnCollisionEnter2D(Collision2D collision)
    {
     if(collision.gameObject.tag == "Player")
        {
            // "talks" to the Player Health script
            playerHealth.TakeDamage(damage);
            playerHealth2.TakeDamage(damage);
        }
    }
}
