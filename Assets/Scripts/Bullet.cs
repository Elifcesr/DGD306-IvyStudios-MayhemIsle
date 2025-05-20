using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Oyunda merminin saniyede kaç birim gideceðini belirtir. 
    public float shotSpeed = 7f;

    // Merminin düþmana vereceði hasar miktarý.
    public int bulletDamage = 10;

                                         
    void Start()
    {
        // Mermi sahnede en fazla 3 saniye kalýr, sonra yok edilir.
        Destroy(gameObject, 1f);

    }

    // Merminin sürekli saða doðru hareket etmesi saðlanýr.
    private void Update()
    {
        // Merminin x ekseninde shotSpeed hýzýnda ilerlemesini saðlar.
        // Time.deltaTime kullanýmý, kare hýzýndan baðýmsýz hareket saðlar.
        transform.position += new Vector3(shotSpeed * Time.deltaTime, 0f, 0f);
    }

    // Baþka bir nesne ile çarpýþma gerçekleþtiðinde tetiklenir.
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            // Mermiyi yok et
            Destroy(gameObject);

            // EnemyHealth bileþenini al
            EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(bulletDamage);
            }
        }
    }


    private void OnBecameInvisible()
    {
        // Mermiyi sahneden kaldýrýr.
        Destroy(gameObject);
    }
}
