using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Reload
{
    public bool isReloading = false;

    public Animator animator;

    private float reloadTime = 1f;


    //reload weapon
    public IEnumerator ReloadAnimation(Ammo _ammo)
    {
        isReloading = true;

        animator.SetBool("Reloading", true);
        yield return new WaitForSeconds(reloadTime - 0.25f);

        animator.SetBool("Reloading", false);
        yield return new WaitForSeconds(0.25f);
        _ammo.currentAmmo = _ammo.maxAmmo;

        isReloading = false;
    }
}
