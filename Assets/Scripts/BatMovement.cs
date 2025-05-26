using System.Collections;
using UnityEngine;

public class BatMovement : MonoBehaviour
{
    public Vector3 pointA;
    public Vector3 pointB;
    public float speed = 2f;

    private SpriteRenderer spriteRenderer;

    // 🔊 SES
    public AudioClip flapSound;
    private AudioSource audioSource;

    public float flapInterval = 1.5f; // Frequency of sound playback

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Ses sistemi
        audioSource = GetComponent<AudioSource>();
        if (flapSound != null && audioSource != null)
        {
            StartCoroutine(FlapSoundRoutine());
        }
    }

    void Update()
    {
        float t = Mathf.PingPong(Time.time * speed, 1);
        Vector3 newPos = Vector3.Lerp(pointA, pointB, t);
        transform.position = newPos;

        bool goingToA = Mathf.PingPong(Time.time * speed, 2f) > 1f;
        spriteRenderer.flipX = !goingToA;
    }

    // flap sound
    IEnumerator FlapSoundRoutine()
    {
        while (true)
        {
            audioSource.PlayOneShot(flapSound);
            yield return new WaitForSeconds(flapInterval);
        }
    }
}
