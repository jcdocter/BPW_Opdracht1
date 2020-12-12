using UnityEngine;

//made by Joey Docter
//player health
public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    private float refillTimer = 0f;

    public HealthUI health;

    void Awake()
    {
        //start max health
        currentHealth = maxHealth;
        health.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        RefillHealth();
    }
    public void HitPlayer(int damage)
    {
        //take damage
        currentHealth -= damage;
        refillTimer = 0f;

        health.SetHealth(currentHealth);

        //death
        if (currentHealth <= 0)
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }

    void RefillHealth()
    {
        if (currentHealth != maxHealth)
        {
            refillTimer += Time.deltaTime;

            // gain health back
            if (refillTimer > 3f)
            {
                currentHealth += 1;
                health.SetHealth(currentHealth);
            }
        }
        // cant go further than max health
        if(currentHealth >= maxHealth)
        {
            currentHealth = maxHealth;
            refillTimer = 0f;
        }
    }
}
