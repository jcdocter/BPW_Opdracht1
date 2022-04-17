using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Ammo : MonoBehaviour
{
    public float maxAmmo;
    public float currentAmmo;

    public TextMeshProUGUI ammoText;
    public Reload reload;

    //display ammo
    public void AmmoDisplay()
    {
        ammoText.text = currentAmmo.ToString() + " / " + maxAmmo.ToString();
    }

    void OnEnable()
    {
        reload.isReloading = false;
        reload.animator.SetBool("Reloading", false);
    }
}
