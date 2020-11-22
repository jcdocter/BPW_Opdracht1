using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    private NavMeshAgent enemy;
    private Transform target;


    void Awake()
    {
        enemy = GetComponent<NavMeshAgent>();
        target = GameObject.FindWithTag(Tags.PLAYER_TAG).transform;
    }

    void Update()
    {
     float distance = Vector3.Distance(transform.position, target.transform.position);

            Vector3 moveToPlayer = transform.position - target.transform.position;
            Vector3 newPos = transform.position - moveToPlayer;

            enemy.SetDestination(newPos);

      if(distance <= enemy.stoppingDistance)
        {
            FaceTarget();
        }
    }

    void FaceTarget()
    {
        Vector3 direction = (target.transform.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }
}
