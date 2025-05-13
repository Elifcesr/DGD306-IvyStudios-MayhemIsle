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
            // Mermiyi sahneden yok eder.
            Destroy(gameObject);

            // E�er d��man�n can� 10'dan fazlaysa, hasar uygulan�r.
            if (other.GetComponent<EnemyHealth>().currentHealth > 10)
            {
                // D��man�n can�n� bulletDamage kadar azalt�r.
                other.GetComponent<EnemyHealth>().currentHealth -= bulletDamage;
            }
            // E�er d��man�n can� 10 veya daha azsa, �l�m i�lemleri ba�lat�l�r.
            else if (other.GetComponent<EnemyHealth>().currentHealth <= 10)
            {
                // D��man�n �arp��mas�n� devre d��� b�rak�r, ba�ka nesnelerle etkile�ime girmez.
                other.GetComponent<BoxCollider2D>().enabled = false;

                // D��man nesnesini sahneden 0.4 saniye sonra kald�r�r. 
                Destroy(other.gameObject, .4f);
            }
        }
    }

    private void OnBecameInvisible()
    {
        // Mermiyi sahneden kald�r�r.
        Destroy(gameObject);
    }
}
