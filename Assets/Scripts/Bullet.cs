using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// The Bullet class manages the bullet's movement and interactions.
public class Bullet : MonoBehaviour
{
    // Determines the bullet's travel speed, default value is 7 units/second.
    public float shotSpeed = 7f;

    // Determines the damage the bullet will deal to the enemy, default value is 10.
    public int bulletDamage = 10;

    // Start is a method that will run before the first frame is drawn. It is not used here.
    void Start()
    {

    }

    // Update runs once per frame. It ensures that the bullet moves continuously to the right.
    private void Update()
    {
        // It updates the position of the bullet every frame according to the shotSpeed.
        transform.position += new Vector3(shotSpeed * Time.deltaTime, 0f, 0f);
    }

    // OnTriggerEnter2D is called when the bullet collides with a collider.
    // If the colliding object has the "Enemy" tag, it will start dealing damage to the enemy.
    private void OnTriggerEnter2D(Collider2D other)
    {
        // If the colliding object is an Enemy 
        if (other.tag == "Enemy")
        {
            // Destroys the bullet.
            Destroy(gameObject);

            // If the enemy's health is greater than 10, it inflicts damage.
            if (other.GetComponent<EnemyHealth>().currentHealth > 10)
            {
                // Reduces the enemy's health by bulletDamage.
                other.GetComponent<EnemyHealth>().currentHealth -= bulletDamage;
            }
            // If the enemy's health is 10 or less
            else if (other.GetComponent<EnemyHealth>().currentHealth <= 10)
            {
                // Disables the enemy's collider (no longer collides).
                other.GetComponent<BoxCollider2D>().enabled = false;
                // Eliminates the enemy from the stage, 0.4 seconds later.
                Destroy(other.gameObject, .4f);
            }
        }
    }

    // OnBecameInvisible works if the bullet goes off-screen.
    // It destroys the bullet, thus clearing the bullets that go off-screen from memory.
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
