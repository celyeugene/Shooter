using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] public static float playerMaxHealth = 100f;
    public static float currentHealth;

    void Start()
    {
        currentHealth = playerMaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void TakeDamage(float enemyDamage)
    {
        currentHealth -= enemyDamage;
        Debug.Log("Player Health: " + currentHealth);

        if (currentHealth <= 0)
        {
            Debug.Log("tot idi nahui");
        }
    }

    /*void Die()
    {
        // Логика при смерти объекта
        Destroy(gameObject);
    }*/
}
