using UnityEngine;
using System.Collections;
using TMPro;
public class WeaponHandler : MonoBehaviour
{
    public float damage = 10f;
    private float range = 100f;
    private float fireRate = 5f;

    private float nextTimeToFire = 0f;

    public int maxAmmo = 10;
    private int currentAmmo;
    private float reloadTime = 1f;
    private bool isReloading = false;

    public TextMeshProUGUI ammoText;

    public Camera fpsCam;

    public ParticleSystem muzzleFlash;

    public Animator animator;
    public GameObject weaponType;

    public enum WeaponType
    {
        M1911,
        AK74
    }

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
        //Pistol weapon
        if (weaponType.gameObject.name == "M1911")
        {
            if (currentAmmo < 10)
            {
                if (currentAmmo <= 0 || Input.GetKeyDown(KeyCode.R))
                {
                    StartCoroutine(Reload());
                    return;
                }
            }

            if (Input.GetButtonDown("Fire1"))
            {
                nextTimeToFire = Time.time + 1f / fireRate;
                Shoot();
            }
        }

        //AutoWeapon
        if(weaponType.gameObject.name == "AK74")
        {
            if (currentAmmo < 30)
            {
                if (currentAmmo <= 0 || Input.GetKeyDown(KeyCode.R))
                {
                    StartCoroutine(Reload());
                    return;
                }
            }

            if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
            {
                nextTimeToFire = Time.time + 1f / fireRate;
                Shoot();
            }
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
