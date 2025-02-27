using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player Stats")]
    [SerializeField] public float moveSpeed = 5f;
    [SerializeField] public float jumpForce = 5f;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator animator;


    [SerializeField] public GameObject npc;


    [Header("Player Movement")]
    [SerializeField] private bool isFacingLeft = true;
    private bool isGrounded;
    public Transform groundCheck;
    public float groundCheckDistance = 0.2f;
    public LayerMask groundLayer;

    [Header(" ")]
    [Header("Player Health")]
    public int playerHealth = 3;
    public bool hastakendamage = false;
    public GameObject deathPanel;

    [Header(" ")]
    [Header("Player Attack")]
    [SerializeField] private GameObject attackHitbox;
    public bool canAttack = true;
    public float attackDuration = 0.5f;
    public LayerMask enemyLayer;

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
            animator.SetTrigger("Jump");
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
        if (canAttack == true) 
        {
            //moveSpeed = 0;
            //jumpForce = 0;
            animator.SetTrigger("Attack");
            canAttack = false;
            StartCoroutine(AttackCooldown());
            attackHitbox.SetActive(true);
            StartCoroutine(DisableHitbox());
        }
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
        moveSpeed = 0;
        jumpForce = 0;
        Time.timeScale = 0f;
        if (deathPanel != null)
        {
            deathPanel.SetActive(true);
        }

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") && hastakendamage == false)
        {
            {
                TakeDamage(1);
                //Debug.Log("Daño al player");
                hastakendamage = true;
            }
        }
    }
    IEnumerator AttackCooldown()
    {
        yield return new WaitForSeconds(1f);
        canAttack = true;
        //jumpForce = 5f;
        //moveSpeed = 5f;
    }
    IEnumerator DisableHitbox()
    {
        yield return new WaitForSeconds(0.5f);
        attackHitbox.SetActive(false);
    }
}