using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHitbox : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        NPCController enemy = collision.GetComponent<NPCController>();
        Debug.Log("Hit enemy");
        enemy.TakeDamage(1);
    }
}
