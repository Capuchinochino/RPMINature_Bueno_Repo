using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    private float currentHealth;

    public GameObject healthBar;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }

        UpdateHealthBar();
    }

    private void Die()
    {
        // Aqu� puedes a�adir el comportamiento cuando el jefe muere, como desactivarlo, reproducir una animaci�n, etc.
        Debug.Log("El jefe ha muerto");
        gameObject.SetActive(false);
    }

    private void UpdateHealthBar()
    {
        // Aqu� actualizas la barra de vida del jefe, por ejemplo:
        // healthBar.transform.localScale = new Vector3(currentHealth / maxHealth, 1, 1);
    }
}