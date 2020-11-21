using System.Collections;
using System.Collections.Generic;
using UnityEngine;


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
            Debug.Log("hit");
        }

        


        health.SetHealth(currentHealth);
    }
}
