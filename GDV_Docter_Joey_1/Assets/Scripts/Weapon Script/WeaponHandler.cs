using UnityEngine;
using System.Collections;
using TMPro;
public class WeaponHandler : MonoBehaviour
{
    public float damage = 10f;
    private float range = 100f;
    private float fireRate = 15f;

    public int maxAmmo = 10;
    private int currentAmmo;
    private float reloadTime = 1f;
    private bool isReloading = false;

    public TextMeshProUGUI ammoText;

    public Camera fpsCam;

    public ParticleSystem muzzleFlash;

    private float nextTimeToFire = 0f;

    public Animator animator;

    void Awake()
    {
        currentAmmo = maxAmmo;
    }

    void Update()
    {
        if (isReloading)
        {
            return;
        }

        if(currentAmmo <= 0)
        {
            StartCoroutine(Reload());
            return;
        }

        if (Input.GetButtonDown("Fire1"))
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }

        Ammo();
    }

    void Shoot()
    {
        muzzleFlash.Play();

        currentAmmo--;

        RaycastHit hit;
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            TargetScript target = hit.transform.GetComponent<TargetScript>();
            target?.TakeDamage(damage);
        }
    }

    IEnumerator Reload()
    {
        isReloading = true;

        animator.SetBool("Reloading", true);
        yield return new WaitForSeconds(reloadTime - 0.25f);

        animator.SetBool("Reloading", false);
        yield return new WaitForSeconds(0.25f);
        currentAmmo = maxAmmo;

        isReloading = false;
    }

    void OnEnable()
    {
        isReloading = false;
        animator.SetBool("Reloading", false);
    }

    void Ammo()
    {
        ammoText.text = currentAmmo.ToString() + " / " + maxAmmo.ToString();
    }
}
