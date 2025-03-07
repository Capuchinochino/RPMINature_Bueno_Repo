using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D playerRb;
    public float speed;
    public float input;
    public SpriteRenderer spriteRenderer;
    public float jumpForce;

    public LayerMask groundLayer;
    private bool isGrounded;
    public Transform feetPosition;
    public float groundCheckCircle;


    void Update()
    {
        input = Input.GetAxisRaw("Horizontal");
        if (input < 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (input > 0)
        {
            spriteRenderer.flipX = true;
        }

        isGrounded = Physics2D.OverlapCircle(feetPosition.position, groundCheckCircle, groundLayer);

        if (isGrounded && Input.GetButton("Jump"))
        {
            playerRb.velocity = Vector2.up * jumpForce;
        }

    }

    void FixedUpdate()
    {
        if (!isGrounded)
        {
            playerRb.velocity = new Vector2(input * (speed + 5), playerRb.velocity.y);
        }
        else 
        {
            playerRb.velocity = new Vector2(input * speed, playerRb.velocity.y);    
        }
    }
}
