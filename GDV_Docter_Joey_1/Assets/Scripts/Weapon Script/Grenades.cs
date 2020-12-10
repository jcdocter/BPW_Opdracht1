using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenades : MonoBehaviour
{
    private float delay = 3f;
    private float radius = 5f;
    private float force = 700f;
    private float damage = 40f;

    public GameObject explosionEffect;
    public GameObject grenadeType;

    private float countdown;

    private bool hasExploded = false;

    // Start is called before the first frame update
    void Start()
    {
        countdown = delay;
    }

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;

        if (countdown <= 0f && !hasExploded)
        {
            Explode();
            hasExploded = true;
        }
    }

    void Explode()
    {
           Instantiate(explosionEffect, transform.position, transform.rotation);
           Collider[] collidersToHit = Physics.OverlapSphere(transform.position, radius);

              foreach(Collider nearbyObject in collidersToHit)
              {
                  TargetScript target = nearbyObject.GetComponent<TargetScript>();
                  EnemyController targetMovement = nearbyObject.GetComponent<EnemyController>();

                  if(target != null && grenadeType.gameObject.tag == Tags.RGD5_TAG)
                  {
                      target.TakeDamage(damage);
                  }
                  if (target != null && grenadeType.gameObject.tag == Tags.FLASH_TAG)
                  {
                    targetMovement.Chase(0f);
                  }
        }

              Collider[] collidersToMove = Physics.OverlapSphere(transform.position, radius);

              foreach (Collider nearbyObject in collidersToMove)
              {
                  Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
                  if (rb != null)
                  {
                      rb.AddExplosionForce(force, transform.position, radius);
                  }
              }

              Destroy(gameObject);
    }
}
