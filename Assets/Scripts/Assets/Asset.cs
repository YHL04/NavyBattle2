using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asset : MonoBehaviour
{
    public GameObject deathEffect;
    public Healthbar healthbar;

    public int maxHealth;
    public int currentHealth;

    public void SetMaxHealth(int maxHealth)
    {
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthbar.SetHealth(currentHealth);

        if(currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
