using UnityEngine;
using UnityEngine.AI;

//made by Joey Docter
//movement enemy
public class EnemyController : MonoBehaviour
{
    private EnemyAnimator enemyAnim;
    private NavMeshAgent enemy;
    private Transform target;

    public float attackDistance = 1.8f;
    private float WaitBeforeAttack = 0.5f;

    public float chaseSpeed = 5f;
    private float movementSpeed;
    private float timeToMove = 0f;

    private float attackTimer;
    private int playerDamage;


    public enum EnemyState
    {
        CHASE,
        ATTACK
    }

    private EnemyState enemyState;

    void Awake()
    {
        enemy = GetComponent<NavMeshAgent>();
        enemyAnim = GetComponent<EnemyAnimator>();
        target = GameObject.FindWithTag(Tags.PLAYER_TAG).transform;

        //random value for movement and attack damage
        movementSpeed = Random.Range(4f, 10f);
        playerDamage = Random.Range(10, 30);
    }

    void Update()
    {
        switch (enemyState)
        {
            case EnemyState.CHASE: Chase(movementSpeed);
                break;
            case EnemyState.ATTACK: Attack();
                break;
        }
    }

    public void Chase(float speed)
    {
        enemyAnim.RunAnimation(true);
        //movement speed
        movementSpeed = speed;
        enemy.speed = movementSpeed;

        // timer to stop moving if movement is 0
        if (movementSpeed <= 0f)
        {
            enemyAnim.RunAnimation(false);
            timeToMove += Time.deltaTime;
            if (timeToMove >= 5f)
            {
                movementSpeed = 4f;
                timeToMove = 0f;
            }
        }

        //move to player
        float distance = Vector3.Distance(transform.position, target.transform.position);

        Vector3 moveToPlayer = transform.position - target.transform.position;
        Vector3 newPos = transform.position - moveToPlayer;

        enemy.SetDestination(newPos);

        //face direction to player
        if (distance <= enemy.stoppingDistance)
        {
            FaceTarget();
        }

        //change to attack state
        if(Vector3.Distance(transform.position, target.position) <= attackDistance)
        {
            enemyAnim.RunAnimation(false);
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
        //wait to attack
        attackTimer += Time.deltaTime;
        if (attackTimer > WaitBeforeAttack)
        {
            enemyAnim.AttackAnimation();
            PlayerHealth playerTarget = target.transform.GetComponent<PlayerHealth>();
            playerTarget.HitPlayer(playerDamage);
            attackTimer = 0f;
        };

        // stop attacking and chase player
        if (Vector3.Distance(transform.position, target.position) > attackDistance)
        {
            enemyState = EnemyState.CHASE;
        }
    }
}
