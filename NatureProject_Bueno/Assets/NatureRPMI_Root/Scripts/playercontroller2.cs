using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    private Rigidbody2D rb;
    private Animator animator;

    public GameObject npc;

    public Transform groundCheck;
    public float groundCheckDistance = 0.2f;
    public LayerMask groundLayer;

    private bool isFacingLeft = true;
    private bool isGrounded;

    public int playerHealth = 3;
    public GameObject attackColliderPrefab;
    public float attackDuration = 0.5f;

    public LayerMask enemyLayer;
    public GameObject deathPanel;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();


        if (deathPanel != null)
        {
            deathPanel.SetActive(false);
        }
    }

    void Update()
    {
        isGrounded = Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckDistance, groundLayer);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }

        Move();
        UpdateAnimator();

        if (Input.GetKeyDown(KeyCode.F))
        {
            Attack();
        }
    }

    private void Move()
    {
        float moveInput = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

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
        if (isGrounded == true && Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
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
        if (rb.velocity.x > 0 && isFacingLeft || rb.velocity.x < 0 && !isFacingLeft)
        {
            isFacingLeft = !isFacingLeft;
            Vector3 scale = transform.localScale;
            scale.x *= -1; // Invierte la escala en el eje X
            transform.localScale = scale;
        }
    }

    private void Attack()
    {
        animator.SetTrigger("Attack");

        Vector3 attackPosition = transform.position + (isFacingLeft ? Vector3.left : Vector3.right) * 1.5f;
        GameObject attackObject = Instantiate(attackColliderPrefab, attackPosition, Quaternion.identity);
        attackObject.tag = "PlayerAttack";

        Destroy(attackObject, attackDuration);

        attackObject.SetActive(true);
    }

    public void TakeDamage(int damage)
    {
        playerHealth -= damage;
        Debug.Log("Agh");

        if (playerHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // Debug.Log("El Jugador ha muerto");
        animator.SetTrigger("Die");
        rb.velocity = Vector2.zero;
        moveSpeed = 0;
        jumpForce = 0;
        Time.timeScale = 0f;
        if (deathPanel != null)
        {
            deathPanel.SetActive(true);
        }

    }

    //private void OnDrawGizmos()
    //{
    //Gizmos.color = Color.red;
    //Gizmos.DrawLine(groundCheck.position, groundCheck.position + Vector3.down * groundCheckDistance);
    //}
}