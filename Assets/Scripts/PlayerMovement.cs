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

    public bool stopMovement = false; //Gamemanager and Health Control

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (stopMovement) return;

        Jump();
        Attack(); // Triggering Sword animation

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
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            isGrounded = false;
            rb2d.velocity = Vector2.up * jumpSpeed;
        }

        if (!isGrounded)
        {
            playerAnimator.SetBool("isJumping", true);
        }
        else
        {
            playerAnimator.SetBool("isJumping", false);
        }
    }

    // Triggering Sword animation
    private void Attack()
    {
        if (Input.GetMouseButtonDown(0)) // left click
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
