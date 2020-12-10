using UnityEngine;

public class TargetScript : MonoBehaviour
{
    public float health = 50f;

    public static int AliveEnemy = 50;

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
        TimeController.instance.AddTime(5f);
    }
}
