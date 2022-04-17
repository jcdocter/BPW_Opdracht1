using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AK74 : Weapon
{
    void Awake()
    {
        ammo.currentAmmo = ammo.maxAmmo;
    }

    void Update()
    {
        Fire();

        if (ammo.reload.isReloading)
        {
            return;
        }

        //update ammo text
        ammo.AmmoDisplay();
    }

    public override void Fire()
    {
        //AutoWeapon
        if (ammo.currentAmmo < 30f)
        {
            if (ammo.currentAmmo <= 0f || Input.GetKeyDown(KeyCode.R))
            {
                StartCoroutine(ammo.reload.ReloadAnimation(ammo));
                return;
            }
        }

        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
    }
    
}
