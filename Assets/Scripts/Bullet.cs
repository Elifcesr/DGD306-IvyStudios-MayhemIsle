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
            // Mermiyi sahneden yok eder.
            Destroy(gameObject);

            // Eðer düþmanýn caný 10'dan fazlaysa, hasar uygulanýr.
            if (other.GetComponent<EnemyHealth>().currentHealth > 10)
            {
                // Düþmanýn canýný bulletDamage kadar azaltýr.
                other.GetComponent<EnemyHealth>().currentHealth -= bulletDamage;
            }
            // Eðer düþmanýn caný 10 veya daha azsa, ölüm iþlemleri baþlatýlýr.
            else if (other.GetComponent<EnemyHealth>().currentHealth <= 10)
            {
                // Düþmanýn çarpýþmasýný devre dýþý býrakýr, baþka nesnelerle etkileþime girmez.
                other.GetComponent<BoxCollider2D>().enabled = false;

                // Düþman nesnesini sahneden 0.4 saniye sonra kaldýrýr. 
                Destroy(other.gameObject, .4f);
            }
        }
    }

    private void OnBecameInvisible()
    {
        // Mermiyi sahneden kaldýrýr.
        Destroy(gameObject);
    }
}
