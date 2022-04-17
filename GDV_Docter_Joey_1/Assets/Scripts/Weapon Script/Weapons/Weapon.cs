using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public abstract class Weapon : MonoBehaviour, IShoot
{
    public float damage;

    public float fireRate = 5f;
    public float nextTimeToFire = 0f;
    
    public Camera fpsCam;
    public ParticleSystem muzzleFlash;

    public Ammo ammo;

    private float range = 100f;

    public abstract void Fire();

    public void Shoot()
    {
        //activate shoot animation
        muzzleFlash.Play();

        //decrease ammo
        ammo.currentAmmo--;

        //hit enemy
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            TargetScript target = hit.transform.GetComponent<TargetScript>();
            target?.TakeDamage(damage);
        }
    }
}
