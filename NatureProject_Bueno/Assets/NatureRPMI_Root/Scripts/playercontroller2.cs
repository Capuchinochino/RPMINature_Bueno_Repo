using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    private Rigidbody2D rb;
    private Animator animator;

    public Transform groundCheck;
    public float groundCheckDistance = 0.2f;
    public LayerMask groundLayer;
    private bool isFacingLeft = true;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        isGrounded = Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckDistance, groundLayer);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            Attack();
        }

        Move();
        UpdateAnimator();
    }

    private void Move()
    {
        float moveInput = Input.GetAxis("Horizontal");

        Vector3 move = new Vector3(moveInput, 0, 0) * moveSpeed * Time.deltaTime;
        transform.Translate(move);

        if (moveInput > 0 && isFacingLeft)
        {
            Flip();
        }
        else if (moveInput < 0 && !isFacingLeft)
        {
            Flip();
        }
    }

    private void Jump()
    {
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            animator.SetBool("isJumping", true);
        }
    }

    private void UpdateAnimator()
    {
        float moveInput = Input.GetAxis("Horizontal");
        animator.SetBool("isRunning", moveInput != 0);

        if (isGrounded && animator.GetBool("isJumping"))
        {
            animator.SetBool("isJumping", false);
        }
    }

    private void Flip()
    {
        isFacingLeft = !isFacingLeft;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    private void Attack()
    {
        Debug.Log("El ataque se ha ejecutado");
        animator.SetTrigger("Attack");
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(groundCheck.position, groundCheck.position + Vector3.down * groundCheckDistance);
    }
}
