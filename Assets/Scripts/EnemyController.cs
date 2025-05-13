using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// EnemyController manages the movement, health, and interactions of the enemy character.
public class EnemyController : MonoBehaviour
{
    // Determines the enemy's movement speed.
    public float moveSpeed;

    // Determines the enemy's starting direction (X and Y).
    public Vector2 startDirection;

    // The enemy's change of direction
    public bool shouldChangeDirection;

    // Change direction point (X)
    public float changeDirectionXPoint;

    // The enemy's maximum health, current health, and damage dealt
    public int maxHealth;
    public int currentHealth;
    // The amount of damage dealt by the enemy
    public int damageAmount;

    // The new direction to be used when the direction is changed.
    public Vector2 changedDirection;

    // Update is called once in per frame. Manages the enemy's movement.
    void Update()
    {
        // If the game is not over, the enemy continues to move.
        if (!GameManager.instance.isGameOver)
        {
            // If it needs to change direction, it moves according to the starting direction.
            if (!shouldChangeDirection)
            {
                // Moves the enemy at a certain speed (using startDirection and moveSpeed).
                transform.position += new Vector3(startDirection.x * moveSpeed * Time.deltaTime, startDirection.y * moveSpeed * Time.deltaTime, 0f);
            }
            else
            {
                // If a direction change is necessary and the X position is greater than changeDirectionXPoint, it continues in the starting direction.
                if (transform.position.x > changeDirectionXPoint)
                {
                    transform.position += new Vector3(startDirection.x * moveSpeed * Time.deltaTime, startDirection.y * moveSpeed * Time.deltaTime, 0f);
                }
                else
                {
                    // The position continues with the changing direction.
                    transform.position += new Vector3(changedDirection.x * moveSpeed * Time.deltaTime, changedDirection.y * moveSpeed * Time.deltaTime, 0f);
                }
            }
        }
        else
        {
            // If the game is over, it resets the enemy's movement speed (the enemy stops).
            moveSpeed = 0f;
        }
    }

    // HurtEnemy manages the damage taken by the enemy. Health decreases, and if health reaches 0, the enemy dies.
    public void HurtEnemy()
    {
        // Reduces the enemy's health by one.
        currentHealth--;

        // If health is less than 0, it destroys the enemy.
        if (currentHealth < 0)
        {
            Destroy(gameObject);
        }
    }

    // OnBecameInvisible works if the enemy goes off-screen. In this case, it is not used.
    private void OnBecameInvisible()
    {

    }

    // OnTriggerEnter2D is called when the enemy collides with an object.
    // If the colliding object has the "FinishLine" tag, it reduces the player's health and performs other necessary actions.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // If the colliding object has the "FinishLine" tag
        if (collision.tag == "FinishLine")
        {
            // About the enemy's passage
            Debug.Log("can azalacak");

            // Reduces the player's health by the amount of damage dealt by the enemy.
            GameManager.instance.currentLives -= damageAmount;

            // If the player's health is zero or less, the game ends.
            if (GameManager.instance.currentLives <= 0)
            {
                Debug.Log("gameover");

                // The game ends, indicates a GameOver state.
                GameManager.instance.isGameOver = true;

            }

            // Disables the enemy's collider (no longer collides).
            gameObject.GetComponent<BoxCollider2D>().enabled = false;

            Destroy(gameObject, .5f);
        }
    }
}