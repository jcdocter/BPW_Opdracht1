using UnityEngine;

//made by Joey Docter
//health script for enemy
public class TargetScript : MonoBehaviour
{
    private float health = 100f;

    public static int AliveEnemy = 50;

    //take damage form player
    public void TakeDamage(float amount)
    {
        health -= amount;
        if(health <= 0f)
        {
            Death();
            GenerateEnemies.enemyLeft--;
        }
    }

    // death and gain time
    void Death()
    {
        Destroy(gameObject);
        AliveEnemy--;
        TimeController.instance.AddTime(2f);
    }
}
