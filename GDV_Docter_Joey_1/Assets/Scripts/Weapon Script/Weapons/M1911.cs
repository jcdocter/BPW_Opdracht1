using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M1911 : Weapon
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
        //Pistol weapon
        if (ammo.currentAmmo < 10f)
        {
            if (ammo.currentAmmo <= 0f || Input.GetKeyDown(KeyCode.R))
            {
                StartCoroutine(ammo.reload.ReloadAnimation(ammo));
                return;
            }
        }

        if (Input.GetButtonDown("Fire1"))
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
    }
}
