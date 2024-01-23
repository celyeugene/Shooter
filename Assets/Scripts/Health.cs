using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHealth = 100f;
    private float currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float playerDamage)
    {
        currentHealth -= playerDamage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Логика при смерти объекта
        Destroy(gameObject);
    }
}
