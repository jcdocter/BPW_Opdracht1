using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    private NavMeshAgent enemy;
    public GameObject player;


    void Awake()
    {
        enemy = GetComponent<NavMeshAgent>();    
    }

    void Update()
    {
     float distance = Vector3.Distance(transform.position, player.transform.position);

            Vector3 moveToPlayer = transform.position - player.transform.position;
            Vector3 newPos = transform.position - moveToPlayer;

            enemy.SetDestination(newPos);

      if(distance <= enemy.stoppingDistance)
        {
            FaceTarget();
        }
    }

    void FaceTarget()
    {
        Vector3 direction = (player.transform.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }
}
