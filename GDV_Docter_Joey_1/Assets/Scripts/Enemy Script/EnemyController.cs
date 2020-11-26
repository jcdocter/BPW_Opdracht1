using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    private NavMeshAgent enemy;
    private Transform target;

    public float attackDistance = 1.8f;
    public float chaseAfterAttackDistance = 2f;

    private float WaitBeforeAttack = 0.5f;
    private float attackTimer;
    private int playerDamage = 10;


    public enum EnemyState
    {
        CHASE,
        ATTACK
    }

    private EnemyState enemyState;

    void Awake()
    {
        enemy = GetComponent<NavMeshAgent>();
        target = GameObject.FindWithTag(Tags.PLAYER_TAG).transform;
    }

    void Update()
    {
        switch (enemyState)
        {
            case EnemyState.CHASE: Chase();
                break;
            case EnemyState.ATTACK: Attack();
                break;
        }
    }

    void Chase()
    {
        float distance = Vector3.Distance(transform.position, target.transform.position);

        Vector3 moveToPlayer = transform.position - target.transform.position;
        Vector3 newPos = transform.position - moveToPlayer;

        enemy.SetDestination(newPos);

        if (distance <= enemy.stoppingDistance)
        {
            FaceTarget();
        }

        if(Vector3.Distance(transform.position, target.position) <= attackDistance)
        {
            enemyState = EnemyState.ATTACK;
        }
    }

    void FaceTarget()
    {
        Vector3 direction = (target.transform.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    void Attack()
    {
        attackTimer += Time.deltaTime;
        if (attackTimer > WaitBeforeAttack)
        {
            PlayerHealth playerTarget = target.transform.GetComponent<PlayerHealth>();
            playerTarget.HitPlayer(playerDamage);
            attackTimer = 0f;
        };

        if (Vector3.Distance(transform.position, target.position) > attackDistance)
        {
            enemyState = EnemyState.CHASE;
        }
    }
}
