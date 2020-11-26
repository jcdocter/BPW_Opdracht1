using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    private float refillTimer = 0f;

    public HealthUI health;

    void Awake()
    {
        currentHealth = maxHealth;
        health.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        RefillHealth();
    }
    public void HitPlayer(int damage)
    {

        currentHealth -= damage;
        refillTimer = 0f;

        health.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            Death();
        }
    }

    void RefillHealth()
    {
        if (currentHealth != maxHealth)
        {
            refillTimer += Time.deltaTime;
            Debug.Log(refillTimer + " " + currentHealth);

            if (refillTimer > 3f)
            {
                currentHealth += 1;
                health.SetHealth(currentHealth);
            }
        }

        if(currentHealth >= maxHealth)
        {
            currentHealth = maxHealth;
            refillTimer = 0f;
        }
    }

    void Death()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
