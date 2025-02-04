using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NPCController : MonoBehaviour
{
    public Transform player;            // Referencia al jugador
    public GameObject projectilePrefab; // Prefabricado del proyectil
    public float speed = 3f;            // Velocidad de persecución
    public float detectionRange = 5f;   // Distancia a la que el NPC detecta al jugador
    public float attackCooldown = 2f;   // Tiempo de espera entre disparos
    private float attackTimer = 0f;     // Temporizador para el disparo
    public Transform patrolPointA;
    public Transform patrolPointB;
    public Transform currentPatrolPoint;
    private bool isChasing = false;

    void Start() { currentPatrolPoint = patrolPointA; }

    void Update()
    {
        //MoveTowardsPlayer();

        // Verifica la distancia al jugador
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);


        if (distanceToPlayer <= detectionRange) { isChasing = true; } else { isChasing = false; }
        if (isChasing) { MoveTowardsPlayer(); } else { Patrol();}


        // Si el jugador está dentro del rango de detección
        if (distanceToPlayer <= detectionRange)
        {
            // Si el NPC está listo para disparar (basado en el cooldown)
            if (attackTimer <= 0f)
            {
                ShootProjectile();
                attackTimer = attackCooldown; // Reiniciar el temporizador de disparo
            }
        }

        // Decrementar el temporizador de disparo
        if (attackTimer > 0f)
        {
            attackTimer -= Time.deltaTime;
        }



    }
    private void MoveTowardsPlayer() 
    {
        Vector2 direction = (player.position - transform.position).normalized;
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }

    private void Patrol()
    {
        transform.position = Vector2.MoveTowards(transform.position, currentPatrolPoint.position, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, currentPatrolPoint.position) < 0.1f) 
        {
            if (currentPatrolPoint == patrolPointA)
            {
                currentPatrolPoint = patrolPointB;
            }
            else 
            {
                currentPatrolPoint = patrolPointA;
            }
        }


    }



    private void ShootProjectile()
    {
        // Crear el proyectil y asignarle la dirección del disparo
        GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        Vector2 direction = (player.position - transform.position).normalized;
        projectile.GetComponent<Projectile>().SetDirection(direction);
    }
}