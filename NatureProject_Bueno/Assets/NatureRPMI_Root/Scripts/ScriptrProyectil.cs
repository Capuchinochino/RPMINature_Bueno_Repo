using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10f; // Velocidad del proyectil
    private Vector2 direction; // Direcci�n en la que se mueve el proyectil

    public void SetDirection(Vector2 dir)
    {
        direction = dir;
    }

    void Update()
    {
        // Mover el proyectil en la direcci�n asignada
        transform.Translate(direction * speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Aqu� podr�as agregar la l�gica cuando el proyectil impacte (por ejemplo, da�o al jugador)
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("�El proyectil golpe� al jugador!");
            Destroy(gameObject); // Destruir el proyectil al colisionar
        }
    }
}
