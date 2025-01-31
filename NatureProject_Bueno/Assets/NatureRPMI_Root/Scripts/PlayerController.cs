using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D Rigidbody2D;
    private float Horizontal;

    public float speed = 5f;
    public float jumpForce = 5f;

    private bool isGrounded;

    public float groundCheckDistance = 0.1f; // Distancia del Raycast

    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");

        // Raycast hacia abajo para comprobar si el jugador está tocando el suelo
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance);

        // Salto si está en el suelo
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Rigidbody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    private void FixedUpdate()
    {
        Rigidbody2D.velocity = new Vector2(Horizontal * speed, Rigidbody2D.velocity.y);
    }

    // Mostrar el raycast en la escena (opcional para depuración)
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * groundCheckDistance);
    }
}