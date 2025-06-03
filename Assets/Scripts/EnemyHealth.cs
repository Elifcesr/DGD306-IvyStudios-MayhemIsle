using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 3;
    public int currentHealth;
    public GameObject bloodEffectPrefab;

    public GameObject explosionEffectPrefab; // Explosion Effect
    public AudioClip explosionSound;         // Explosion Sound

    private DamageFlash _damageFlash;
    private AudioSource _audioSource;

    public Slider healthSlider; // slider

    void Start()
    {
        currentHealth = maxHealth;

        _damageFlash = GetComponent<DamageFlash>();
        _audioSource = GetComponent<AudioSource>(); // AudioSource 

        if (healthSlider != null)
        {
            healthSlider.maxValue = maxHealth;
            healthSlider.value = currentHealth;
        }
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;

        if (healthSlider != null)
        {
            healthSlider.value = currentHealth;
        }

        SpawnBloodEffect();

        if (currentHealth <= 0)
        {
            Die();
        }

        _damageFlash.CallDamageFlash();
    }

    void SpawnBloodEffect()
    {
        if (bloodEffectPrefab != null)
        {
            Instantiate(bloodEffectPrefab, transform.position, Quaternion.identity);
        }
    }

    void Die()
    {
        // Explosion Effect
        if (explosionEffectPrefab != null)
        {
            Instantiate(explosionEffectPrefab, transform.position, Quaternion.identity);
        }

        // Explosion Sound
        if (explosionSound != null && _audioSource != null)
        {
            _audioSource.PlayOneShot(explosionSound);
        }

        GameManager.instance.EnemyKilled();
        Destroy(gameObject);
    }
}