using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    // The point where the bullet was fired
    public Transform firePoint;

    // Bullet prefab to be created when fired
    public GameObject bulletPrefab;

    // Sound to be played when shooting
    public AudioClip shootSound;
    private AudioSource audioSource;

    // Reference to the player movement script (PlayerMovement).
    private PlayerMovement playerMovement;

    void Start()
    {
        // PlayerMovement script
        playerMovement = GetComponentInParent<PlayerMovement>(); // If the weapon is bound to the player character

        // Get AudioSource component
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && !GameManager.instance.isGameOver && !playerMovement.stopMovement)
        {
            Shoot(); // fire the gun
        }
    }

    // It performs the ignition process.
    void Shoot()
    {
        // Creates a new bullet and places it in the scene with the firePoint's position and rotation
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        // Play shoot sound
        if (shootSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(shootSound);
        }
    }
}
