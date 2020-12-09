using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenades : MonoBehaviour
{
    private float delay = 3f;
    private float radius = 5f;
    private float force = 700f;

    public GameObject explosionEffect;

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

                  if(target != null)
                  {
                      target.TakeDamage(40);
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
