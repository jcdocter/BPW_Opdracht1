using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperWeapon : Weapon
{
    void Update()
    {
        Fire();

        //update ammo text
        ammo.AmmoDisplay();
    }

    public override void Fire()
    {
        //Power up weapon
        // ammo is equal to 60 from the timer
        ammo.currentAmmo = Mathf.RoundToInt(WeaponWheel.powerUpTimer);

        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
            WeaponWheel.powerUpTimer--;
        }

        if (ammo.currentAmmo <= 0f)
        {
            SwitchWeapon.instance.SelectWeapon(0);

            WeaponWheel.powerUpTimer = 0f;
            WeaponWheel.stopCounting = false;
        }
    }
}
