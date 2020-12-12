using UnityEngine;

//made by Joey Docter
//grenades

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

    void Start()
    {
        countdown = delay;
    }

    void Update()
    {
        countdown -= Time.deltaTime;
        //explode only if the countdown is 0 and if it hasn't exploded
        if (countdown <= 0f && !hasExploded)
        {
            Explode();
            hasExploded = true;
        }
    }

    void Explode()
    {
        // include explosion effect
           Instantiate(explosionEffect, transform.position, transform.rotation);
           Collider[] collidersToHit = Physics.OverlapSphere(transform.position, radius);

              foreach(Collider nearbyObject in collidersToHit)
              {
                   //is the enemy near by the grenade
                  TargetScript target = nearbyObject.GetComponent<TargetScript>();
                  EnemyController targetMovement = nearbyObject.GetComponent<EnemyController>();

                  //take damage if it's a frag grenade
                  if(target != null && grenadeType.gameObject.tag == Tags.RGD5_TAG)
                  {
                      target.TakeDamage(damage);
                  }

                  //stop enemy movement if it's a falsh grenade
                  if (target != null && grenadeType.gameObject.tag == Tags.FLASH_TAG)
                  {
                    targetMovement.Chase(0f);
                  }
        }

              Collider[] collidersToMove = Physics.OverlapSphere(transform.position, radius);
              
              //hit enemies near by
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
