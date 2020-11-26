﻿using UnityEngine;

public class TargetScript : MonoBehaviour
{
    private float health = 50f;
    public static int AliveEnemy = 3;

    public void TakeDamage(float amount)
    {
        health -= amount;
        if(health <= 0f)
        {
            Death();
        }
    }

    void Death()
    {
        Destroy(gameObject);
        AliveEnemy--;
    }
}
