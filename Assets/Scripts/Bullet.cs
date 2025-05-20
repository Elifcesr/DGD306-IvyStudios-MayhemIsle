using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Oyunda merminin saniyede ka� birim gidece�ini belirtir. 
    public float shotSpeed = 7f;

    // Merminin d��mana verece�i hasar miktar�.
    public int bulletDamage = 10;

                                         
    void Start()
    {
        // Mermi sahnede en fazla 3 saniye kal�r, sonra yok edilir.
        Destroy(gameObject, 1f);

    }

    // Merminin s�rekli sa�a do�ru hareket etmesi sa�lan�r.
    private void Update()
    {
        // Merminin x ekseninde shotSpeed h�z�nda ilerlemesini sa�lar.
        // Time.deltaTime kullan�m�, kare h�z�ndan ba��ms�z hareket sa�lar.
        transform.position += new Vector3(shotSpeed * Time.deltaTime, 0f, 0f);
    }

    // Ba�ka bir nesne ile �arp��ma ger�ekle�ti�inde tetiklenir.
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            // Mermiyi yok et
            Destroy(gameObject);

            // EnemyHealth bile�enini al
            EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(bulletDamage);
            }
        }
    }


    private void OnBecameInvisible()
    {
        // Mermiyi sahneden kald�r�r.
        Destroy(gameObject);
    }
}
