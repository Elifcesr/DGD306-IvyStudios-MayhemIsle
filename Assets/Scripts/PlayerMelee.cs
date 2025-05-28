using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMelee : MonoBehaviour
{
    public Transform attackOrigin;
    public float attackRadius = 1f;
    public LayerMask enemyMask;
    public int attackDamage = 4;

    public float cooldownTime = .5f;
    private float cooldownTimer = 0f;

    public AudioClip slashSound; 
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (cooldownTimer <= 0)
        {
            if (Input.GetMouseButton(0) || Input.GetKey(KeyCode.Joystick1Button0)) // left click
            {
                // play sound
                if (slashSound != null && audioSource != null)
                {
                    audioSource.PlayOneShot(slashSound);
                }

                Collider2D[] enemiesInRange = Physics2D.OverlapCircleAll(attackOrigin.position, attackRadius, enemyMask);
                foreach (var enemy in enemiesInRange)
                {
                    enemy.GetComponent<EnemyHealth>().TakeDamage(attackDamage);
                }

                cooldownTimer = cooldownTime;
            }
        }
        else
        {
            cooldownTimer -= Time.deltaTime;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attackOrigin.position, attackRadius);
    }
}
