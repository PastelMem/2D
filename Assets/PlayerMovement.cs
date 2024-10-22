using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed of the player
    public float jumpForce = 10f; // Force applied when jumping

    private Rigidbody2D rb;
    private Animator animator;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        // Ensure the scale is correct
        transform.localScale = new Vector3(0.3f, 0.3f, 1f); // Set the scale explicitly
    }

    void Update()
    {
        MovePlayer();
        Jump();
    }

    void MovePlayer()
    {
        float moveInput = Input.GetAxis("Horizontal"); // Get horizontal input
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y); // Set velocity

        // Update Animation
        if (moveInput != 0)
        {
            animator.SetBool("isWalking", true); // Trigger walking animation
        }
        else
        {
            animator.SetBool("isWalking", false); // Trigger idle animation
        }

        // Flip the player based on direction
        if (moveInput > 0)
        {
            transform.localScale = new Vector3(0.3f, 0.3f, 1f); // Keep scale constant when facing right
        }
        else if (moveInput < 0)
        {
            transform.localScale = new Vector3(-0.3f, 0.3f, 1f); // Keep scale constant when facing left
        }
    }

    void Jump()
    {
        if (isGrounded && Input.GetButtonDown("Jump")) // Check for jump input
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse); // Apply jump force
            animator.SetTrigger("isFlying"); // Trigger jump animation
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")) // Check if on the ground
        {
            isGrounded = true; // Set grounded state
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")) // Check if leaving ground
        {
            isGrounded = false; // Set not grounded state
        }
    }
}

