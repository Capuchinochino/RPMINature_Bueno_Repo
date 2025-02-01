using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    private Rigidbody2D rb;
    private Animator animator;

    public Transform groundCheck; // Añadir este campo
    public float groundCheckDistance = 0.2f; // Distancia del raycast
    public LayerMask groundLayer; // Capa del suelo

    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {

       

            // Verificar si está tocando el suelo
            isGrounded = Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckDistance, groundLayer);

        // Salto
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
           
        }

       
    

    Move();
    
        UpdateAnimator();

          

            }

    private void Move()
    {
        float moveInput = Input.GetAxis("Horizontal");
        Vector3 move = new Vector3(moveInput, 0, 0) * moveSpeed * Time.deltaTime;
        transform.Translate(move);

        // Usar el GroundCheck para verificar si está en el suelo
        isGrounded = Physics.Raycast(groundCheck.position, Vector3.down, groundCheckDistance, groundLayer);
    }
     
    private void Jump()
    {
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
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
      
        

    }