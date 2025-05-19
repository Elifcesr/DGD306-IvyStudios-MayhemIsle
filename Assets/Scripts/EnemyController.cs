using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed;
    public Vector2 startDirection;
    public bool shouldChangeDirection;
    public float changeDirectionXPoint;
    public int maxHealth;
    public int currentHealth;
    public int damageAmount;
    public Vector2 changedDirection;

    public Transform playerTransform; // ← Oyuncunun Transform'u
    public float detectionRange = 5f; // ← Düşmanın oyuncuyu algılayacağı mesafe

    void Update()
    {
        if (GameManager.instance.isGameOver)
        {
            moveSpeed = 0f;
            return;
        }

        if (playerTransform == null) return; // Oyuncu atanmamışsa devam etme

        float distanceToPlayer = Vector2.Distance(transform.position, playerTransform.position);

        if (distanceToPlayer <= detectionRange)
        {
            // Oyuncu algılama mesafesinde → hareket et
            if (!shouldChangeDirection)
            {
                transform.position += new Vector3(startDirection.x * moveSpeed * Time.deltaTime,
                                                  startDirection.y * moveSpeed * Time.deltaTime, 0f);
            }
            else
            {
                if (transform.position.x > changeDirectionXPoint)
                {
                    transform.position += new Vector3(startDirection.x * moveSpeed * Time.deltaTime,
                                                      startDirection.y * moveSpeed * Time.deltaTime, 0f);
                }
                else
                {
                    transform.position += new Vector3(changedDirection.x * moveSpeed * Time.deltaTime,
                                                      changedDirection.y * moveSpeed * Time.deltaTime, 0f);
                }
            }
        }
        // Eğer oyuncu çok uzaktaysa → düşman durur (hiçbir hareket yapılmaz)
    }
}