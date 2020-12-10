using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowGrenade : MonoBehaviour
{
    private float throwForce = 20f;
    public GameObject grenadePrefab;
    private float throwTimer = 3f;


    void Update()
    {
        if (throwTimer >= 3f)
        {
            this.transform.localScale = new Vector3(1, 1, 1);
            if (Input.GetMouseButtonDown(0))
            {
                Throw();
                throwTimer = 0f;
                this.transform.localScale = new Vector3(0, 0, 0);
            }
        } else
        {
            throwTimer += Time.deltaTime;
        }
    }

    void Throw()
    {
        GameObject grenade = Instantiate(grenadePrefab, transform.position, transform.rotation);
        Rigidbody rb = grenade.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * throwForce, ForceMode.VelocityChange);
    }
}
