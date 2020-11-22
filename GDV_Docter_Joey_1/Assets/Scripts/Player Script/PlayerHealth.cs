using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    private int damage = 10;

    public HealthUI health;

    void Awake()
    {
        currentHealth = maxHealth;
        health.SetMaxHealth(maxHealth);
    }

    void OnCollisionEnter(Collision other)
    {

        if(other.gameObject.tag == "Enemy")
        {
            currentHealth -= damage;
        }

        health.SetHealth(currentHealth);

        if(currentHealth <= 0)
        {
            Death();
        }
    }

    void Death()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
