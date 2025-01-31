using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10f; // Velocidad del proyectil
    private Vector2 direction; // Dirección en la que se mueve el proyectil

    public void SetDirection(Vector2 dir)
    {
        direction = dir;
    }

    void Update()
    {
        // Mover el proyectil en la dirección asignada
        transform.Translate(direction * speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Aquí podrías agregar la lógica cuando el proyectil impacte (por ejemplo, daño al jugador)
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("¡El proyectil golpeó al jugador!");
            Destroy(gameObject); // Destruir el proyectil al colisionar
        }
    }
}
