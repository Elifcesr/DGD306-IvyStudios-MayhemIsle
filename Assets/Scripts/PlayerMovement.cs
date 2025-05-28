using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private float jumpSpeed;

    private float horizontalMovement;
    private bool isGrounded = false;
    private bool isFacingRight = true;

    private Rigidbody2D rb2d;
    private Animator playerAnimator;

    public bool stopMovement = false; // GameManager and Health Control

    public AudioClip walkSound;
    public AudioClip jumpSound;
    private AudioSource audioSource;

    private bool isWalkingSoundPlaying = false;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (stopMovement) return;

        Jump();
        Attack(); // Triggering Sword animation

        HandleWalkSound();

        if (horizontalMovement > 0 && !isFacingRight)
        {
            FlipSprite();
        }
        else if (horizontalMovement < 0 && isFacingRight)
        {
            FlipSprite();
        }
    }

    private void FixedUpdate()
    {
        if (stopMovement) return;

        Movement();
    }

    private void Movement()
    {
        horizontalMovement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(horizontalMovement * movementSpeed * Time.deltaTime, 0, 0);
        playerAnimator.SetFloat("Speed", MathF.Abs(horizontalMovement));
    }

    private void Jump()
    {
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Joystick1Button2)) && isGrounded)
        {
            isGrounded = false;
            rb2d.velocity = Vector2.up * jumpSpeed;

            // play jump sound
            if (jumpSound != null && audioSource != null)
            {
                audioSource.PlayOneShot(jumpSound);
            }
        }

        playerAnimator.SetBool("isJumping", !isGrounded);
    }

    private void HandleWalkSound()
    {
        if (Mathf.Abs(horizontalMovement) > 0.1f && isGrounded)
        {
            if (!isWalkingSoundPlaying && walkSound != null)
            {
                audioSource.clip = walkSound;
                audioSource.loop = true;
                audioSource.Play();
                isWalkingSoundPlaying = true;
            }
        }
        else
        {
            if (isWalkingSoundPlaying)
            {
                audioSource.Stop();
                isWalkingSoundPlaying = false;
            }
        }
    }

    private void Attack()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Joystick1Button0)) // left click
        {
            playerAnimator.SetTrigger("Sword");
        }
    }

    private void FlipSprite()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;
        isFacingRight = !isFacingRight;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Platform")
        {
            isGrounded = true;
        }
    }
}
