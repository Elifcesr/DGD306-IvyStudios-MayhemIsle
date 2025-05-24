using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float shotSpeed = 7f;

    // The amount of damage the bullet will deal to the enemy.
    public int bulletDamage = 10;

    void Start()
    {
        // The bullet will be destroyed after 1 second in the scene.
        Destroy(gameObject, 1f);
    }

    // Ensures the bullet moves to the right.
    private void Update()
    {
        // Moves the bullet along the x-axis at the rate of shotSpeed.
        // Time.deltaTime ensures movement is frame-rate independent.
        transform.position += new Vector3(shotSpeed * Time.deltaTime, 0f, 0f);
    }

    // Triggered when the bullet collides with another object.
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            // Destroy the bullet.
            Destroy(gameObject);

            // Get the EnemyHealth component.
            EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(bulletDamage);
            }
        }
    }

    private void OnBecameInvisible()
    {
        // Removes the bullet from the scene when it becomes invisible.
        Destroy(gameObject);
    }
}
