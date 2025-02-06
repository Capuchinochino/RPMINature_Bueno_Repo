using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;


public class NPCController : MonoBehaviour
{
    public Transform player;
    public float speed = 3f;
    public float detectionRange = 5f;
    public int npcHealth = 1;
    public float damageAmount = 1f;



    public Transform patrolPointA;
    public Transform patrolPointB;
    public Transform currentPatrolPoint;

    private bool isChasing = false;
    private bool isFacingRight = false;

    private Vector2 lastPosition;

    private Rigidbody2D rb;

    //public bool hasAttacked = false;

    void Start()
    {
        currentPatrolPoint = patrolPointA;
        lastPosition = transform.position;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);
        bool isPlayerInPatrolZone = IsPlayerWithinPatrolZone();

        if (distanceToPlayer <= detectionRange && isPlayerInPatrolZone)
        {
            isChasing = true;
        }
        else
        {
            isChasing = false;
        }

        if (isChasing)
        {
            MoveTowards(player.position);
        }
        else
        {
            MoveTowards(currentPatrolPoint.position);

            if (Vector2.Distance(transform.position, currentPatrolPoint.position) < 0f)
            {
                currentPatrolPoint = (currentPatrolPoint == patrolPointA) ? patrolPointB : patrolPointA;
                Flip();
            }
        }
    }

    private void MoveTowards(Vector2 target)
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if (target.x != lastPosition.x)
        {
            if ((target.x > transform.position.x && !isFacingRight) || (target.x < transform.position.x && isFacingRight))
            {
                Flip();
            }
        }
        lastPosition = transform.position;
    }
    private void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }

    private bool IsPlayerWithinPatrolZone()
    {
        float minX = Mathf.Min(patrolPointA.position.x, patrolPointB.position.x);
        float maxX = Mathf.Max(patrolPointA.position.x, patrolPointB.position.x);

        return player.position.x >= minX && player.position.x <= maxX;
    }

    public void TakeDamage(int damage)
    {
        npcHealth -= damage;
        if (npcHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        if (gameObject.activeInHierarchy)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController player = other.GetComponent<PlayerController>();
            if (player != null)
            {
                player.TakeDamage(1);
                //Debug.Log("Daño al player");
            }
        }
            //hasAttacked = true;

        if (other.CompareTag("Enemy"))
        {
            currentPatrolPoint = (currentPatrolPoint == patrolPointA) ? patrolPointB : patrolPointA;
            Flip();
        }

        if (other.CompareTag("PlayerAttack"))
        {
            TakeDamage(1);
            //Debug.Log("DAño al npc");
        }
    }
}