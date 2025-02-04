using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    public int health;
    public int maxHealth = 3;
    public PanelMuerte panelMuerteScript;
    private bool isDead = false;

    private PlayerMovement playerMovementScript;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;

        if (panelMuerteScript != null) 
        {
        panelMuerteScript.panelMuerte.SetActive(false);
        }

        playerMovementScript = GetComponent<PlayerMovement>();
    }

    public void TakeDamage(int damage) 
    {
        if (isDead) return;
        health -= damage;
        if (health <= 0) 
        {
            Die();
            //gameObject.SetActive(false);
        }
    }

    void Die() 
    {
        isDead = true;

        if (playerMovementScript != null) 
        {
            playerMovementScript.enabled = false;
        }

        var playerMovement = GetComponent<Rigidbody2D>();
        if (GetComponent<Rigidbody>() != null) 
        {
        
        }
    }

}
