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

    public Transform playerTransform;
    public float detectionRange = 5f;

    // sound
    public AudioClip hissSound;
    private AudioSource audioSource;
    private bool hasHissed = false; 

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (GameManager.instance.isGameOver)
        {
            moveSpeed = 0f;
            return;
        }

        if (playerTransform == null) return;

        float distanceToPlayer = Vector2.Distance(transform.position, playerTransform.position);

        //Hiss 
        if (!hasHissed && distanceToPlayer <= detectionRange)
        {
            audioSource.PlayOneShot(hissSound);
            hasHissed = true;
            Invoke(nameof(ResetHiss), 5f);
        }

        if (distanceToPlayer <= detectionRange)
        {
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
    }
    void ResetHiss()
    {
        hasHissed = false;
    }
}
